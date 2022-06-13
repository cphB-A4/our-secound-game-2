using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieSpawner : MonoBehaviour
{
    public GameObject mremireh_o_desbiens;
    // Start is called before the first frame update

    // Update is called once per frame
    /*void Update(){
           if(mremireh_o_desbiens == SetActive(false) ){
                Vector3 randomSpawnPoistion = new Vector3(Random.Range(11,5),1, Random.Range(11,5));
     //Quaternion spawnRotation = Quaternion.Euler(90,0,0);
       Instantiate(mremireh_o_desbiens, randomSpawnPoistion, Quaternion.identity);

        }
        
    }*/

    private float minTime = 5;
    private float maxTime = 15;
    private float currentTime;
    private float spawnTime;

    void Start(){
        SetRandomTime();
        currentTime = 0;
    }
    void SetRandomTime ()
     {
         spawnTime = Random.Range (minTime, maxTime);
         //Debug.Log ("Next zombie spawn in " + spawnTime + " seconds.");
     }
     
    void Update() {
        //Tæller op
         currentTime += Time.deltaTime;
         //Tjekker om det skal spawnes en zombie
         if (currentTime >= spawnTime) {
             SpawnZombie();
             SetRandomTime();
             currentTime = 0;
         }
         //var test = GameObject.Find("mremireh_o_desbiens");
         //if(test) test.SetActive(true);
             
         }

     

    void SpawnZombie (){
     Vector3 randomSpawnPoistion = new Vector3(Random.Range(11,5),1, Random.Range(11,5));
       Instantiate(mremireh_o_desbiens, randomSpawnPoistion, Quaternion.identity);
    }

}
     
