using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StopGame() {
        //To open the stop panel
        this.gameObject.SetActive(true);
        //To stop the gane
        Time.timeScale = 0f;
    }

    public void Resume() {
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        //To load the scene whitch player is in
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
