using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //All the spawn points whitch birds are instantiate in
    [SerializeField]
    private Transform[] spawnPositions;
    //All the game birds
    [SerializeField]
    private GameObject[] birds;
    //Get the player information like score, level....
    [SerializeField]
    private GameObject PlayerInfo;
   
    private int birdNumber = 0;

    //The distance between to gameObject to spawn
    private float waitforSpawn;

    //The number witch point to the specific place of birds array 
    private int spawnNumber = 0;

    //The score whitch need to go in to the next level
    private int levelUpScore;

    //To limit the spawn point array 
    //It depends the level whitch player is in
    private int spawnPosNumber = 2;

    //To increase the birds speed depends on the game level
    private float speedAmount = 0;

    private PLayerInfoManager pLayerInfoManager;

    private bool startSpawn = true;
    void Start()
    {
        pLayerInfoManager = PlayerInfo.GetComponent<PLayerInfoManager>();
        StartCoroutine(StartSpawning());
        waitforSpawn = 4.0f;
        levelUpScore = 2;
    }

    //To spawn the birds in a loop time depends on the "waitforspawn" valuable
    IEnumerator StartSpawning() {
        
        yield return new WaitForSeconds(waitforSpawn);

        birdNumber = Random.Range(0, 3);
        spawnNumber = SpawnPos();

        //To instantiate every random birds in a random positions 
        GameObject bird = Instantiate(birds[birdNumber], spawnPositions[spawnNumber].position, spawnPositions[spawnNumber].rotation);
        BirdSpeed(bird.GetComponent<BirdsFly>());

        StartCoroutine(StartSpawning());
    }

    //To check that if the last random number == to the new number do again until the result is different
    private int SpawnPos() { 
        int tempSpawn;

        tempSpawn = Random.Range(0, spawnPosNumber);
        
        if (spawnNumber == tempSpawn)
            tempSpawn = SpawnPos();   
                
        return tempSpawn;
    }

    public void Update()
    {
        if (!DontSpawn()) {
            //Update to the next level
            pLayerInfoManager.PlayerLevel += 1;
            pLayerInfoManager.UpdateLevel();
            NextLevel();
        }

    }

    //When go into the next level its not hte time to spawn any new object
    //If we are in this situation it will be true
    private bool DontSpawn() {
        if (pLayerInfoManager.PlayerLevelScore != 0 && pLayerInfoManager.PlayerLevelScore % levelUpScore == 0) {
                startSpawn = false;     
        }else
            startSpawn = true;
        return startSpawn;
    }

    //When player go into the next level
    private void NextLevel() {
        //To decreas the wait time for spawn new birds
        if (waitforSpawn > 1.5f) 
            waitforSpawn *= 0.8f;
        //To increase the spawn position of the birds
        if (spawnPosNumber < spawnPositions.Length)
            spawnPosNumber++;
        levelUpScore++;
        //Set the distance to the next level to zero and then increase it by increaseing the score
        pLayerInfoManager.PlayerLevelScore = 0;
        //To increase the amount of speed
        speedAmount += 0.05f;
    }

    //To change the bird speed By increase the level
    private void BirdSpeed(BirdsFly bird) {
        bird.BirdSpeed += speedAmount;
    }
}
        
