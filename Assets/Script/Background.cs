using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private GameObject cam;
    public float Effect;
    private float xPosition;
    private float length;


    private void Awake()
    {
        cam = GameObject.Find("Main Camera");
        xPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }
   private void Update()
    {
        float move = cam.transform.position.x * Effect;
        float pMove = cam.transform.position.x * (1 - Effect);
        transform.position = new Vector2(xPosition + move, transform.position.y);
        if (pMove > xPosition + length)
        {
            xPosition += length;
        }
            


    }
}
