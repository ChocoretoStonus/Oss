using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject  mbg, exit_ob,seya,play;
    [SerializeField] public bool salir_perm;
    public bool salir;
    [SerializeField] float volumen, reduc;
    [SerializeField] Animator ani;
    [SerializeField] AudioSource song;
    [SerializeField] Config Config;

    void Start()
    {
        StartCoroutine(musica());
    }

    public void Update()
    {
        exit();
        exit_comandos();
        Profile_comandos();
    }

    public void exit()
    {
        switch (salir)
        {

            case true:
                if (Input.GetKeyDown(KeyCode.Escape) && salir_perm && !Config.isOn)
                {
                    StartCoroutine(can());
                }
                break;



            case false:
                if (Input.GetKeyDown(KeyCode.Escape) && salir_perm && !Config.isOn)
                {
                    StartCoroutine(sal());
                }
                break;
        }

    }

    public void b_cancel()
    {
        StartCoroutine(can());
    }

    public void b_exit()
    {
        Destroy(play);
        StartCoroutine(adios());
    }


    void exit_comandos()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && salir_perm && !Config.isOn)
        {
            b_exit();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && salir_perm && !Config.isOn)
        {
            b_cancel();
        }

    }

    void Profile_comandos()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Config.isOn)
        {
            Config.pathFileExplorer = "";
            Config.CancelUpdate();
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.O) && !Config.isOn)
        {
            Config.isOn = true;
            Config.gameObject.SetActive(true);
        }
    }

    IEnumerator musica()
    {
        salir_perm = false;
        yield return new WaitForSeconds(3.6f);
        mbg.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        salir_perm = true;
    }
    IEnumerator sal()
    {
        exit_ob.SetActive(true);
        yield return new WaitForSeconds(.5f);
        ani.SetInteger("Com",1);
        salir = true;
    }

    IEnumerator can()
    {
        ani.SetInteger("Com",2);
        yield return new WaitForSeconds(.7f);
        ani.SetInteger("Com", 3);
        salir = false;
        exit_ob.SetActive(false);
    }

   IEnumerator adios()
    {
        volumen = song.volume;
        comparador_vol();
        Instantiate(seya);
        yield return new WaitForSeconds(3f);
        Application.Quit();
    }

    void comparador_vol()
    {
        if (volumen < 0.5f && volumen>0.20f)
        {
            reduc = 0.13f;
            volumen = song.volume-reduc;
            song.volume = volumen;
        }
        else if (volumen == 0.5f)
        {
            volumen = song.volume - reduc;
            song.volume = volumen;
        }
        else if (volumen > 0.5f)
        {
            volumen = 0.25f;
            song.volume = volumen;
        }
        else if (volumen <= 0.2f)
        {
            song.volume = volumen;
        }
    }
}
