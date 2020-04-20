using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFScrollerDistant : MonoBehaviour
{

    private ParticleSystem ps;
    private float particleSpeed = 1.0f;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }


    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = particleSpeed;
    }


    public void WinScroller(bool sfWinScrollerDistant = false)
    {
        if (sfWinScrollerDistant == true)
        {
            particleSpeed = 7.0f;
            /*for (int i = 0; i < 4; i++)
            {
                particleSpeed = particleSpeed * 5;
                if (i == 3)
                    sfWinScroller = false;
            }*/


        }
    }
}