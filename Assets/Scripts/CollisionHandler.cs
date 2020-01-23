using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay = 1f;
    [SerializeField] private GameObject deathFx; 

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence(); 
    }

    private void StartDeathSequence()
    {
        //GetComponent<Rigidbody>().isKinematic = false;
        print("player dying");
        SendMessage("OnPlayerDeath");
        GameObject explosion = GameObject.Find("Explosion");
        deathFx.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
        
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1); 
    }
}
