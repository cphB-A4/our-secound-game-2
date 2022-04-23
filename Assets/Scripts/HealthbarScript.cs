// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour
// {

// 	public int maxHealth = 100;
// 	public int currentHealth;

// 	public HealthBar healthBar;

//     // Start is called before the first frame update
//     void Start()
//     {
// 		currentHealth = maxHealth;
// 		healthBar.SetMaxHealth(maxHealth);
//     }

//     // Update is called once per frame
//     void Update()
//     {
// 		if (Input.GetKeyDown(KeyCode.Space))
// 		{
// 			TakeDamage(20);
// 		}
//     }

// 	void TakeDamage(int damage)
// 	{
// 		currentHealth -= damage;

// 		healthBar.SetHealth(currentHealth);
// 	}
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbarscript : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100;
    PlayerControllerScript Player;

    private void Start()
    {
    HealthBar =  GetComponent<Image>();
    Player = FindObjectOfType<PlayerControllerScript>();
    }

    private void Update()
    {
    	CurrentHealth = Player.Health;
    	HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}