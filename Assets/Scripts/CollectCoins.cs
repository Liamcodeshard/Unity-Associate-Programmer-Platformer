using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    [Tooltip("The particles that appear after the player collects a coin.")]
    public GameObject coinParticles;

    PlayerMovement playerMovementScript;
    static int coinCounter;

    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Player")
        {
            
            playerMovementScript = other.GetComponent<PlayerMovement>();
            playerMovementScript.soundManager.PlayCoinSound();
            ScoreManager.score += 10;
            GameObject particles = Instantiate(coinParticles, transform.position, new Quaternion());
            Destroy(gameObject);
            coinCounter++;
            if (coinCounter % 10 == 0) playerMovementScript.AddHealth(10);
        }
    }
}