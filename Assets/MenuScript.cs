using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class MenuScript : MonoBehaviour
{
    private StarterAssetsInputs starterAssets;
    //private StarterAssets starterAssets;
    //private InputAction menu;
    private bool menu;

    [SerializeField] private GameObject pauseUI;
    [SerializeField] private bool isPaused;
    // Start is called before the first frame update
    void Awake()
    {
          starterAssets = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (starterAssets.Escape)
        {
            Debug.Log("t trykket");
            //  menu = starterAssets.Escape;
            //menu.Enable();
            // menu.performed += Pause;
            Pause2();
        }
    }

    private void OnEnable()
    {
       
       
        
    }
    private void OnDisable()
    {
         //menu.Disable();

    }

    void Pause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;
        if(isPaused){
           ActivateMenu();
        } else {
          DeactivateMenu();
        }
    }

    void Pause2()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }
    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseUI.SetActive(true);
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseUI.SetActive(false);
        isPaused = false;

    }
}
