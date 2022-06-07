using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Buttons : MonoBehaviour
{
    [SerializeField] Animator ani;
    void Awake()
    {
        ani.SetInteger("Cambio",0);
    }

    void Update()
    {
        //Debug.Log(this.transform.position.x);
        //menor();
    }
    public void Oss_Play()
    {
        ani.SetInteger("Cambio", 1);
    }
    public void Oss_Reverse()
    {
        ani.SetInteger("Cambio", 0);
    }



}
