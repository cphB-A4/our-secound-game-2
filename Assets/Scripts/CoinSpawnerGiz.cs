using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerGiz : MonoBehaviour
{
    // Start is called before the first frame update

public GameObject coin;
 public Vector3 center;
    public Vector3 size;
    // Update is called once per frame

    private float minTime = 2;
    private float maxTime = 10;
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
     //Vector3 randomSpawnPoistion = new Vector3(Random.Range(5,11),1, Random.Range(5,11));
      Vector3 randomSpawnPoistion = center + new Vector3(Random.Range(-size.x / 2 , size.x /2), -0.5f, Random.Range(-size.z /2 , size.z/2));
       Instantiate(coin, randomSpawnPoistion, Quaternion.Euler(new Vector3(90,0,0)));
    }
    void OnDrawGizmosSelected(){
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center,size);
    }

}
