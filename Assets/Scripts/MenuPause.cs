using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ResumeGame(){
        //definir a lógica para quando for voltar pro jogo

        SceneManager.LoadScene(1);
    }

    public void ExitGame(){
        SceneManager.LoadScene(2);
    }
}
