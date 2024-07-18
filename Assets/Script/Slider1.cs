using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Slider1 : MonoBehaviour
{
    private Slider slider;
    private GameObject manager;
    private Barriermanager barrierManager;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        manager = GameObject.Find("BarrierManager");
        barrierManager = manager.GetComponent<Barriermanager>();
        slider.value = 0.4f;
    }
    private void Update()
    {
        barrierManager.ground = slider.value * 20 - 7;
    }
}
