using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float Health = 100f;

    public float Points = 0f;
    
    public GameObject Enemy;

    public GameObject Pot;

    public GameObject Coin;

    public static bool gameOver;

    public GameObject gameOverPanel;

    public void Update(){

    	float distanceForEnemy = Vector3.Distance(transform.position, Enemy.transform.position);

        float distanceForPot = Vector3.Distance(transform.position, Pot.transform.position);

        float distanceForCoin = Vector3.Distance(transform.position, Coin.transform.position);

    	if(distanceForEnemy < 2.0f){
            Debug.Log("damage");
            //gives damage to player ... To do
            Health = Health-1;
        }

        if(distanceForCoin < 1.0f){
            
            Points = Points+1;
            Debug.Log("Total points: " + Points);
        }

        if(distanceForPot < 1.0f){
            
            Health += 10;
            Debug.Log("You got a pot " + Health);

            if(Health>100){
                Health = 100;
            }
        }


        if(Health==0){
            Debug.Log("game over");
            gameOver = true;
            gameOverPanel.SetActive(true);
        }

    }
}

