using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class SwipeMenu : MonoBehaviour
{
    [SerializeField] AudioSource AudioSystem;
    [SerializeField] AudioClip[] Music;
    //[SerializeField]Scrollbar valueScroll;
    [SerializeField] Transform posi;
    [SerializeField] Transform NamePos, ArtistPos;
    [SerializeField] float timeScroll,distanceScroll;
    [SerializeField, ReadOnly] float PosIni, PosFini;
    [SerializeField, ReadOnly] float scroll_pos = 0;
    [SerializeField, ReadOnly] float PosBaseName = 0.6f, PosBaseArtist = 0.5f, nameLimit,artistLimit;
    [SerializeField] bool Change = true, NameScroll = true, ArtistScroll=true;
    [SerializeField] TextMeshProUGUI Name, Artist,MaxAcc,Difficulty;
    [SerializeField] GameObject Exit_Prefab, To_Black;
    private float Acc;
    void Awake()
    {
        nameLimit = -106;
        //StartCoroutine(ScrollArtist(timeScroll, distanceScroll));
        NamePos.localPosition = new Vector2(40.6f, NamePos.localPosition.y);
        StartCoroutine(ScrollName(timeScroll, distanceScroll));
    }
    private void Start()
    {
        StartCoroutine("ChangePosition");
        AudioSystem.Play();
    }

    private void FixedUpdate()
    {
        scroll_pos = this.gameObject.transform.position.x;
        //scroll_pos = posi.position.x; 
    }

    void Update()
    {
        Music_Selector();
    }

    void Music_Selector()
    {
        if (scroll_pos <= 24.85851 && scroll_pos >= 16.91185)
        {
            NameScroll = false;
            ArtistScroll = false;
            NamePos.localPosition = new Vector2(0.14f, NamePos.localPosition.y);
            PosIni = 24.85851f;
            PosFini = 16.91185f;
            if (Change)
            {
                //Buts
                Name.text = "No Buts!(TV Size)";
                Artist.text = "Kaweada Mami";
                MaxAcc.text = "Max Acc: 0.00%";
                Difficulty.text = "Difficulty: 5 stars";
                AudioSystem.clip = Music[0];
                AudioSystem.Play();
            }
        }
        else if (scroll_pos <= 16.91184 && scroll_pos >= 12.27775)
        {
            NameScroll = false;
            ArtistScroll = false;
            ArtistPos.localPosition = new Vector2(0.5f, ArtistPos.localPosition.y);
            NamePos.localPosition = new Vector2(-0.64f, NamePos.localPosition.y);
            PosIni = 16.91184f;
            PosFini = 12.27775f;
            if (Change)
            {
                //Bye
                Name.text = "Good-bye sengen";
                Artist.text = "Uruha Rushia";
                MaxAcc.text = "Max Acc: 0.00%";
                Difficulty.text = "Difficulty: 5.5 stars";
                AudioSystem.clip = Music[1];
                AudioSystem.Play();
            }
        }
        else if (scroll_pos <= 12.27774 && scroll_pos >= 7.362186)
        {
            NameScroll = false;
            ArtistScroll = true;
            artistLimit = -94;
            PosBaseArtist = 94.95f;
            NamePos.localPosition = new Vector2(0.05f, NamePos.localPosition.y);
            ArtistPos.localPosition = new Vector2(0.5f, ArtistPos.localPosition.y);
            StartCoroutine(ScrollArtist(timeScroll, distanceScroll));
            PosIni = 12.27774f;
            PosFini = 7.362186f;
            if (Change)
            {
                //Fine
                Name.text = "Fine!!(Cut Ver.)";
                Artist.text = "Tomato Gummy feat. Shirakami Fubuki";
                MaxAcc.text = "Max Acc: 0.00%";
                Difficulty.text = "Difficulty: 4.8 stars";
                AudioSystem.clip = Music[2];
                AudioSystem.Play();
            }
        }
        else if (scroll_pos <= 7.362185 && scroll_pos >= 2.426518)
        {
            NameScroll = false;
            ArtistScroll = false;
            ArtistPos.localPosition = new Vector2(0.5f, ArtistPos.localPosition.y);
            NamePos.localPosition = new Vector2(-0.36f, NamePos.localPosition.y);
            PosIni = 7.362185f;
            PosFini = 2.426518f; if (Change)
            {
                //Finorza
                Name.text = "Finorza";
                Artist.text = "Camellia feat. Nanahira";
                MaxAcc.text = "Max Acc: 0.00%";
                Difficulty.text = "Difficulty: 5.2 stars";
                AudioSystem.clip = Music[3];
                AudioSystem.Play();
            }
        }
        else if (scroll_pos <= 2.4265187 && scroll_pos >= -2.478992)
        {
            NameScroll = true;
            ArtistScroll = false;
            nameLimit = -106;
            PosBaseName = 103.49f;
            Name.text = "Ikenai Bordeline (Speed Up Ver.)";
            NamePos.localPosition = new Vector2(37, NamePos.localPosition.y);
            StartCoroutine(ScrollName(timeScroll, distanceScroll));
            PosIni = 2.4265187f;
            PosFini = -2.478992f;
            if (Change)
            {
                //Giri

                Artist.text = "Walkure";
                MaxAcc.text = "Max Acc: 0.00%";
                Difficulty.text = "Difficulty: 6 stars";
                AudioSystem.clip = Music[4];
                AudioSystem.Play();
            }
        }
        else if (scroll_pos <= -2.478991 && scroll_pos >= -7.374451)
        {
            NameScroll = true;
            ArtistScroll = false;
            nameLimit = -110;
            PosBaseName = 108;
            NamePos.localPosition = new Vector2(37, NamePos.localPosition.y);
            StartCoroutine(ScrollName(timeScroll, distanceScroll));
            PosIni = -2.478991f;
            PosFini = -7.374451f;
            if (Change)
            {
                //Hero

                Name.text = "Holding out for a Hero(Retiv edit)";
                Artist.text = "Helblinde";
                MaxAcc.text = "Max Acc: 0.00%";
                Difficulty.text = "Difficulty: 5 stars";
                AudioSystem.clip = Music[5];
                AudioSystem.Play();
            }
        }
        else if (scroll_pos <= -7.374450 && scroll_pos >= -12.23975)
        {
            NameScroll = false;
            ArtistScroll = false;
            NamePos.localPosition = new Vector2(0.29f, NamePos.localPosition.y);
            PosIni = -7.374450f;
            PosFini = -12.23975f;
            if (Change)
            {
                //Eromanga
                Name.text = "Hitorigoto (TV Size)";
                Artist.text = "ClariS";
                MaxAcc.text = "Max Acc: 0.00%";
                Difficulty.text = "Difficulty: 4.8 stars";
                AudioSystem.clip = Music[6];
                AudioSystem.Play();
            }
        }
        else if (scroll_pos <= -12.23974 && scroll_pos >= -17.01458)
        {
            NameScroll = false;
            ArtistScroll = false;
            NamePos.localPosition = new Vector2(-0.65f, NamePos.localPosition.y);
            PosIni = -12.23974f;
            PosFini = -17.01458f;
            if (Change)
            {
                //Phony
                Name.text = "Phony";
                Artist.text = "Aitsuki Nakuru";
                MaxAcc.text = "Max Acc: 0.00%";
                Difficulty.text = "Difficulty: 5.7 stars";
                AudioSystem.clip = Music[7];
                AudioSystem.Play();
            }
        }
        else if (scroll_pos <= -17.01457 && scroll_pos >= -22.46748)
        {
            NameScroll = false;
            ArtistScroll = false;
            NamePos.localPosition = new Vector2(0.38f, NamePos.localPosition.y);
            PosIni = -17.01457f;
            PosFini = -22.46748f;
            if (Change)
            {
                //Vigin
                Name.text = "Virgin Sindrome";
                Artist.text = "osu! virgin gang";
                fullAcc();
                Difficulty.text = "Difficulty: 4.5 stars";
                AudioSystem.clip = Music[8];
                AudioSystem.Play();
            }
        }
    }



    void fullAcc()
    {
        Acc = PlayerPrefs.GetFloat("HighAcc");
        //aqui obtengo mi accuracy en un valor redondeado para compararla
        //con el accuracy obtenido del metodo "Accuracy"
        float Int = Mathf.Round(Acc);

        float mult = Mathf.Pow(10.0f, 2);
        float OneDecimal = Mathf.Round(Acc * mult) / mult;


        if (Acc > 100)
        {
            MaxAcc.text = Acc + ".00%";
        }
        else if (Acc <= 0)
        {
            Acc = 0;
            MaxAcc.text = Acc + ".00%";
        }
        else if (Acc == Int)
        {
            MaxAcc.text = Acc + ".00%";
        }
        else if (Acc == OneDecimal)
        {
            MaxAcc.text = Acc + "0%";
        }
        else
        {
            MaxAcc.text = Acc + "%";
        }
    }




    public void Exit()
    {
        AudioSystem.volume = 0.1f;
        Exit_Prefab.SetActive(true);
    }

    public void ReturnMenu()
    {
        To_Black.SetActive(true);
    }



    IEnumerator ScrollName(float time, float distanceAum)
    {

        while (NameScroll)
        {
        if (NamePos.localPosition.x > nameLimit)
        {
            //Debug.Log("Hola");
            //PosiName.x = PosiName.x - distanceAum;
            NamePos.localPosition = new Vector2(NamePos.localPosition.x - distanceAum, NamePos.localPosition.y);
            //PosiName = new Vector2(PosiName.x - distanceAum, 0);
            }
        if(NamePos.localPosition.x <= nameLimit)
        {
            //PosiName.x = returnPos;
            NamePos.localPosition = new Vector2(PosBaseName, NamePos.localPosition.y);
            //PosiName = new Vector2(returnPos, 0);
            }
            yield return new WaitForSeconds(time);

        }

    }


    IEnumerator ScrollArtist(float time, float distanceAum)
    {
        while (ArtistScroll)
        {
            if (ArtistPos.localPosition.x > artistLimit)
            {
                //Debug.Log("Hola");
                //PosiName.x = PosiName.x - distanceAum;
                ArtistPos.localPosition = new Vector2(ArtistPos.localPosition.x - distanceAum, ArtistPos.localPosition.y);
                //PosiName = new Vector2(PosiName.x - distanceAum, 0);
            }
            if (ArtistPos.localPosition.x <= artistLimit)
            {
                //PosiName.x = returnPos;
                ArtistPos.localPosition = new Vector2(PosBaseArtist, ArtistPos.localPosition.y);
                //PosiName = new Vector2(returnPos, 0);
            }
            yield return new WaitForSeconds(time);

        }
    }



    IEnumerator ChangePosition()
    {
        while (true)
        {
            float posiprev = scroll_pos;
            yield return new WaitForSeconds(0.1f);
            if (posiprev <= PosIni && posiprev >= PosFini) { Change = false;}
            else if (posiprev > PosIni || posiprev < PosFini) {Change = true;}
        }
    }
}
