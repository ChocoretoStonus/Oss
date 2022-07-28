using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WinController : MonoBehaviour
{
    #region Variables
    [SerializeField] TextMeshProUGUI Score_Txt, HighScore_Text,_AccText;
    [SerializeField] TextMeshProUGUI _100Txt, _50Txt, _MissTxt, _300Txt,_MaxCText;
    [SerializeField] GameObject Anim_Score, Anim_HighScore,Back_To_Song;
    [SerializeField] Image Win_BG,RankImg;
    [SerializeField] AudioSource AudioSystem;
    [SerializeField] AudioClip ScoreMusic;
    [SerializeField] Sprite[] SC_HS_BG;
    [SerializeField] Sprite[] Ranks;
    [SerializeField] AudioClip[] HS;
    int GameScore, GameMiss, Game100, Game50, Game300,GameMC;
    float GameAccuracy,HighAcc;
    #endregion



    #region UnityMetodos

    void Start()
    {
        GameScore = PlayerPrefs.GetInt("GameScore");
        GameAccuracy = PlayerPrefs.GetFloat("Accuracy");
        GameMiss = PlayerPrefs.GetInt("Miss");
        Game50 = PlayerPrefs.GetInt("50");
        Game100 = PlayerPrefs.GetInt("100");
        Game300 = PlayerPrefs.GetInt("300");
        GameMC = PlayerPrefs.GetInt("ComboMax");
        HighAcc = PlayerPrefs.GetFloat("HighAcc");
        HS_or_SC();
        HAcc_or_Acc();
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
            Win_BG.sprite = SC_HS_BG[0];
            PlayerPrefs.SetInt("HighScore", GameScore);
            AsigTextScore(GameScore, HighScore_Text);
            Rank_Calculate();
            fullAcc();
            Scores();
            Anim_HighScore.SetActive(true);
        }
        //GameScore
        else
        {
            Win_BG.sprite = SC_HS_BG[1];
            AsigTextScore(GameScore, Score_Txt);
            AudioSystem.PlayOneShot(ScoreMusic);
            Rank_Calculate();
            fullAcc();
            Scores();
            Anim_Score.SetActive(true);
        }
    }

    void HAcc_or_Acc()
    {
        //HighAccuracy
        if (GameAccuracy > HighAcc)
        {
            PlayerPrefs.SetFloat("HighAcc", GameAccuracy);
            //AsigTextScore(GameScore, HighScore_Text);
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
                AudioSystem.PlayOneShot(HS[0]);
                break;

            case 1:
                //Industry Baby 

                //Debug.Log("Industry");
                AudioSystem.PlayOneShot(HS[1]);
                break;
            case 2:
                //After Dark 

                //Debug.Log("After Dark");
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

    void Rank_Calculate()
    {
        if (GameAccuracy==100)
        {
            RankImg.sprite = Ranks[0];
        }
        else if (GameAccuracy >= 97 && GameAccuracy < 100  &&GameMiss==0 && Game50==0 && Game100 <=3)
        {
            RankImg.sprite = Ranks[1];
        }
        else if (GameAccuracy >= 92 && GameAccuracy < 97 && GameMiss == 0 && Game50 ==0 && Game100 <= 4)
        {
            RankImg.sprite = Ranks[2];
        }
        else if (GameAccuracy >= 86 && GameAccuracy < 92)
        {
            RankImg.sprite = Ranks[3];
        }
        else if (GameAccuracy >= 66 && GameAccuracy < 86)
        {
            RankImg.sprite = Ranks[4];
        }
        else if (GameAccuracy < 66)
        {
            Debug.Log(GameAccuracy);
            RankImg.sprite = Ranks[5];
        }
    }

    void Scores()
    {
        _100Txt.text = ""+Game100; 
        _50Txt.text = "" + Game50;
        _MissTxt.text = "" + GameMiss;
        _300Txt.text = "" + Game300;
        _MaxCText.text = GameMC +"x";
    }


    void fullAcc()
    {

        //aqui obtengo mi accuracy en un valor redondeado para compararla
        //con el accuracy obtenido del metodo "Accuracy"
        float Int = Mathf.Round(GameAccuracy);

        float mult = Mathf.Pow(10.0f, 2);
        float OneDecimal = Mathf.Round(GameAccuracy * mult) / mult;


        if (GameAccuracy > 100)
        {
            _AccText.text = GameAccuracy + ".00%";
        }
        else if (GameAccuracy <= 0)
        {
            GameAccuracy = 0;
            _AccText.text = GameAccuracy + ".00%";
        }
        else if (GameAccuracy == Int)
        {
            _AccText.text = GameAccuracy + ".00%";
        }
        else if (GameAccuracy == OneDecimal)
        {
            _AccText.text = GameAccuracy + "0%";
        }
        else
        {
            _AccText.text = GameAccuracy + "%";
        }
    }


    #endregion

}
