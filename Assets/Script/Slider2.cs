using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Slider2 : MonoBehaviour
{
    private Slider slider;
    private GameObject manager;
    private Barriermanager barrierManager;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        manager = GameObject.Find("BarrierManager");
        barrierManager = manager.GetComponent<Barriermanager>();
        slider.value = 3f;
    }
    private void Update()
    {
        barrierManager.height = slider.value * 15;
    }
}
