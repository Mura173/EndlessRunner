using UnityEngine;
using TMPro;

public class PlayerCollector : MonoBehaviour
{
    public int coins = 0;
    public float speedIncreasePerCoin = 0.5f; // quanto aumenta a velocidade por moeda
    public TMP_Text coinText; // texto UI para mostrar a pontuação
    private player_data playerData;

    void Start()
    {
        playerData = GetComponent<player_data>();
        UpdateCoinText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            playerData.forwardSpeed += speedIncreasePerCoin; // aumenta a velocidade
            Destroy(other.gameObject); // some com a moeda
            UpdateCoinText();
        }
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Score: " + coins.ToString();
        }
    }
}
