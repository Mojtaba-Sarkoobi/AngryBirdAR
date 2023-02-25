using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMenuSetting : MonoBehaviour
{
    //Get images from the scene
    [SerializeField]
    private Image[] inGamesoundImages;
    //Get images from asset
    [SerializeField]
    private Sprite[] resourcesImages;

    public void MusicButton() {
        if (AudioListener.volume != 0) { 
             AudioListener.volume = 0;
            //To change the current image into the mute image 
            inGamesoundImages[1].sprite = resourcesImages[2];
        }
           
        else {
            AudioListener.volume = 1;
            //To change the current image into the unmute image 
            inGamesoundImages[1].sprite = resourcesImages[1];
        }
    }

    //If the game has another sound for shoot or spawn birds it will mute or unmute them
    //But there is no any sound for this game until now!!!
    public void SoundButton() {
        inGamesoundImages[0].sprite = resourcesImages[2];
    }

   
}
