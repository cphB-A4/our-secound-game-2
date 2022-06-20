using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ThirdPersonShooterController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;

    [SerializeField] private GameObject pauseUI;
    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject gameOverUI;
    // Start is called before the first frame update

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private Animator animator;

    public AudioClip shotClip;
    public AudioSource shotSFX;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
    }
     public AudioSource AddAudio(bool loop, bool playAwake, float vol) 
 { 
     AudioSource newAudio = gameObject.AddComponent<AudioSource>();
     //newAudio.clip = clip; 
     newAudio.loop = loop;
     newAudio.playOnAwake = playAwake;
     newAudio.volume = vol; 
     return newAudio; 
 }
    void Start()
    {
        shotSFX = AddAudio(false, false, 0.2f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        //Finds center of the screen 
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if (starterAssetsInputs.aim)
        {
            thirdPersonController.SetSensitivity(aimSensitivity);
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            //when we stop aiming set to true
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }
        if(starterAssetsInputs.shoot){
            shotSFX.clip = shotClip;
            shotSFX.Play();
            Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false; //if you click it shoots (like a pistol)
        }

        if (starterAssetsInputs.Escape){
            if(isPaused){
                DeactivateMenu();
            } else{
                ActivateMenu();
            }
           
            starterAssetsInputs.Escape = false;
        }
        if(gameOverUI.activeInHierarchy && starterAssetsInputs.Restart){

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void ActivateMenu(){
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseUI.SetActive(true);
        //Cursor.lockState = CursorLockMode.None;
        isPaused = true;
    }
    public void DeactivateMenu(){
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseUI.SetActive(false);
        isPaused = false;
        //Cursor.lockState = CursorLockMode.Locked;

    }

    //Game UI
    
}
