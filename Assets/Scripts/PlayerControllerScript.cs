using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float Health = 100f;

    public float Points = 0f;
    
    public GameObject mremireh_o_desbiens;

    public GameObject Pot;

    public GameObject Coin;

    public static bool gameOver;

    public GameObject gameOverPanel;
    
    //public GameObject mremireh_o_desbiens (Clone);


    public void Update(){

    	float distanceForEnemy = Vector3.Distance(transform.position, mremireh_o_desbiens.transform.position);

        float distanceForPot = Vector3.Distance(transform.position, Pot.transform.position);

        float distanceForCoin = Vector3.Distance(transform.position, Coin.transform.position);

        //float distanceForEnemyClone = Vector3.Distance(transform.position, mremireh_o_desbiens.transform.position);

    	if(distanceForEnemy < 2.0f){
            Debug.Log("damage");
            //gives damage to player ... To do
            Health = Health-1;
        }

        if(distanceForCoin < 1.0f){
            //points til player
            Points = Points+1;
            Debug.Log("Total points: " + Points);
        }

        if(distanceForPot < 1.0f){
            //health til player
            Debug.Log("Du fik: + " + Health + " HP");
            Health += 10;
            if(Health>100){
                Health = 100;
            }
            
        }

//Når spiller rammer 0 health = game over
        if(Health==0){
            Debug.Log("game over");
            gameOver = true;
            gameOverPanel.SetActive(true);
        }

    }
}

