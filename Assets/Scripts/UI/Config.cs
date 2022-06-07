using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using SimpleFileBrowser;
using System.Collections;
using UnityEngine.SceneManagement;

public class Config : MonoBehaviour
{

    #region Variables
    [SerializeField] Image ChangeImg, ProfileImg;
    [SerializeField] Sprite spriteUnknown;
    [SerializeField] GameObject ToBlack;
    //[SerializeField] Slider Darkness;
    [SerializeField] TextMeshProUGUI ChangeName,UserName,Placeholder;
    [SerializeField]Data_System data_System;
    [HideInInspector] public bool isOn;
    [HideInInspector] public string pathImg, pathFileExplorer;
    [SerializeField]byte FirstTime;
    //[SerializeField]byte FirstTimeText;
    //[SerializeField]string pruebas;
    Sprite sprite;
    Data data;
    int porcentaje;


    #endregion



    #region Metodos Unity

    private void Awake()
    {
        //Crea el lugar donde se actualizaran los datos en tiempo real
        data = new Data();

    }
    private void Start()
    {
        //Descarga los datos guardados al iniciarse y despues los carga esos datos
        //en la clase que defini en el "Awake"

        data_System.ApplicationPath = Application.dataPath + "/Jsons/";
        data_System.Json = File.ReadAllText(data_System.ApplicationPath + "Database.json");
        data = JsonUtility.FromJson<Data>(data_System.Json);
        pathImg = data.ProfilePhoto;
        FirstTime = 0;

        LoadProfile();
    }
    private void FixedUpdate()
    {
        //Esta en constante descarga de datos esto con el fin de estar al pendiente
        //si se llega a guardar algo en el json para en tiempo real cargarlo
        data = JsonUtility.FromJson<Data>(data_System.Json);
    }

    private void Update()
    {
    }

    #endregion



    #region Mis Metodos



    #region FileExplorer


