using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    #region Variables
    public TextMeshProUGUI K1, K2, M1, M2,Acc,scoreText,ComboText;
    public GameObject Bo_K1, Bo_K2, Bo_M1, Bo_M2, circulo,ToBlack,ToRestar,ToWin,LoseBG,PauseBG;
    private int k1 = 1, k2 = 1, m1 = 1, m2 = 1;
    [Header("Scripts")]
    [SerializeField] Player pl;
    [SerializeField] HitCircle circles;

    [Header("Variables")]
    [SerializeField] bool record,pause = false, permiso=false, fail=false;
    [SerializeField] AudioClip[] Sounds;
    [SerializeField] AudioSource Music_Source;
    [SerializeField] AudioSource Sfx_Source;
    [HideInInspector] int MouseCompare;
    [HideInInspector] float time;
    [SerializeField] float HpTime;
    [SerializeField] Image TimeMusic,HpColor;
    [HideInInspector]public int ScorePlayer;
    [HideInInspector] public int Miss, Cien, Cincuenta, Trescientos;
    public float Hp;
    public float Accuracy=100;
    public int Cont_X, Cont_50, Cont_100, Cont_300,Combo,MaxCombo;
    #endregion


    #region Metodos Unity

    private void Awake()
    {
        //ScoreScreen scoreScreen = new ScoreScreen();
    }


    void Start()
    {
        int ReStartPref = 0;

        PlayerPrefs.SetInt("GameScore", ReStartPref);
        PlayerPrefs.SetFloat("Accuracy", ReStartPref);
        PlayerPrefs.SetInt("300", ReStartPref);
        PlayerPrefs.SetInt("100", ReStartPref);
        PlayerPrefs.SetInt("50", ReStartPref);
        PlayerPrefs.SetInt("Miss", ReStartPref);
        PlayerPrefs.SetInt("ComboMax", ReStartPref);

        Corrutinas();
    }



    #region Updates

    void Update()
    {
        if (Combo>MaxCombo) { MaxCombo = Combo; }
        HpEvaluate();
        Botones();
        //if (TimeMusic.fillAmount >= 0.97)
        //{
        //}
        if (TimeMusic.fillAmount >= 0.993) {
            permiso = true;
            PlayerPrefs.SetInt("GameScore" , ScorePlayer);
            PlayerPrefs.SetFloat("Accuracy" , Accuracy);
            PlayerPrefs.SetInt("300", Cont_300);
            PlayerPrefs.SetInt("100", Cont_100);
            PlayerPrefs.SetInt("50", Cont_50);
            PlayerPrefs.SetInt("Miss", Cont_X);
            PlayerPrefs.SetInt("ComboMax", MaxCombo);
            ToWin.SetActive(true);
            StopHp();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !pause && !permiso)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pause && !permiso)
        {
            UnPause();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            Restar();
            PlayerPrefs.SetInt("HighScore", 0);
        }

    }
     void FixedUpdate()
    {
        MouseCompare = pl.MouseCompare;
    }

    #endregion

    #endregion



    #region Bottons
    void Botones() {


        #region Boton K1
        if (!record)
        {

        if (Input.GetKeyDown(KeyCode.Z))
        {
           Bo_K1.transform.localScale = new Vector3(0.839999974f, 0.839999974f, 0.839999974f);
           K1.text = "" + (k1++);
        }
        else
        {
            Bo_K1.transform.localScale = new Vector3(1, 1, 1);
            K1.text = K1.text;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            Bo_K1.transform.localScale = new Vector3(0.839999974f, 0.839999974f, 0.839999974f);
        }

        else
        {
            Bo_K1.transform.localScale = new Vector3(1, 1, 1);
        }



        }
        #endregion


        #region Boton K2
        if (!record)
        {

            if (Input.GetKeyDown(KeyCode.X))
            {
                Bo_K2.transform.localScale = new Vector3(0.839999974f, 0.839999974f, 0.839999974f);
                K2.text = "" + (k2++);
            }

            else
            {
                Bo_K2.transform.localScale = new Vector3(1, 1, 1);
                K2.text = K2.text;
            }
            if (Input.GetKey(KeyCode.X))
            {
                Bo_K2.transform.localScale = new Vector3(0.839999974f, 0.839999974f, 0.839999974f);
            }

            else
            {
                Bo_K2.transform.localScale = new Vector3(1, 1, 1);
            }

        }

        #endregion



        #region Record
        
        if (record)
        {
            //Boton Z

            time += (Time.deltaTime + (Time.deltaTime / 3));
            //time = musica.time;
            circles.aument = time;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Bo_K1.transform.localScale = new Vector3(0.839999974f, 0.839999974f, 0.839999974f);
                circles.add();
            }
            else if(Input.GetKeyUp(KeyCode.Z))
            {
                Bo_K1.transform.localScale = new Vector3(1, 1, 1);
                circles.reinicio();
                time = circles.aument;
            }
            if (Input.GetKey(KeyCode.Z))
            {
                Bo_K1.transform.localScale = new Vector3(0.839999974f, 0.839999974f, 0.839999974f);
            }
            else
            {
                Bo_K1.transform.localScale = new Vector3(1, 1, 1);
            }



            //Boton X

            if (Input.GetKeyDown(KeyCode.X))
            {
                Bo_K2.transform.localScale = new Vector3(0.839999974f, 0.839999974f, 0.839999974f);
                circles.add();
            }

            else if (Input.GetKeyUp(KeyCode.X))
            {
                Bo_K2.transform.localScale = new Vector3(1, 1, 1);
                circles.reinicio();
                 time= circles.aument;
            }
            if (Input.GetKey(KeyCode.X))
            {
                Bo_K2.transform.localScale = new Vector3(0.839999974f, 0.839999974f, 0.839999974f);
            }

            else
            {
                Bo_K2.transform.localScale = new Vector3(1, 1, 1);
            }

        }



        #endregion
        


        #region Botones Mouse
        //if (MouseButtons==true)
        if (MouseCompare == 1)
        {
        #region Boton M1
        if (Input.GetMouseButtonDown(0))
        {
            Bo_M1.transform.localScale = new Vector3(0.839999974f, 0.839999974f, 0.839999974f);
            M1.text = "" + (m1++);
        }

        else
        {
            Bo_M1.transform.localScale = new Vector3(1, 1, 1);
            M1.text = M1.text;
        }
        if (Input.GetMouseButton(0))
        {
            Bo_M1.transform.localScale = new Vector3(0.839999974f, 0.839999974f, 0.839999974f);
        }

        else
        {
            Bo_M1.transform.localScale = new Vector3(1, 1, 1);
        }
        #endregion

        #region Boton M2
        if (Input.GetMouseButtonDown(1))
        {
            Bo_M2.transform.localScale = new Vector3(0.839999974f, 0.839999974f, 0.839999974f);
            M2.text = "" + (m2++);
        }

        else
        {
            Bo_M2.transform.localScale = new Vector3(1, 1, 1);
            M2.text = M2.text;
        }
        if (Input.GetMouseButton(1))
        {
            Bo_M2.transform.localScale = new Vector3(0.839999974f, 0.839999974f, 0.839999974f);
        }

        else
        {
            Bo_M2.transform.localScale = new Vector3(1, 1, 1);
        }
        #endregion

        }
        #endregion


    }

    #endregion



    #region MetodosPropios

    void HpEvaluate()
    {
        if (Hp > 1 )
        {
            Hp = 1;
            HpColor.fillAmount = Hp;
        }
        else
        {
            HpColor.fillAmount = Hp;
        }
        if (Hp<0 && !fail)
        {
            Fail();
        }
    }



    void Corrutinas()
    {
        StartCoroutine(circles.cuenta_atras(circulo));
        StartCoroutine("HpCorrutine");
    }

    void Pause()
    {
        DestroyCircles[] Ciculos = FindObjectsOfType<DestroyCircles>();
        for (int i = 0; i < Ciculos.Length; i++) { 
        Ciculos[i].gameObject.SetActive(false);
        }
        Music_Source.Pause();
        PauseBG.SetActive(true);
        Time.timeScale = 0;
        Sfx_Source.clip = (Sounds[2]);
        Sfx_Source.Play();
        Sfx_Source.loop = true;
        pause = true;
    }

    public void UnPause()
    {
        Sfx_Source.loop = false;
        Time.timeScale = 1;
        Music_Source.Play();
        PauseBG.SetActive(false);
        Sfx_Source.Stop();
        pause = false;
    }

    void Fail()
    {
        DestroyCircles[] Ciculos = FindObjectsOfType<DestroyCircles>();
        for (int i = 0; i < Ciculos.Length; i++)
        {
            Ciculos[i].gameObject.SetActive(false);
        }
        fail = true;
        permiso = true;
        Music_Source.Stop();
        LoseBG.SetActive(true);
        Sfx_Source.PlayOneShot(Sounds[3]);
        Time.timeScale = 0;
        Sfx_Source.clip = (Sounds[2]);
        Sfx_Source.Play();
        Sfx_Source.loop = true;
        pause = true;

    }

    public void BackToSelect()
    {
        DestroyCircles[] Ciculos = FindObjectsOfType<DestroyCircles>();
        for (int i = 0; i < Ciculos.Length; i++)
        {
            Ciculos[i].gameObject.SetActive(false);
        }
        LoseBG.SetActive(false);
        PauseBG.SetActive(false);
        Time.timeScale = 1;
        ToBlack.SetActive(true);
    }

    public void Restar()
    {
        DestroyCircles[] Ciculos = FindObjectsOfType<DestroyCircles>();
        for (int i = 0; i < Ciculos.Length; i++)
        {
            Ciculos[i].gameObject.SetActive(false);
        }
        LoseBG.SetActive(false);
        PauseBG.SetActive(false);
        Time.timeScale = 1;
        ToRestar.SetActive(true);
    }



    public void StopHp()
    {
        //Debug.Log("Parado");
        StopCoroutine("HpCorrutine");
    }

    public void SFX(bool fail)
    {
        if (fail)
        {
            Sfx_Source.PlayOneShot(Sounds[0]);
        }
        else
        {
            Sfx_Source.PlayOneShot(Sounds[1]);
        }
    }


    #endregion



    #region Corrutinas
    public IEnumerator HpCorrutine()
    {
        while (!record)
        {
            yield return new WaitForSeconds(HpTime);
            Hp -= 0.0016f;
        }
    }


    #endregion


}

#region ScoreScreen

public class ScoreScreen
{
    public double Score;
    public float Accuracy;
    public int Combo;
}



#endregion
