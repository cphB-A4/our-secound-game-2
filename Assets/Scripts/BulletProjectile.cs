using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {

    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    private Rigidbody bulletRigidbody;

    private void Awake() {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        float speed = 50f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<BulletTarget>() != null) {
            // Hit target
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            Debug.Log("Rammer target gameObject: " + gameObject.name);//projectile
            Debug.Log("Rammer target other: " + other.name); //zombie 
            Destroy(other.gameObject);
            Destroy(gameObject);
        } else {
            // Hit something else
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Debug.Log("Rammer ikke target: "+gameObject.name);
        }
    
    }

}