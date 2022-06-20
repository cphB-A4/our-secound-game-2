using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other){
        Debug.Log("teleport");
        player.transform.position = teleportTarget.transform.position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
