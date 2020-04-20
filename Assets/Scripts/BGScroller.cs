using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    

    private Vector3 startPosition;
    private GameController gameController;

    void Start()
    {
        startPosition = transform.position;

        //find Game Controller
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


    void Update()
    {

        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

    }

    public void WinScroller(bool bgWinScroller = false)
    {

        while (bgWinScroller == true)
            {

            scrollSpeed = -3.0f;
            /*for (int i = 0; i< 3; i++)
            {
                scrollSpeed = scrollSpeed* 1.7f;
                if (i == 2)
                    bgWinScroller = false;
            }*/
        bgWinScroller = false;
            break;
        }
    }

}
