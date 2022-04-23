using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;
    float CurrentHealth;
    public PlayerControllerScript PlayerArmature;

	private void Start(){
		PlayerArmature = FindObjectOfType<PlayerControllerScript>();
	}

	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;
		fill.color = gradient.Evaluate(1f);
	}


    public void Update(){
		SetHealth();
    }

    public void SetHealth()
	{
        CurrentHealth = PlayerArmature.Health;
		slider.value = CurrentHealth;
        
		fill.color = gradient.Evaluate(slider.normalizedValue);

	}
}
