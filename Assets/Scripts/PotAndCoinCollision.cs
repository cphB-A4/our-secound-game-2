using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotAndCoinCollision : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
       float distance = Vector3.Distance(transform.position, Player.transform.position);
       if(distance < 2.0f){
            Debug.Log("Object collided with player");
            gameObject.SetActive(false);
                   }
            
    }
}

