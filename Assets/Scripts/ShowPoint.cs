using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowPoint : MonoBehaviour

{
    public PlayerControllerScript Player;

	public Text textElement;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerControllerScript>();
       
        textElement.text = "Total points: " + Player.Points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textElement.text = "Total points: " + Player.Points.ToString();
    }
}