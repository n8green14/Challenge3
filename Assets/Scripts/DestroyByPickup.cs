using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPickup : MonoBehaviour
{
    public GameObject pickupExplosion;

    public bool pickup = false;
    public int scoreValue;
    private PlayerController playerController;
    private GameController gameController;

    void Start()
    {
        //find playercontroller script
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<PlayerController>();
        }
        if (playerController == null)
        {
            Debug.Log("Cannot find 'PlayerController' script");
        }
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
            pickup = true;
            playerController.Pickup(pickup);
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
       // gameController.AddScore(scoreValue);
        //Destroy(gameObject);
    }
}
