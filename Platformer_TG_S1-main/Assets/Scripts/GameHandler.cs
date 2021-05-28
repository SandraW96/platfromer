using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameHandler : MonoBehaviour
{
	public GameObject RestartMenuPanel;
	public GameObject Player;
	public static float GameSpeed;
    public int Maxvalue = 2000;

    int score=0;
    bool gameOver = false;

    public static bool slowTime;
    public static bool immortalityBonus;

    public float slowTimeDelay;
    float timeFromSlow;
    public float immortalityDelay;
    float timeFromImmortality;


    public GameObject[] healthPointsArray;
    public static bool healthGained;

    public static bool trapTriggered;

    private int healthPoints = 3;

    public void HealthGained()
    {
        if (healthPoints < 3)
        {
            healthPoints++;
        }
        if (healthPoints == 3)
            {
                healthPointsArray[2].SetActive(true);
            }

        if (healthPoints == 2)
            {
                healthPointsArray[1].SetActive(true);
            }
        
        healthGained = false;


    }

    public void TrapTriggered()
    {
        healthPoints--;
        if(healthPoints == 2)
        {
            healthPointsArray[2].SetActive(false);
        }
        if (healthPoints == 1)
        {
            healthPointsArray[1].SetActive(false);
        }
        if (healthPoints == 0)
        {
            healthPointsArray[0].SetActive(false);
            gameOver = true;
            Player.SetActive(false);
        }
        trapTriggered = false;
    }

    public void SlowTimeActivated()
    {
        GameSpeed = 2;
        if (timeFromSlow >= slowTimeDelay)
        {
            slowTime = false;
            GameSpeed = 4;
            timeFromSlow = 0;
        }
        timeFromSlow += Time.deltaTime;
    }

    public void ImmortalityActivated()
    {
        if (timeFromImmortality >= immortalityDelay)
        {
            immortalityBonus = false;
            timeFromImmortality = 0;
        }
        timeFromImmortality += Time.deltaTime;
    }

	// Start is called before the first frame update
	void Start()
    {
		RestartMenuPanel.gameObject.SetActive(false);
		GameSpeed = 4;

        healthGained = false;
        trapTriggered = false;
        slowTime = false;
        immortalityBonus = false;
	}
        

    // Update is called once per frame
    void Update()
    {
        score++;
        //Debug.Log(score);
        if (score==Maxvalue)
        {
            gameOver = true;
        }
        if (gameOver)
        {
            RestartMenuPanel.gameObject.SetActive(true);
            Player.gameObject.SetActive(false);
        }
        if (trapTriggered)
        {
            if (!immortalityBonus)
            {
                TrapTriggered();
            }
        }
        if (healthGained)
        {
            HealthGained();
        }
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitButtonClick()
    {
        Application.Quit();
    }
   
}
