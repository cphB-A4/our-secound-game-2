using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerScript : MonoBehaviour
{
    public float Health;

    public float Points = 0f;
    
    public GameObject mremireh_o_desbiens;

    public GameObject Pot;

    public GameObject Coin;

    public static bool gameOver;

    public GameObject gameOverPanel;

    public GameOverScript GameOverScript;

int maxPlatform = 0;


   
    public void Update(){

    	float distanceForEnemy = Vector3.Distance(transform.position, mremireh_o_desbiens.transform.position);

        float distanceForPot = Vector3.Distance(transform.position, Pot.transform.position);

        float distanceForCoin = Vector3.Distance(transform.position, Coin.transform.position);

        //float distanceForEnemyClone = Vector3.Distance(transform.position, mremireh_o_desbiensClone.transform.position);

        //float distanceForEnemyClone = Vector3.Distance(transform.position, mremireh_o_desbiens(Clone).transform.position);

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
        if(Health <=0 ){
            Debug.Log("game over");
             Cursor.visible = true;
             Time.timeScale = 0;
           GameOverScript.Setup(maxPlatform);
        }

    }

    	public void DoDamage(float damage){
            Debug.Log("Before" + Health);
			Health = Health-damage;
            Debug.Log("After" + Health);
            if(Health < -1000.0f){
                 Time.timeScale = 0;
                 SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
		}

        public void HealPlayer(float healAmount){
            Debug.Log("Before" + Health);
            Health = Health+healAmount;
            Debug.Log("After" + Health);
        }

        	public void UpdateScore(float newPoint){
            Debug.Log("Before" + Points);
			Points = Points+newPoint;
		}
//Kan kun bruges hvis man har en rigidbody som man collider med...
     // void OnCollisionEnter(Collision obj){
       //   Debug.Log("damage");
       //if(obj.gameObject.tag == "Enemy"){
       //if(obj.gameObject.CompareTag("Enemy"))
       //Health= Health-1f;  
       //}
   //}
}

