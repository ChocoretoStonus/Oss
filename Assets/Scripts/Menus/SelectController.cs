using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectController : MonoBehaviour
{
    [SerializeField] GameObject ToBlack;
    [SerializeField] AudioSource Music;
    [SerializeField] string ScenaTP;
    void Awake()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToBlack.SetActive(true);
        }
    }
    public void ToReturn()
    {
        SceneManager.LoadScene(ScenaTP);
    }
    public void StopMusic()
    {
        Music.Stop();
    }
}
