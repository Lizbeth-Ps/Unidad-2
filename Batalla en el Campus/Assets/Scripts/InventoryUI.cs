using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText;
    private TextMeshProUGUI scoreText;

    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();
        scoreText = GetComponent<TextMeshProUGUI>();

    }

    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        diamondText.text = "Diamantes: " + playerInventory.NumberOdDiamonds.ToString();
    }

    public void UpdateScoreText(int playerScore)
    {
        scoreText.text = "Puntaje: " + playerScore.ToString();
    }
}
