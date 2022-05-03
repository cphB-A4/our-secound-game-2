using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotAndCoinCollision : MonoBehaviour
{
    //public GameObject Player;
    public Transform PlayerArmature;
    // Start is called before the first frame update
    void Start(){
          PlayerArmature = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       float distance = Vector3.Distance(transform.position, PlayerArmature.transform.position);
       if(distance < 2.0f){
            //Debug.Log("Object collided with player");
            Destroy(gameObject);
        
                   }
            
    }
}

