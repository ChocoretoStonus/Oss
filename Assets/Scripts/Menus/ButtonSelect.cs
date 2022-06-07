using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ButtonSelect : MonoBehaviour
{
    [SerializeField] Image ImgChange;
    [SerializeField] Sprite ImgIni,ImgFini;
    private void OnMouseEnter()
    {
        ImgChange.sprite = ImgFini;
    }
    private void OnMouseExit()
    {
        ImgChange.sprite = ImgIni;
    }
}
