using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScore : MonoBehaviour
{
    //Text ui to show the player score
    [SerializeField]
    private GameObject PlayerScore;

    private TMP_Text bestScore;

    void Start()
    {
        bestScore = PlayerScore.GetComponent<TMP_Text>();
    }

    //To get the score whitch is save in memory
    public void BestPlayerScore() {
        bestScore.text = PlayerPrefs.GetFloat("Score").ToString();
    }


    
}
