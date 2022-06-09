using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Data_System : MonoBehaviour
{


    #region Variables
    [SerializeField] Main_BGI IMG;
    [SerializeField] string vacio;
    [SerializeField] Image ProfileImg;
    [SerializeField] Sprite spriteUnknown;
    [SerializeField] TextMeshProUGUI NameTag;
    [HideInInspector] public string Json;
    [HideInInspector] public string ApplicationPath;
    [SerializeField] public Data clase;
    [HideInInspector] public bool cambios;
    private string pathImg;

    #endregion



    #region Metodos Unity

    void FixedUpdate()
    {
        //detecta si hay cambios, y si los hay guarda la informacion en el "Json"
        if (cambios)
        {
            LoadData();
            cambios = false;
        }
    }

    public void Awake()
    {
        clase = new Data();
        CreateJson();
    }


    public void Start()
    {
        //carga los datos desde que inicia y comprueba si hay un NameTag
        //y si no hay caraga un predeterminado
        LoadData();
        if (clase.NameTag == "")
        {
            clase.NameTag = vacio;
            NameTag.text = clase.NameTag;

            SaveData();
        }


        else
        {
            LoadProfileImg();
            NameTag.text = clase.NameTag;
        }
    }

    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    clase.NameTag = medio;
        //    texto.text = clase.NameTag;
        //    cambios = true;
        //    SaveData();
        //}
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    clase.NameTag = lleno;
        //    texto.text = clase.NameTag;
        //    cambios = true;
        //    SaveData();
        //}




    }



    #endregion



    #region Metodos de Data

    public void LoadProfileImg()
    {
        //extrae la ruta de la foto guardada y si el archivo existe y si hay una ruta guardada carga la imagen,
        //si no carga una imagen por defecto
        pathImg = clase.ProfilePhoto;
        if (pathImg != "" && File.Exists(pathImg))
        {
            byte[] image = File.ReadAllBytes(pathImg);
            Texture2D NewTexture = new Texture2D(1, 1);
            NewTexture.LoadImage(image);
            Sprite sprite = Sprite.Create(NewTexture, new Rect(0, 0, NewTexture.width, NewTexture.height), new Vector2(.5f, .5f));
            ProfileImg.sprite = sprite;
        }
        else
        {
            ProfileImg.sprite = spriteUnknown;
        }
    }



    public void SaveData()
    {
        //sube los datos de la clase publica al Archivo "Json" creado
        ApplicationPath = Application.dataPath + "/Jsons/";
        Json = JsonUtility.ToJson(clase);
        File.WriteAllText(ApplicationPath + "Database.json", Json);
    }



    public void LoadData()
    {
        //busca el archivo y descarga los datos en la clase publica (Nota: Cada script tiene una clase independiente,
        //ya que no son la misma si no que es una para cada uno a menos que se desee trabajar con scriptableObject)
        ApplicationPath = Application.dataPath + "/Jsons/";
        Json = File.ReadAllText(ApplicationPath + "Database.json");
        clase = JsonUtility.FromJson<Data>(Json);
    }



    public void CreateJson()
    {

        //para crear un archivo con la extencion
        //se necesita de un path y tu archivo con la extension que deseas hacer,
        //en este caso el .json

        //-------------------------------------------------------------------------------------------
        ApplicationPath = Application.dataPath + "/Jsons/";
        string create = ApplicationPath + "Database.json";


        if (File.Exists(ApplicationPath) && !File.Exists(create))
        {
            //si existe carpeta pero el archivo no, solo creara el json
            PlayerPrefs.DeleteKey("HighScore");

            Json = JsonUtility.ToJson(clase);
            File.WriteAllText(create, Json);
            Debug.Log("json");
            ProfileImg.sprite = spriteUnknown;
        }
        else if (!File.Exists(ApplicationPath) && !File.Exists(create))
        {
            //Si no hay carpeta ni archivo creara ambos
            PlayerPrefs.DeleteKey("HighScore");

            Directory.CreateDirectory(ApplicationPath);
            Json = JsonUtility.ToJson(clase);
            File.WriteAllText(create, Json);

            Json = JsonUtility.ToJson(clase);
            File.WriteAllText(create, Json);
            Debug.Log("json");
            ProfileImg.sprite = spriteUnknown;
        }
        else if (File.Exists(ApplicationPath) && File.Exists(create))
        {
            //si existen ambos solo cargara los datos
            LoadData();
        }


        //-------------------------------------------------------------------------------------------

        //para cuando guardes los cambios del script le creara el archivo en el path
        //que asignaste, yo use un string para poder hacerlo mas estetico y entedible
        //pero con poner la ruta en vez del "ApplicationPath" y poner Application.dataPath
        //ya con eso se asegura una creacion en la carpeta "Assets/" y si es en el Build se hara en 
        //la carpeta Data donde este el ejecutable del juego
    }



    #endregion


}