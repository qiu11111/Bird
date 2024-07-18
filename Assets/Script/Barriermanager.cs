using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriermanager : MonoBehaviour
{
    public GameObject Barrier;
    private GameObject bird;
    private float x;
    private float distance;
    private float x0;
    private List<GameObject> barriersDown;
    private List<GameObject> barriersUp;

    public float height;
    public float ground;
    public float num1;
    public float num2;

    public bool wake;
    public float startTime;
    public float timer;

    public float maxHeight;
    public float minHeight;

    //barrier¿í¶È£º1.5808  ¸ß¶È£º12.80984


    private void Awake()
    {
        bird = GameObject.Find("Bird");
        x0 = bird.transform.position.x;
        barriersDown = new List<GameObject>();
        barriersUp = new List<GameObject>();
    }

    private void Update()
    {
        trans();
        timer += Time.deltaTime;
        if (timer >= startTime)
        {
            wake = true;
        }
        bird = GameObject.Find("Bird");
        x = bird.transform.position.x;
        /*distance = x - x0;
        if (distance >= 1.5808f)
        {
            createBarrierDown();
            createBarrierUp();
            distance = 0;
            x0 = x;
        }*/
        distance = x - x0;
        delete();
        if (wake)
        {
            if (distance >= 1.5808f)
            {
                createDouble(cHeight(), dixing());
                distance = 0;
                x0 = x;
            }
            
        }
    }
    public float dixing()
    {
        float noise = Mathf.PerlinNoise(Time.time * num1, 0f);
        return Mathf.Lerp(-7, 10, noise);
    }
    public float cHeight()
    {
        float noise = Mathf.PerlinNoise(Time.time * num2, 0f);
        return Mathf.Lerp(minHeight, maxHeight, noise);
    }
    public void createBarrierDown()
    {
        GameObject barrier=GameObject.Instantiate(Barrier, new Vector2(x+25f, -11.09f), Quaternion.identity);
        barrier.transform.localScale = new Vector3(3.04f, 3.04f, 3.04f);
        float p = (float)Random.Range(1, 10) / 10.0f;
        barrier.GetComponent<BarrierController>().longer(p);
        if(barrier!=null)
            barriersDown.Add(barrier);
    }
    public void delete()
    {
        foreach(GameObject o in barriersDown)
        {
            if (x - o.transform.position.x > 25)
            {
                Destroy(o.gameObject);
                barriersDown.Remove(o);
            }
        }
        foreach(GameObject p in barriersUp)
        {
            if (x - p.transform.position.x > 25)
            {
                Destroy(p.gameObject);
                barriersUp.Remove(p);
            }
        }
    }
    public void createBarrierUp()
    {
        GameObject barrier = GameObject.Instantiate(Barrier, new Vector2(x + 25f, 20.0f), Quaternion.identity);
        barrier.transform.localScale = new Vector3(3.04f, 3.04f, 3.04f);
        barrier.GetComponent<SpriteRenderer>().flipY = true;
        float p = (float)Random.Range(1, 10) / 10.0f;
        barrier.GetComponent<BarrierController>().upLonger(p);
        if (barrier != null)
            barriersUp.Add(barrier);
    }



    public void createBarrierUp1(float length)
    {
        GameObject barrier = GameObject.Instantiate(Barrier, new Vector2(x + 25f, 20.0f), Quaternion.identity);
        barrier.transform.localScale = new Vector3(3.04f, 3.04f, 3.04f);
        barrier.GetComponent<SpriteRenderer>().flipY = true;
        barrier.GetComponent<BarrierController>().upLonger(length);
        if (barrier != null)
            barriersUp.Add(barrier);
    }
    public GameObject createBarrierDown1(float length)
    {
        GameObject barrier = GameObject.Instantiate(Barrier, new Vector2(x + 25f, -11.09f), Quaternion.identity);
        barrier.transform.localScale = new Vector3(3.04f, 3.04f, 3.04f);
        float p = length / 12.80984f * 3.04f;
        barrier.GetComponent<BarrierController>().longer(p);
        if (barrier != null)
            barriersDown.Add(barrier);
        return barrier;
    }

    public void createDouble(float height, float ground)
    {
        GameObject barrier = createBarrierDown1(ground);
        float y = barrier.GetComponent<SpriteRenderer>().bounds.size.y;
        float length = 31.09f - y - height;
        float p = length / 12.80984f * 3.04f;
        createBarrierUp1(p);
    }

    public void trans()
    {
        if (timer >= 20)
            maxHeight = 15;
        if (timer > 40)
            maxHeight = 10;
            
    }


}
