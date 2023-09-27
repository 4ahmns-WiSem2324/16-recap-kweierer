using System.Collections;
using UnityEngine;
using TMPro;

public class KnobelKlacks : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI resultText;

    private int currentNumber;
    private int highscore;
    private bool gameActive;

    private float timeBetweenNumbers = 3.0f;
    private float timeLeftForNumber;

    private void Start()
    {
        StartNewLevel();
    }

    private void Update()
    {
        if (gameActive)
        {
            timeLeftForNumber -= Time.deltaTime;

            if (Input.GetKeyDown(currentNumber.ToString()))
            {
                // Correct number pressed
                highscore++;
                StartNewLevel();
            }
            else if (timeLeftForNumber <= 0 || !IsValidInput())
            {
                // Time's up or wrong key pressed, player lost
                gameActive = false;
                resultText.text = "Highscore: " + highscore + "\nYou Lost! Press '1' to Restart.";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Restart the game
            highscore = 0;
            StartNewLevel();
        }
    }

    private void StartNewLevel()
    {
        currentNumber = Random.Range(1, 7);
        numberText.text = currentNumber.ToString();
        resultText.text = "Game is running";
        timeLeftForNumber = timeBetweenNumbers;
        gameActive = true;
    }

    private bool IsValidInput()
    {
        for (int i = 1; i <= 6; i++)
        {
            if (Input.GetKeyDown(i.ToString()) && i != currentNumber)
            {
                return false;
            }
        }
        return true;
    }
}
