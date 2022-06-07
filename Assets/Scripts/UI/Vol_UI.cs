using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Vol_UI : MonoBehaviour
{

    #region Variables


    [Header("ETC")]
        [SerializeField] Config config;
        [SerializeField] MainController mainconter;
        [SerializeField] TextMeshProUGUI porcent;
        [SerializeField] AudioMixer mixer_gen;


    [Header("Objetos")]
        [SerializeField] Image vol_gen;
        [SerializeField] GameObject vol_max;
        [SerializeField] GameObject master;


    [Header("Variables")]
        [SerializeField] bool perm;
        [SerializeField] bool activo;
        [SerializeField] int porcent_scroll;
        [SerializeField] float min;
        [SerializeField] float max;
        [SerializeField] float aumento;
        [SerializeField] float fillamout;
        [SerializeField] float scroll_;


    const string Mixer_General = "General_Volume";


    #endregion



    #region Metodos de Unity

    void Awake()
    {
        vol_gen.fillAmount = PlayerPrefs.GetFloat("Volumen_Save");
        StartCoroutine(inicio());
    }

    void Update()
    {
        if (vol_gen.fillAmount ==1)
        {
            vol_max.SetActive(true);
        }
        else
        {
            vol_max.SetActive(false);
        }
        aumento_img();
        redondeo();
    }


    #endregion



    #region Metodos propios

    void aumento_img()
    {
        if (perm && !mainconter.salir && !config.isOn)
        {
            if (Input.mouseScrollDelta.y < 0 )
            {
                StopAllCoroutines();
                master.SetActive(true);
                activo = true;

                if (vol_gen.fillAmount > 0 && vol_gen.fillAmount < 1)
                {
                    vol_gen.fillAmount -= aumento;
                    fillamout = Mathf.Log10(vol_gen.fillAmount) * 20;
                    mixer_gen.SetFloat(Mixer_General, fillamout);
                    activo = false;
                    StartCoroutine(scroll());
                }
                else if (vol_gen.fillAmount == 1)
                {
                    activo = true;
                    vol_gen.fillAmount -= aumento;
                    fillamout = Mathf.Log10(vol_gen.fillAmount) * 20;
                    mixer_gen.SetFloat(Mixer_General, fillamout);
                    activo = false;
                    StartCoroutine(scroll());
                }

            }
            else if (Input.mouseScrollDelta.y > 0)
            {
                StopAllCoroutines();
                master.SetActive(true);

                if (vol_gen.fillAmount == 1)
                {
                    vol_gen.fillAmount = max;
                    mixer_gen.SetFloat(Mixer_General, vol_gen.fillAmount);
                    activo = false;
                    StartCoroutine(scroll());
                }
                else if (vol_gen.fillAmount > 0 && vol_gen.fillAmount < 1)
                {
                    vol_gen.fillAmount += aumento;
                    fillamout = Mathf.Log10(vol_gen.fillAmount) * 20;
                    mixer_gen.SetFloat(Mixer_General, fillamout);
                    activo = false;
                    StartCoroutine(scroll());

                }

            }

        }

        if (vol_gen.fillAmount == 0)
        {
            activo = true;
            vol_gen.fillAmount = min;
            fillamout = Mathf.Log10(vol_gen.fillAmount) * 20;
            mixer_gen.SetFloat(Mixer_General, fillamout);
            activo = false;
        }
    }



    void redondeo()
    {
        scroll_ = vol_gen.fillAmount *100;
        porcent_scroll = Mathf.RoundToInt(scroll_);
        porcent.text = porcent_scroll + "%";
        PlayerPrefs.SetFloat("Volumen_Save", vol_gen.fillAmount);
    }


    #endregion



    #region Corrutinas


    IEnumerator inicio()
    {
        perm = false;
        yield return new WaitForSeconds(3.6f);
        perm = true;
        fillamout = Mathf.Log10(vol_gen.fillAmount) * 20;
        mixer_gen.SetFloat(Mixer_General, fillamout);
        yield return null;
    }
    IEnumerator scroll()
    {
        yield return new WaitForSeconds(1);
        master.SetActive(false);
        yield return null;
        StopAllCoroutines();
    }


    #endregion



}

