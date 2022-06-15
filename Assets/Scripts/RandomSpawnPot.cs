using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPot : MonoBehaviour
{
    // Start is called before the first frame update

public GameObject Pot;
    // Update is called once per frame

    private float minTime = 10;
    private float maxTime = 50;
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
         //Tjekker om det skal spawnes en pot
         if (currentTime >= spawnTime) {
             SpawnPot();
             SetRandomTime();
             currentTime = 0;
         }


     
    
    }
    void SpawnPot (){
     Vector3 randomSpawnPoistion = new Vector3(Random.Range(5,11),0.8f, Random.Range(5,11));
       Instantiate(Pot, randomSpawnPoistion, Quaternion.identity);
    }
    

}
