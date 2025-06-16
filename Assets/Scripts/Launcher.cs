using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    
    [SerializeField] public float launchForce = 100f;

    private GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }

    private void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.E))
        {
            LaunchPlayer();
        }
    }

    private void LaunchPlayer()
    {
        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();

        if (playerRb != null)
        {
            
            Vector2 launchDirection = (player.transform.position - transform.position).normalized;
            playerRb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
        }
    }
}