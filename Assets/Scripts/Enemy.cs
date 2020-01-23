using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform parent; 
    [SerializeField] private GameObject deathFX;
    [SerializeField] private int hitPoints = 1;
    [SerializeField] private int scorePoints = 12; 
    private Scoreboard scoreBoard; 


    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        hitPoints -= 1; 
        if (hitPoints < 1)
        {
            OnEnemyDestroyed(); 
        }
       
    }

    private void OnEnemyDestroyed()
    {
        scoreBoard.ScoreHit(scorePoints); 
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent; 
        Destroy(gameObject);
    }
}
