using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    
    #region Variables
    [Header ("Cursor")]
    public Texture2D[] ima;
    public GameObject  MB_ena, MB_dis;
    //private bool MouseButtons=true;
     public int MouseCompare;

    #endregion



    #region Metodos Unity
    void Start()
    {
        MouseCompare = PlayerPrefs.GetInt("F10Boton");
        Cursor.lockState = CursorLockMode.Confined;
    }


    #region Updates

    void Update()
    {
        Cursor.visible = true;
        Botones();
    }
     void FixedUpdate()
    {
        Cursor.SetCursor(ima[0], new Vector2(50, 50), CursorMode.Auto);
    }

    #endregion

    #endregion



    #region Bottons
    void Botones() {
        

        #region Boton F10
        if (Input.GetKeyDown(KeyCode.F10) && MouseCompare==1)
        {
            //Botones apagados
            MB_dis.SetActive(true);
            MouseCompare = 0;
            PlayerPrefs.SetInt("F10Boton", MouseCompare);
        }
        else if (Input.GetKeyDown(KeyCode.F10) && MouseCompare==0)
        {
            //Botones prendidos
            MB_ena.SetActive(true);
            MouseCompare = 1;
            PlayerPrefs.SetInt("F10Boton", MouseCompare);

        }
        #endregion


    }

    #endregion



    #region Corrutinas
    IEnumerator cursor()
    {
        while (true)
        {
        }
    }


    #endregion


}
