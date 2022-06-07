using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetAni : MonoBehaviour
{
    //Variables
    public MainController main;
    public GameObject ani, prefab,musica;

    //Transicion con mouse activado

    public void Start()
    {
    }

    


    #region Eventos

    public void detener()
    {
        Destroy(prefab);

    }

    public void prefab_ini()
    {
        Instantiate(prefab);
    }

    public void invisible()
    {
        Cursor.visible = false;
    }
    public void visible()
    {
        Cursor.visible = true;
        main.salir_perm = true;
    }
    public void IniCancion()
    {
        musica.SetActive(true);
    }



    #endregion
}
