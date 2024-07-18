using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private void Update()
    {
        GameObject bird = GameObject.Find("Bird");
        transform.position = new Vector3(bird.transform.position.x, 0, -10);
    }
}
