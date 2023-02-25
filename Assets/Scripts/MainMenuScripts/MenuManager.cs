using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject settingPanele;
    [SerializeField]
    private GameObject infoPanel;
    [SerializeField]
    private GameObject scorePanel;

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Play the pop animation to open the setting panel
    public void Settings() {
        settingPanele.GetComponent<Animator>().SetTrigger("pop");
    }

    //Play the pop animation to open the information panel
    public void Information() {
        infoPanel.GetComponent<Animator>().SetTrigger("pop");
    }

    //Play the amimation to show the best palyer score from score panel
    public void ShowScore() {
        scorePanel.GetComponent<Animator>().SetTrigger("ScorePop");
    }

    //To open the game developer information from his linkedIn account
    public void OpenLinkedIn() {
        Application.OpenURL("");
    }

    public void QuiteGame() {
        Application.Quit();
    }

}
