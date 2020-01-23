using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; 

public class PlayerController : MonoBehaviour
{
    //Translation. 
    [Header("Translation")]
    [Tooltip("In ms^-1")] [SerializeField] private float xSpeed = 50f;
    [Tooltip("In m")] [SerializeField] private float xRange = 25f;
    [Tooltip("In ms^-1")] [SerializeField] private float ySpeed = 50f;
    [Tooltip("In m")] [SerializeField] private float yMinRange = -14f; 
    [Tooltip("In m")] [SerializeField] private float yMaxRange = 20f;
    //Pitch
    [Header("Pitch")]
    [SerializeField] private float positionPitchFactor = -1.2f;
    [SerializeField] private float controlPitchFactor = -30f;
    float xThrow, yThrow;
    //Yaw
    [Header("Yaw")]
    [SerializeField] private float positionYawFactor = 1f;
    [SerializeField] private float controlYawFactor = 20f;
    //Roll
    [Header("Roll")]
    [SerializeField] private float controlRollFactor = -20f;
    private bool isControlsEnabled = true; 

    void Update()
    {
        if (isControlsEnabled)
        {
            Translation();
            Rotation();
        }
    }

    private void Translation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        //print(yThrow); 
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        //print(yOffset); 
        float newXPosition = transform.localPosition.x + xOffset;
        float newYPosition = transform.localPosition.y + yOffset;
        //print(newYPosition); 
        float clampedXPos = Mathf.Clamp(newXPosition, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(newYPosition, yMinRange, yMaxRange);
        //print(clampedYPos); 
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void Rotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDueToControlThrow = xThrow * controlYawFactor; 
        float yaw = yawDueToPosition + yawDueToControlThrow;

        float roll = xThrow * controlRollFactor; 
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); 
    }

    void OnPlayerDeath()
    {
        print("freeze the controls");
        isControlsEnabled = false; 
    }
}
