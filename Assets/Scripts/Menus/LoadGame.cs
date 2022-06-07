using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class LoadGame : MonoBehaviour
{
    void Awake()
    {
        
    }

    void Update()
    {
        
    }
    public void GamePlay()
    {
        SceneManager.LoadScene("Game");
    }
}
