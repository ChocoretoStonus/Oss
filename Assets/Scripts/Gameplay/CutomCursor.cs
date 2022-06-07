using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutomCursor : MonoBehaviour
{
    [SerializeField] float posZ;
    void Update()
    {
       
    }
    public void FixedUpdate()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 posi = new Vector3(pos.x,pos.y,70); ;
        transform.position = posi;
    }
}
