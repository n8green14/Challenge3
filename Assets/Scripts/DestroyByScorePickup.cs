using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByScorePickup : MonoBehaviour
{
    public GameObject pickupExplosion;
    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        
        //find gamecontroller script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        if (other.tag == "Bolt")
        {
            return;
        }

        if (pickupExplosion != null)
        {
            Instantiate(pickupExplosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
        //gameController.AddScore(scoreValue);
       // Destroy(gameObject);
    }
}
