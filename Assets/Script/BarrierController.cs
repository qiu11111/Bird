using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void longer(float y)
    {
        float a = sr.bounds.size.y;
        sr.transform.localScale = new Vector3(3.04f, sr.transform.localScale.y+y, 3.04f);
        
        float b = sr.bounds.size.y;
        sr.transform.position = new Vector3(sr.transform.position.x, sr.transform.position.y - 0.5f * (a-b), 0);
    }

    public void upLonger(float y)
    {
        float a = sr.bounds.size.y;
        sr.transform.localScale = new Vector3(3.04f, sr.transform.localScale.y + y, 3.04f);
        float b = sr.bounds.size.y;
        sr.transform.position = new Vector3(sr.transform.position.x, sr.transform.position.y + 0.5f * (a - b), 0);
    }

    private void Update()
    {
        
    }
}
