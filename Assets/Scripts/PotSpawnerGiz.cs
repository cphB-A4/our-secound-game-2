using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotSpawnerGiz : MonoBehaviour
{
    // Start is called before the first frame update

public GameObject Pot;
public Vector3 center;
    public Vector3 size;
    // Update is called once per frame

    private float minTime = 5;
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
         //Tjekker om det skal spawnes en pot
         if (currentTime >= spawnTime) {
             SpawnPot();
             SetRandomTime();
             currentTime = 0;
         }


     
    
    }
    void SpawnPot (){
    Vector3 randomSpawnPoistion = center + new Vector3(Random.Range(-size.x / 2 , size.x /2), -1, Random.Range(-size.z /2 , size.z/2));
     //Vector3 randomSpawnPoistion = new Vector3(Random.Range(5,11),0.8f, Random.Range(5,11));
       Instantiate(Pot, randomSpawnPoistion, Quaternion.identity);
    }
      void OnDrawGizmosSelected(){
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center,size);
    }
    

}
