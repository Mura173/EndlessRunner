using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTest : MonoBehaviour
{
    public float speed;
    bool alive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void FeixedUpdate()
    {
        if (!alive) return;

        // Movimenta��o
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
    }

    public void Die()
    {
        alive = false;
        //Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
