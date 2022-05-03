using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameobj;
    public Transform trans;

    void Start()
    {
        Instantiate(gameobj, trans.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
