using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : MonoBehaviour
{
    public GameObject xd;
    public GameObject[] xds;
    //void Start()
    //{
    //    float posx = 0;
    //    float posy = 0;
    //    Quaternion angulo = xd.transform.rotation;
    //    angulo.y = 0 ;
    //    for (int i = 0; i < 3; i++)
    //    {
    //        Instantiate(xd, new Vector3(posx, posy, 0), Quaternion.Euler(angulo.x,angulo.y,angulo.z));
    //        angulo.z += 25;
    //        posx += 0.3f;
    //        posy += 0.2f;
    //    }
    //    xds = GameObject.FindGameObjectsWithTag("Bars");
    //}

    void Update()
    {
        float[] spectrum = new float[1024];
        AudioListener.GetOutputData(spectrum, 0);
        for (int i = 0; i < 32; i++)
        {
            Vector3 prevscale = xds[i].transform.localScale;
            prevscale.y = spectrum[i] * 1.5f;
            xds[i].transform.localScale = prevscale;
        }
    }
}
