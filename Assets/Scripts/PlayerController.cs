﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    public Text shotSpeedText;

    public AudioSource musicSource;

    public bool pickup;
    private Rigidbody rb;
    private float nextFire;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        musicSource = GetComponent<AudioSource>();
        shotSpeedText.text = "";
    }

    public void Pickup(bool pickup)
    {
        if (pickup == true)
        {
            fireRate = 0.1f;
            shotSpeedText.text = "SHOT SPEED INCREASED!";
        }
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            //GameObject clone = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;
            
            musicSource.Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
