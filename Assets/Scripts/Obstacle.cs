using UnityEngine;

public class Obstacle : MonoBehaviour
{
    player_data playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<player_data>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player"){
            //Kill the player
            playerMovement.Die();
        }        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
