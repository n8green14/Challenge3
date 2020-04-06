using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public AudioSource musicSource;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        musicSource.Play();
    }

}