    [ContextMenu("Load Image")]
    public void UploadProfile()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png",".jpeg"), new FileBrowser.Filter("Text Files", ".txt", ".pdf"));
        FileBrowser.SetDefaultFilter(".jpg");
        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);
        // Show a select folder dialog 
        StartCoroutine(ShowLoadDialogCoroutine());
    }

    IEnumerator ShowLoadDialogCoroutine()
    {
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, true, null, null, "Load Files and Folders", "Load");
       if (FileBrowser.Success)
        {
            // Print paths of the selected files (FileBrowser.Result) (null, if FileBrowser.Success is false)
            for (int i = 0; i < FileBrowser.Result.Length; i++)
            //Debug.Log(FileBrowser.Result[i]);
            pathFileExplorer = FileBrowser.Result[i];
            byte[] image = File.ReadAllBytes(pathFileExplorer);
            Texture2D NewTexture = new Texture2D(1, 1);
            NewTexture.LoadImage(image);
            sprite = Sprite.Create(NewTexture, new Rect(0, 0, NewTexture.width, NewTexture.height), new Vector2(.5f, .5f));
            ChangeImg.sprite = sprite;

        }

    }



    #endregion



    #region Sistemas de Carga y Guardado


    [ContextMenu("Save data")]
    public void SaveProfile(){
        //carga en el perfil del usuario
        ProfileImg.sprite = sprite;
        UserName.text = ChangeName.text;
        

        //Guardado Json
        data.NameTag = ChangeName.text;
        data.ProfilePhoto = pathFileExplorer;
        //data.Opacity = Darkness.value;
        SaveData();
        this.gameObject.SetActive(false);
        isOn =false;
    }


    public void LoadProfile()
    {
        isOn = true;
        this.gameObject.SetActive(true);
        //extrae la ruta guardada en el Json y si la ruta existe y esta llena la variable
        //carga la imagen de lo contrario cargara una predefinida
        pathImg = data.ProfilePhoto;
        if (pathImg != "" && File.Exists(pathImg))
        {
            byte[] image = File.ReadAllBytes(pathImg);
            Texture2D NewTexture = new Texture2D(1, 1);
            NewTexture.LoadImage(image);
            sprite = Sprite.Create(NewTexture, new Rect(0, 0, NewTexture.width, NewTexture.height), new Vector2(.5f, .5f));
            ChangeImg.sprite = sprite;
            Placeholder.text = data.NameTag;
        }
        else if (pathImg != "" && !File.Exists(pathImg))
        {
            ChangeImg.sprite = spriteUnknown;
            ChangeName.text = UserName.text;
        }
        else if (pathImg == "")
        {
            ChangeImg.sprite = spriteUnknown;
            ChangeName.text = UserName.text;
        }
    }


    public void CancelUpdate()
    {
        pathImg = data.ProfilePhoto;

        if (pathFileExplorer == "" && FirstTime == 1)
        {
            if (pathFileExplorer == "" && ChangeName.text == UserName.text )
            {
                ChangeName.text = UserName.text;
                ChangeImg.sprite = ProfileImg.sprite;
                this.gameObject.SetActive(false);
                isOn = false;
                FileBrowser.HideDialog();
            }
            else if (ChangeName.text != UserName.text && ChangeName.text.Length <= 3)
            {
                this.gameObject.SetActive(false);
                FileBrowser.HideDialog();
                isOn = false;
            }
            else
            {
                UserName.text = ChangeName.text;
                data.NameTag = ChangeName.text;
                SaveData();
                this.gameObject.SetActive(false);
                FileBrowser.HideDialog();
                isOn = false;
            }

        }
        else if (pathFileExplorer == "" && FirstTime <= 0)
        {
            if (pathFileExplorer == "" && ChangeName.text == UserName.text)
            {
                FirstTime = 1;
                ChangeName.text = UserName.text;
                ChangeImg.sprite = ProfileImg.sprite;
                this.gameObject.SetActive(false);
                isOn = false;
                FileBrowser.HideDialog();
            }
            else if (ChangeName.text != UserName.text && ChangeName.text.Length <= 3)
            {
                this.gameObject.SetActive(false);
                FileBrowser.HideDialog();
                isOn = false;
            }
            else
            {
                FirstTime = 1;
                UserName.text = ChangeName.text;
                data.NameTag = ChangeName.text;
                SaveData();
                this.gameObject.SetActive(false);
                FileBrowser.HideDialog();
                isOn = false;

            }
        }
        else if (pathFileExplorer != "" && FirstTime == 1) {
            
            if (pathFileExplorer != "" && ChangeName.text == UserName.text && ChangeName.text.Length >= 3  || pathFileExplorer != "" && ChangeName.text.Length <= 3)
            {
                    ProfileImg.sprite = sprite;
                    data.NameTag = UserName.text;
                    data.ProfilePhoto = pathFileExplorer;
                    SaveData();
                    this.gameObject.SetActive(false);
                    isOn = false;
            }
            else if (pathFileExplorer != "" && ChangeName.text != UserName.text && ChangeName.text.Length >= 3)
            {
                SaveProfile();
            }
        }
        else if (pathFileExplorer != "" && FirstTime == 0) {
            if (pathFileExplorer != "" && ChangeName.text.Length <= 3 || pathFileExplorer != "" && ChangeName.text.Length <= 3)
            {
                FirstTime = 1;
                ProfileImg.sprite = sprite;
                data.NameTag = UserName.text;
                data.ProfilePhoto = pathFileExplorer;
                SaveData();
                this.gameObject.SetActive(false);
                isOn = false;
            }
            else if (pathFileExplorer != "" && ChangeName.text != UserName.text && ChangeName.text.Length >= 3)
            {
                FirstTime = 1;
                SaveProfile();
            }
        }

    }


    void SaveData()
    {
        data_System.ApplicationPath = Application.dataPath + "/Jsons/";
        data_System.Json = JsonUtility.ToJson(data);
        File.WriteAllText(data_System.ApplicationPath + "Database.json", data_System.Json);
        data_System.cambios = true;
    }



    #endregion


    public void Game()
    {
        ToBlack.SetActive(true);
    }



    #endregion



}
