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
    [HideInInspector] public bool fade_in, fade_out;
    [SerializeField] GameObject paralaxObj;
    [SerializeField] float mouseX, mouseY;
    [SerializeField] public bool access, press;
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
        fade_in = false;
    }

    public void Start()
    {
        data_system.ApplicationPath = Application.dataPath + "/Jsons/";
        data_system.Json = File.ReadAllText(data_system.ApplicationPath + "Database.json");
        datos = JsonUtility.FromJson<Data>(data_system.Json);

        if (datos.Paralax)
        {
            access = true;
        }
        else if (!datos.Paralax)
        {
            access = false;
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
        Fades();
    }


    #endregion
    


    #region Metodos Propios

    public void Botton_Paralax()
    {
        if (access)
        {
            press = true;
            access = false;
        }
        else if (!access)
        {
            press = true;
            access = true;
        }
    }

    void cam()
    {
            if (access && press)
            {
            ParalaxEna.SetActive(true);
            datos.Paralax = true;
            data_system.ApplicationPath = Application.dataPath + "/Jsons/";
            data_system.Json = JsonUtility.ToJson(datos);
            File.WriteAllText(data_system.ApplicationPath + "Database.json", data_system.Json);
            data_system.cambios=true;
            press = false;
        }
            else if (!access && press)
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




    public void Fade_Out()
    {
        Audio_System.cam_img = false;
        fade_out = true;
        fade_in = false;

        if (Default_Image.color.a >= 0.3f && !Audio_System.cam_img)
        {
            Degradiente.a -= Time.deltaTime;
            Default_Image.color = Degradiente;
        }
        else
        {
            fade_out = false;
            fade_in = true;
            Compare_img();
        }
    }



    void Compare_img()
    {
        Cancion = Audio_System.son.clip.name;
        switch (Cancion)
        {
            case "bye":
                Audio_System.cam_img = true;
                fade_out = false;
                Default_Image.sprite = Fondos[0];
                Fade_In();
                break;

            case "phony":
                Audio_System.cam_img = true;
                fade_out = false;
                Default_Image.sprite = Fondos[1];
                Fade_In();
                break;

            case "Vigin":
                Audio_System.cam_img = true;
                fade_out = false;
                Default_Image.sprite = Fondos[2];
                Fade_In();
                break;

            case "hero":
                Audio_System.cam_img = true;
                fade_out = false;
                Default_Image.sprite = Fondos[3];
                Fade_In();
                break;

            case "buts":
                Audio_System.cam_img = true;
                fade_out = false;
                Default_Image.sprite = Fondos[4];
                Fade_In();
                break;

            case "giri giri":
                Audio_System.cam_img = true;
                fade_out = false;
                Default_Image.sprite = Fondos[5];
                Fade_In();
                break;

            case "finorza":
                Audio_System.cam_img = true;
                fade_out = false;
                Default_Image.sprite = Fondos[6];
                Fade_In();
                break;

            case "fine":
                Audio_System.cam_img = true;
                fade_out = false;
                Default_Image.sprite = Fondos[7];
                Fade_In();
                break;

            case "eromanga":
                Audio_System.cam_img = true;
                fade_out = false;
                Default_Image.sprite = Fondos[8];
                Fade_In();
                break;
        }
    }



    void Fades()
    {
            if (fade_in)
            {
            Compare_img();
            }


            if (fade_out)
        {
                Fade_Out();
            }

        }

   

    void Fade_In()
    {
        fade_in = true;
        Audio_System.cam_img = true;
        fade_out = false;
        if (Default_Image.color.a < 1 && Audio_System.cam_img)
        {
            Degradiente.a += Time.deltaTime;
            Default_Image.color = Degradiente;
        }

    }



    #endregion

    
}
