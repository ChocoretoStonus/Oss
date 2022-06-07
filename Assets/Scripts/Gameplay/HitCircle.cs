using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Circles", menuName = "Add Notes")]
public class HitCircle : ScriptableObject
{
    [SerializeField] public List<float> captura;
    [SerializeField] public float aument, reset;
    //[SerializeField] public int contador;
    //[SerializeField] AudioSource musica;


    public void add()
    {
        captura.Add(aument);
    }

    public void reinicio()
    {
        //resetea el tiempo de aumento ;
        aument = reset;
    }


    public IEnumerator cuenta_atras(GameObject prefab)
    {
        GameController controller = FindObjectOfType<GameController>();
        GameController conti = controller.GetComponent<GameController>();
        //contador = -1;
        int IndexTime;

        for (int position = 0; position < captura.Count; position++)
        {
            IndexTime = captura.IndexOf(captura[position]);
            float NextTime = captura[position];
            yield return new WaitForSeconds(NextTime);

            prefab.transform.position = new Vector3(Random.Range(-5.18f, 4.73f), Random.Range(-3.98f, 3.73f), -0.1f);
            if (conti.Hp >=0)
            {
            Instantiate(prefab);
            }
            else
            {
                conti.StopHp();
            }
        }
    }


}
