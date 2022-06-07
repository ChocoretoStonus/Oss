using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WinController : MonoBehaviour
{
    #region Variables
    [SerializeField] TextMeshProUGUI Score_Txt, HighScore_Text;
    [SerializeField] GameObject Score, HighScore,Back_To_Song,SC;
    [SerializeField] Image Win_BG;
    [SerializeField] AudioSource AudioSystem;
    [SerializeField] AudioClip S_M;
    [SerializeField] Sprite[] SC_HS;
    [SerializeField] AudioClip[] HS;
    int GameScore;
    float GameAccuracy;
    #endregion



    #region UnityMetodos

    void Start()
    {
        GameScore = PlayerPrefs.GetInt("GameScore");
        GameAccuracy = PlayerPrefs.GetInt("Accuracy");
        HS_or_SC();
    }


    void Update()
    {
        Return_Selector();
    }


    #endregion



    #region Metodos Propios

    void HS_or_SC()
    {
        //HighScore
        if (PlayerPrefs.GetInt("GameScore") > PlayerPrefs.GetInt("HighScore") || PlayerPrefs.GetInt("HighScore") == 0)
        {
            Probability();
            PlayerPrefs.SetInt("HighScore", GameScore);
            AsigTextScore(GameScore, HighScore_Text);
            HighScore.SetActive(true);
        }
        //GameScore
        else
        {
            SC.SetActive(true);
            Win_BG.sprite = SC_HS[0];
            AsigTextScore(GameScore, Score_Txt);
            AudioSystem.PlayOneShot(S_M);
            Score.SetActive(true);
        }
    }


    void MA_or_GA()
    {
        //HighScore
        if (PlayerPrefs.GetInt("Accuracy") > PlayerPrefs.GetInt("MaxAccuracy") || PlayerPrefs.GetInt("MaxAccuracy") == 0)
        {
            PlayerPrefs.SetInt("MaxAccuracy", GameScore);
            //AsigTextScore(GameScore, HighScore_Text);
        }
        //GameScore
        else
        {
            //Win_BG.sprite = SC_HS[0];
            //AsigTextScore(GameScore, Score_Txt);
        }
        
    }




    void Probability()
    {
        int Resultado = Random.Range(0,3);
        //Debug.Log(Resultado);
        switch (Resultado)
        {
            case 0:
                //Caminando Vagando
                
                //Debug.Log("Vagando");
                Win_BG.sprite = SC_HS[1];
                AudioSystem.PlayOneShot(HS[0]);
                break;

            case 1:
                //Industry Baby 

                //Debug.Log("Industry");
                Win_BG.sprite = SC_HS[2];
                AudioSystem.PlayOneShot(HS[1]);
                break;
            case 2:
                //After Dark 

                //Debug.Log("After Dark");
                Win_BG.sprite = SC_HS[3];
                AudioSystem.PlayOneShot(HS[2]);
                break;
        }
    }



    public void Return_Selector()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back_To_Song.SetActive(true);
        }
    }



    void AsigTextScore(int Score, TextMeshProUGUI TextoScore)
    {
        if (Score > 99999999)
        {
            Score = 99999999;
            TextoScore.text = "" + Score;
        }
        else if (Score <= 99999999 && Score > 9999999)
        {
            TextoScore.text = "" + Score;
        }
        else if (Score <= 9999999 && Score > 999999)
        {
            TextoScore.text = "0" + Score;
        }
        else if (Score <= 999999 && Score > 99999)
        {
            TextoScore.text = "00" + Score;
        }
        else if (Score <= 99999 && Score > 9999)
        {
            TextoScore.text = "000" + Score;
        }
        else if (Score <= 9999 && Score > 999)
        {
            TextoScore.text = "0000" + Score;
        }
        else if (Score <= 999 && Score > 99)
        {
            TextoScore.text = "00000" + Score;
        }
        else if (Score <= 99 && Score > 9)
        {
            TextoScore.text = "000000" + Score;
        }
        else if (Score <= 9 && Score > 0)
        {
            TextoScore.text = "0000000" + Score;
        }
    }


    #endregion

}
