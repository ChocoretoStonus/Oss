using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Main_BGI : MonoBehaviour
{

    #region Variables

    [SerializeField] GameObject ParalaxDis, ParalaxEna;
    [SerializeField] Data_System data_system;
    [SerializeField] Songs_Menu Audio_System;
    [SerializeField] public string Cancion;
    [SerializeField] Image Default_Image;
    [SerializeField] Sprite[] Fondos;
    [SerializeField] Color Degradiente;
    [HideInInspector] public bool fa_In, fa_Out;
    [SerializeField] GameObject paralaxObj;
    [SerializeField] float mouseX, mouseY;
    [SerializeField] public bool perm, press;
    Data datos;
    #endregion



    #region Metodos Unity

    public void FixedUpdate()
    {
        datos = JsonUtility.FromJson<Data>(data_system.Json);
    }


    void Awake()
    {
        datos = new Data(); 
        fa_In = false;
    }

    public void Start()
    {
        data_system.ApplicationPath = Application.dataPath + "/Jsons/";
        data_system.Json = File.ReadAllText(data_system.ApplicationPath + "Database.json");
        datos = JsonUtility.FromJson<Data>(data_system.Json);

        if (datos.Paralax)
        {
            perm = true;
        }
        else if (!datos.Paralax)
        {
            perm = false;
        }


        ParalaxImg();
    }

    void Update()
    {
        cam();
        ParalaxImg();


        if (Input.GetKeyDown(KeyCode.P) && datos.Paralax)
        {
            datos.Paralax = false;
        }
        else if (Input.GetKeyDown(KeyCode.P) && !datos.Paralax)
        {
            datos.Paralax = true;
        }
        desvanecidos();
    }


    #endregion



    #region Metodos Propios

    public void boton_cam()
    {
        if (perm)
        {
            press = true;
            perm = false;
        }
        else if (!perm)
        {
            press = true;
            perm = true;
        }
    }

    void cam()
    {
            if (perm && press)
            {
            ParalaxEna.SetActive(true);
            datos.Paralax = true;
            data_system.ApplicationPath = Application.dataPath + "/Jsons/";
            data_system.Json = JsonUtility.ToJson(datos);
            File.WriteAllText(data_system.ApplicationPath + "Database.json", data_system.Json);
            data_system.cambios=true;
            press = false;
        }
            else if (!perm && press)
            {
            ParalaxDis.SetActive(true);
            datos.Paralax = false;
            data_system.ApplicationPath = Application.dataPath + "/Jsons/";
            data_system.Json = JsonUtility.ToJson(datos);
            File.WriteAllText(data_system.ApplicationPath + "Database.json", data_system.Json);
            data_system.cambios=true;
            press = false;
        }
    }



    public void ParalaxImg()
    {
        data_system.cambios = false;
        if (datos.Paralax)
        {
            float x, y;
            x = (Input.mousePosition.x - (Screen.width / 2)) * mouseX / Screen.width;
            y = (Input.mousePosition.y - (Screen.height / 2)) * mouseY / Screen.height;
            paralaxObj.transform.position = new Vector3(x, y, -1);
        }
        else
        {
            paralaxObj.transform.position = new Vector3(0, 0, -1);
        }
    }




    public void fadeout()
    {
        Audio_System.cam_img = false;
        fa_Out = true;
        fa_In = false;

        if (Default_Image.color.a >= 0.3f && !Audio_System.cam_img)
        {
            Degradiente.a -= Time.deltaTime;
            Default_Image.color = Degradiente;
        }
        else
        {
            fa_Out = false;
            fa_In = true;
            compara_img();
        }
    }



    void compara_img()
    {
        Cancion = Audio_System.son.clip.name;
        switch (Cancion)
        {
            case "bye":
                Audio_System.cam_img = true;
                fa_Out = false;
                Default_Image.sprite = Fondos[0];
                fade();
                break;

            case "phony":
                Audio_System.cam_img = true;
                fa_Out = false;
                Default_Image.sprite = Fondos[1];
                fade();
                break;

            case "Vigin":
                Audio_System.cam_img = true;
                fa_Out = false;
                Default_Image.sprite = Fondos[2];
                fade();
                break;

            case "hero":
                Audio_System.cam_img = true;
                fa_Out = false;
                Default_Image.sprite = Fondos[3];
                fade();
                break;

            case "buts":
                Audio_System.cam_img = true;
                fa_Out = false;
                Default_Image.sprite = Fondos[4];
                fade();
                break;

            case "giri giri":
                Audio_System.cam_img = true;
                fa_Out = false;
                Default_Image.sprite = Fondos[5];
                fade();
                break;

            case "finorza":
                Audio_System.cam_img = true;
                fa_Out = false;
                Default_Image.sprite = Fondos[6];
                fade();
                break;

            case "fine":
                Audio_System.cam_img = true;
                fa_Out = false;
                Default_Image.sprite = Fondos[7];
                fade();
                break;

            case "eromanga":
                Audio_System.cam_img = true;
                fa_Out = false;
                Default_Image.sprite = Fondos[8];
                fade();
                break;
        }
    }



    void desvanecidos()
     
        {
            if (fa_In)
            {
            compara_img();
            }


            if (fa_Out)
        {
                fadeout();
            }

        }

   

    void fade()
    {
        fa_In = true;
        Audio_System.cam_img = true;
        fa_Out = false;
        if (Default_Image.color.a < 1 && Audio_System.cam_img)
        {
            Degradiente.a += Time.deltaTime;
            Default_Image.color = Degradiente;
        }

    }



    #endregion




}
