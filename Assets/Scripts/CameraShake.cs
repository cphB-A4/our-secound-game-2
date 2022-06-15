using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance{ get; private set;}
 private CinemachineVirtualCamera cinemachineVirtualCamera;
 private float shakeTimer;
 private float shakeTimerTotal;
 private float startingItensity;



private void Awake(){
    Instance = this;
    cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
}

 public void ShakeCamera(float itensity, float time){
     CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

     cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = itensity;
     startingItensity = itensity;
     shakeTimerTotal = time;
     shakeTimer = time;

 } 

    // Update is called once per frame
    private void Update()
    {
        if(shakeTimer > 0){
            shakeTimer -= Time.deltaTime;
           
                 CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
                 cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                 cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingItensity, 0f, (1-(shakeTimer / shakeTimerTotal))); 

        }

        
    }
}
