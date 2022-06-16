using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public PlayerControllerScript Player;
    public Text textElement;
 public void Setup(int score){
gameObject.SetActive(true);
textElement.text = "Total points: " + Player.Points.ToString();
 }

 public void RestartButton(){
SceneManager.LoadScene("testerScene");
 }
 public void ExitButton(){
SceneManager.LoadScene("ExitGame");
 }
}
