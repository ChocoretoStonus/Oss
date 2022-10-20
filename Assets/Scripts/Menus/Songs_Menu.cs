using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Songs_Menu : MonoBehaviour
{


    #region Variables


    [Header("Scripts")]
        [SerializeField] Config config;
        [SerializeField] Main_BGI main_bgi;
    [Header("Comparadores")]
         [SerializeField]private int numi_1;
         [SerializeField]private int numi_2;
         [SerializeField]private int numi_3;
         [SerializeField]public bool cam_img;
         [SerializeField] bool primera_vez,IsPause, AfterToPause;
         [SerializeField] float LastSong;
    [Header("Reproductor")]
        [SerializeField]public AudioSource son;
        [SerializeField] AudioClip[] otherClip;


    #endregion



    #region Medotodos de Unity 

    void Awake()
    {
        son = GetComponent<AudioSource>();
        primera_vez = true;
        IsPause = false;
        AfterToPause = false;
        awalake();
        cam_img = false;
    }

    void Update()
    {
        music_comandos();
    }


    void FixedUpdate()
    {
        main_bgi.Cancion = son.clip.name;
    }
    #endregion



    #region Botones

    public void Play_M()
    {
        //Time.timeScale = 1;
        if (IsPause)
        {
            AfterToPause = true;
            IsPause = false;
            son.UnPause();
            StartCoroutine(start());
        }
        else
        {
        son.Play();

        }
    }

    public void Pause_M()
    {
        //Time.timeScale = 0;
        LastSong = son.clip.length - son.time;
        IsPause=true;
        AfterToPause=false;
        StopAllCoroutines();
        son.Pause();
    }

    public void Next_M()
    {
        StopAllCoroutines(); 
        IsPause = false;
        AfterToPause = false;
        primera_vez = false;
        awalake();
    }

    #endregion

    
    
    #region Comandos
    void music_comandos()
    {
        if (Input.GetKeyDown(KeyCode.V) && !config.isOn)
        {
            primera_vez = false;
            Next_M();
        }

        if (Input.GetKeyDown(KeyCode.C) && !config.isOn)
        {
            Pause_M();
        }
        if (Input.GetKeyDown(KeyCode.X) && !config.isOn)
        {
            Play_M();
        }
        if (Input.GetKeyDown(KeyCode.Z) && !config.isOn)
        {
            before_song();
        }
    }
    #endregion



    #region Reproduccion de canciones

    void awalake()
    {
        comparador();
        StartCoroutine(start());
    }

    IEnumerator start()
    {
        while (true)
        {
            if (!IsPause && !AfterToPause)
            {
                son.Play();
                yield return new WaitForSeconds(son.clip.length);
                primera_vez = false;
                comparador();
            }
            else if (!IsPause && AfterToPause)
            {
                yield return new WaitForSeconds(LastSong);
                primera_vez = false;
                comparador();
            }
            else if (IsPause && !AfterToPause)
            {
                comparador();
                yield return new WaitForSeconds(son.clip.length);
                primera_vez = false;
            }
        }
    }

    

    #endregion



    #region Comparadores

    void before_song()
    {
        cam_img = true;
        main_bgi.Fade_Out();
        if (numi_3==0 && primera_vez)
        {
            if (!IsPause)
            {
                primera_vez = false;
                comparador();
            }
        }
        else
        {
            if (!IsPause)
            {
            son.clip = otherClip[numi_3];
            son.Play();
            }
        }
    }

    void comparador()
    {
            cam_img = false;
            numi_3 = numi_1;
            numi_1 = Random.Range(0, otherClip.Length);
            numi_2 = Random.Range(0, otherClip.Length);

            if (numi_1 == numi_2 && numi_3 == numi_1 || numi_1 == numi_2 && numi_3 != numi_1 || numi_1 != numi_2 && numi_3 == numi_1)
            {
                numi_3 = numi_1;
                numi_1 = Random.Range(0, otherClip.Length);
                numi_2 = Random.Range(0, otherClip.Length);
                comparador_despues();
            }
            else if (numi_1 != numi_2 && numi_3 != numi_1 )
            {
                if (!IsPause && !AfterToPause || IsPause && !AfterToPause)
                {
                    cam_img = true;
                    main_bgi.Fade_Out();
                    son.clip = otherClip[numi_1];
                    son.Play();
                }
                else
                {
                    StartCoroutine(start());
                }

            }

    }

    void comparador_despues()
    {
        cam_img = false;
        numi_3 = numi_1;
        numi_1 = Random.Range(0, otherClip.Length);
        numi_2 = Random.Range(0, otherClip.Length);
        if (numi_1 == numi_2 && numi_3 == numi_1 || numi_1 == numi_2 && numi_3 != numi_1 || numi_1 != numi_2 && numi_3 == numi_1)
        {
            numi_3 = numi_1;
            numi_1 = Random.Range(0, otherClip.Length);
            numi_2 = Random.Range(0, otherClip.Length);
            comparador_despues();
        }
        else if (numi_1 != numi_2 && numi_3 != numi_1 )
        {
            if (!IsPause && !AfterToPause || IsPause && !AfterToPause)
            {
                cam_img = true;
                main_bgi.Fade_Out();
                son.clip = otherClip[numi_1];
                son.Play();
            }
            else
            {
                StartCoroutine(start());
            }
        }
    }

    #endregion



}
