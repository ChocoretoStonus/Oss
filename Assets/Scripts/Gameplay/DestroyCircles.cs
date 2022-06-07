using UnityEngine;
using System.Collections;
using System.IO;

[RequireComponent(typeof(CircleCollider2D))]
public class DestroyCircles : MonoBehaviour
{
    
    #region Variables
    [SerializeField] GameObject prefab,Hit100, Hit50, HitMiss;
    GameController controller;
    Vector3 scale;
    public GameObject Child;
    #endregion



    #region Metodos de Unity


    void Awake()
    {
        GameController contObj = FindObjectOfType<GameController>();
        controller = contObj.GetComponent<GameController>();
    }


    void Update()
    {
        scale = Child.transform.localScale;
        if (controller.Hp<0)
        {
            Instantiate(HitMiss);
            Destroy(gameObject);
        }
    }


    //Deteccion del mouse de manera continua encima del HitCircle
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            Scale_Hit();
        }
    }


    #endregion



    #region Metodos Propios


    //evento para la animacion del HitCircle
    public void DestroyCircle()
    {
        controller.SFX(true);
        controller.Combo=0;
        controller.ComboText.text = controller.Combo + "x";
        controller.Miss -=5;
        controller.Cont_X++;
        controller.Hp -= 0.1f;
        AsigText();
        Instantiate(HitMiss,this.transform.position,Quaternion.identity);
        Destroy(this.gameObject);
        fullAcc();
    }


    //calcula la accuracy en base a las puntuaciones ganadas y a la 
    //accuracy actual del jugador
    float Accuracy(float acc)
    {
        if (controller.Miss == 0 && controller.Cien == 0 && controller.Cincuenta == 0) { 
            acc = 100; 
        }
        else { 
        float promedio = acc + (controller.Miss + controller.Cien + controller.Cincuenta + controller.Trescientos);
        promedio = (promedio / 4);
        //float mult = Mathf.Pow(10, 1);
        acc = Mathf.Round(promedio * 10) / 10;

        }
        return acc;
    }


    //este metodo solo es para saber si tiene el 100% de accuracy 
    void fullAcc()
    {
        
        //en esta linea se llama al otro metodo para poder calcular la accuracy 
        //y guardarla en si misma 
        controller.Accuracy = Accuracy(controller.Accuracy);

        //aqui obtengo mi accuracy en un valor redondeado para compararla
        //con el accuracy obtenido del metodo "Accuracy"
        float Int = Mathf.Round(controller.Accuracy);

        float mult = Mathf.Pow(10.0f, 2);
        float OneDecimal = Mathf.Round(controller.Accuracy * mult) / mult;


        if (controller.Accuracy > 100)
        {
            controller.Accuracy = 100;
            controller.Acc.text = controller.Accuracy + ".00%";
        }
        else if(controller.Accuracy <= 0)
        {
            controller.Accuracy = 0;
            controller.Acc.text = controller.Accuracy + ".00%";
        }
        else if (controller.Accuracy == Int)
        {
            controller.Acc.text = controller.Accuracy + ".00%";
        }
        else if (controller.Accuracy == OneDecimal)
        {
            controller.Acc.text = controller.Accuracy + "0%";
        }
        else
        {
            controller.Acc.text = controller.Accuracy + "%";
        }
    }


    //este medoto hace la comprobacion de la pulsacion en base a la altura
    void Scale_Hit()
    {
        if (scale.x <= 1.6683 && scale.x >= 1)
        {
            controller.Combo++;
            controller.ComboText.text = controller.Combo+"x";
            controller.SFX(false);
            controller.Cincuenta += 1;
            Destroy(this.gameObject);
            fullAcc();
            controller.ScorePlayer += 236;
            controller.Hp += 0.07f;
            AsigText();
            Instantiate(Hit50, this.transform.position, Quaternion.identity);
            controller.Cont_50++;
        }
        else if (scale.x < 1 && scale.x > 0.8)
        {
            controller.Combo++;
            controller.ComboText.text = controller.Combo + "x";
            controller.SFX(false);
            controller.Cien += 4;
            Destroy(this.gameObject);
            fullAcc();
            controller.ScorePlayer += 452;
            controller.Hp += 0.105f;
            AsigText();
            Instantiate(Hit100, this.transform.position, Quaternion.identity);
            controller.Cont_100++;
        }
        else if (scale.x <= 0.8 && scale.x >= 0.435)
        {
            controller.SFX(false);
            controller.Combo++;
            controller.ComboText.text = controller.Combo + "x";
            controller.Trescientos += 7;
            Destroy(this.gameObject);
            fullAcc();
            controller.Hp += 0.155f;
            controller.ScorePlayer += 935;
            AsigText();
            controller.Cont_300++;
        }
    }

    //este metodo observa cual es la puntuacion actal del personaje para determinar
    //la cantidad de ceros que debe poner a lado del puntaje
    void AsigText()
    {
        if (controller.ScorePlayer > 99999999)
        {
            controller.ScorePlayer = 99999999;
            controller.scoreText.text = "" + controller.ScorePlayer;
        }
        else if (controller.ScorePlayer <= 99999999 && controller.ScorePlayer > 9999999)
        {
            controller.scoreText.text = "" + controller.ScorePlayer;
        }
        else if (controller.ScorePlayer <= 9999999 && controller.ScorePlayer > 999999)
        {
            controller.scoreText.text = "0" + controller.ScorePlayer;
        }
        else if (controller.ScorePlayer <= 999999 && controller.ScorePlayer > 99999)
        {
            controller.scoreText.text = "00" + controller.ScorePlayer;
        }
        else if (controller.ScorePlayer <= 99999 && controller.ScorePlayer > 9999)
        {
            controller.scoreText.text = "000" + controller.ScorePlayer;
        }
        else if (controller.ScorePlayer <= 9999 && controller.ScorePlayer > 999)
        {
            controller.scoreText.text = "0000" + controller.ScorePlayer;
        }
        else if (controller.ScorePlayer <= 999 && controller.ScorePlayer > 99)
        {
            controller.scoreText.text = "00000" + controller.ScorePlayer;
        }
    }

    #endregion



}
