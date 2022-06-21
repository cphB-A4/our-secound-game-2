using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerScript : MonoBehaviour
{
    public float Health;

    public float Points = 0f;

    public static bool gameOver;

    [SerializeField] private GameObject gameOverUI;



   
    public void Update(){
            
        

//Når spiller rammer 0 health = game over
        if(Health <=0 ){
        
             AudioListener.pause = false;
            gameOverUI.SetActive(true);
            
        }
    }

    	public void DoDamage(float damage){
			Health = Health-damage;
		}

        public void HealPlayer(float healAmount){
            Health = Health+healAmount;
            if(Health>100){
                Health=100;
            }
            //Debug.Log("After" + Health);
        }

        	public void UpdateScore(float newPoint){
           
			Points = Points+newPoint;
		}
}

