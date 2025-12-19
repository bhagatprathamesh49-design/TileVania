using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    
    Rigidbody2D myRigidbody;
    PlayerMovement player;

    AudioManager audioManager;
    float xSpeed;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
        audioManager = FindFirstObjectByType<AudioManager>();
        PlayShootSfx(); 
    }

   
    void Update()
    {
        myRigidbody.linearVelocity = new Vector2(xSpeed, 0f); 
         
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
        {
            audioManager.DamageSfx();
            Destroy(other.gameObject);
            
        }
        Destroy(gameObject);    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(gameObject, 1f);
    }

    void PlayShootSfx()
    {
        if(audioManager != null)
        {
            audioManager.ShootSfx();
        }
    }

    
}
