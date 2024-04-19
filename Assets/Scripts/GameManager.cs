using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI zombieCounterUI;
    public int zombiesRemaining = 5;

    void Start()
    {
        UpdateCountdownUI();
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ZombieKilled()
    {
        zombiesRemaining--;
        UpdateCountdownUI();
        CheckWinCondition();
    }

    void UpdateCountdownUI()
    {
        zombieCounterUI.text = $"Zombies Remaining: {zombiesRemaining}";
    }

   public void CheckWinCondition()
    {
        if (zombiesRemaining == 0)
        {
            // All enemies are killed, transition to the win scene
            SceneManager.LoadScene("GameWin"); 
        }
    }
}