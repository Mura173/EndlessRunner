using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPaused = false;
    void Start()
    {
       pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){

            if (isPaused){
                ResumeGame();
            }

            PauseGame();
        }
    }

    public void PauseGame(){
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame(){
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitGame(){
        SceneManager.LoadScene(2);
    }
}
