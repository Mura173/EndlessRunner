using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinal : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayAgain(){
        SceneManager.LoadScene(1);
    }

    public void ExitGame(){
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
