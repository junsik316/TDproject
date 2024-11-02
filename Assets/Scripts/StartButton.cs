using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        LoadingSceneManager.LoadScene("MainScene");
    }
    public void endGame()
    {
        #if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;
        #else
          Application.Quit();
        #endif
    }
    public void GOmain()
    {
        LoadingSceneManager.LoadScene("TitleScene");
    }
}
