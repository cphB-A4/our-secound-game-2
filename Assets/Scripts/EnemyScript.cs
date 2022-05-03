using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent Mob;

    //public GameObject PlayerArmature;
    //public GameObject Player;
    //public Transform PlayerArmature;
    public Transform PlayerArmature;

    public float MobDistanceRun = 1000.0f;
    // Start is called before the first frame update
    void Start()
    {
        PlayerArmature = GameObject.FindWithTag("Player").transform;
        Mob = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, PlayerArmature.transform.position);

        //run towards player

        if(distance < MobDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - PlayerArmature.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;


            //Vector3 newPos = PlayerArmature.position;

            Mob.SetDestination(newPos);

        }

    }
}
