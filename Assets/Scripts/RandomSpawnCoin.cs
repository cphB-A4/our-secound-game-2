using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnCoin : MonoBehaviour
{
    // Start is called before the first frame update

public GameObject coin;
    // Update is called once per frame

    private float minTime = 2;
    private float maxTime = 5;
    private float currentTime;
    private float spawnTime;

    void Start(){
        SetRandomTime();
        currentTime = 0;
    }
    void SetRandomTime ()
     {
         spawnTime = Random.Range (minTime, maxTime);
         //Debug.Log ("Next coin spawn in " + spawnTime + " seconds.");
     }
     
    void Update()
    {
  
        //Tæller op
         currentTime += Time.deltaTime;
         //Tjekker om det skal spawnes en coin
         if (currentTime >= spawnTime) {
             SpawnCoin();
             SetRandomTime();
             currentTime = 0;
         }


     
    
    }
    void SpawnCoin (){
     Vector3 randomSpawnPoistion = new Vector3(Random.Range(5,11),1, Random.Range(5,11));
       Instantiate(coin, randomSpawnPoistion, Quaternion.identity);
    }
    

}
