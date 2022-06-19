using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawner : MonoBehaviour
{
    public GameObject ZombiePrefab;
    public Vector3 center;
    public Vector3 size;

    private float minTime = 5;
    private float maxTime = 15;
    private float currentTime;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
       SetRandomTime();
        currentTime = 0;
    }
    void SetRandomTime ()
     {
         spawnTime = Random.Range (minTime, maxTime);
         //Debug.Log ("Next zombie spawn in " + spawnTime + " seconds.");
     }


    // Update is called once per frame
    void Update() {
        //Tæller op
         currentTime += Time.deltaTime;
         //Tjekker om det skal spawnes en zombie
         if (currentTime >= spawnTime) {
             SpawnZombies();
             SetRandomTime();
             currentTime = 0;
         }
    }

    public void SpawnZombies(){
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2 , size.x /2), Random.Range(-size.y /2 , size.y/2));
        Instantiate(ZombiePrefab, pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center,size);
    }
}
