using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PLayerInfoManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreNumber;
    [SerializeField]
    private TMP_Text levelNumber;
    [SerializeField]
    private TMP_Text healthNumber;

    [SerializeField]
    private GameObject FaileMenu;

    private GameManager gameManager;

    private int levelScore;
    private int score = 0;
    private int level = 1;
    private int healt = 3;
    public void Start()
    {
        gameManager = FaileMenu.GetComponent<GameManager>();
        levelScore = 0;
    }

    //Propertie for player score
    public int PlayerScore {
        get
        {
            return score;
        }

        set
        {
            score = value;
            if (PlayerPrefs.GetFloat("Score") < score)
                PlayerPrefs.SetFloat("Score", this.score);
        }
    }

    //Propertie for PlayerLevelScore : It will determine in what value player go into the next level
    public int PlayerLevelScore 
    {
        get 
        {
            return levelScore;
        }

        set 
        {
            levelScore = value;
        }
    }

    //Propertie for PlayerLevel
    public int PlayerLevel 
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    //Propertie for PlayerHealth
    public int PlayerHealth 
    {
        get
        {
            return healt;
        }

        set
        {
            healt = value;

            if (PlayerHealth == 0)
                gameManager.StopGame();
        }
    }

    public void UpdateScore() {
        scoreNumber.text = PlayerScore.ToString();
    }
   

    public void UpdateLevel() {
        levelNumber.text = PlayerLevel.ToString();
    }

    public void UpdateHealth() {
        healthNumber.text = PlayerHealth.ToString();
    }

    
}
