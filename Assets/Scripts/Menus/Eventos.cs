using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    public GameObject MB_dis, MB_ena, welcome;
    //[SerializeField] float volumen, reduc;
    public AudioSource Audio;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MB_Dis()
    {
        MB_ena.SetActive(false);

    }
    public void MB_Ena()
    {
        MB_dis.SetActive(false);
    }

    public void Welcome_des()
    {
        Destroy(welcome);
    }


    public void Oss_play()
    {
        Audio.Play();
    }
    public void Oss_stop()
    {
        Audio.Stop();
    }
    public void invisible()
    {
        Cursor.visible = false;
    }
    public void visible()
    {
        Cursor.visible = true;

    }


    public void ExitEvent()
    {
        Application.Quit();
    }



}

