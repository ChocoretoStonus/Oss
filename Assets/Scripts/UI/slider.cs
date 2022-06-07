using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class slider : MonoBehaviour
{
    [SerializeField] AudioSource audio;

    // Use this for initialization
    public Image TimeLine;
    // Flag to know if we are draging the Timeline handle
    private bool TimeLineOnDrag = false;

    void Update()
    {

        if (TimeLineOnDrag)
        {
            audio.timeSamples = (int)(audio.clip.samples * TimeLine.fillAmount);

        }


        else {
            TimeLine.fillAmount = (float)audio.timeSamples / (float)audio.clip.samples;
            
        }
    }
 
 
 
 
 // Called by the event trigger when the drag begin
 public void TimeLineOnBeginDrag()
{

    TimeLineOnDrag = true;

    audio.Pause();


}


// Called at the end of the drag of the TimeLine
public void TimeLineOnEndDrag()
{

    audio.Play();

    TimeLineOnDrag = false;
}



}