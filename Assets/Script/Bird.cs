using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BirdStateType
{
    Fly
}

public class Bird : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rd;

    //×´Ì¬Ïà¹Ø
    private Dictionary<BirdStateType, IState> states = new Dictionary<BirdStateType, IState>();
    private IState currentState;

    public float speed;
    public bool start;
    public float startTime;
    public float jumpForce;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rd = GetComponent<Rigidbody2D>();

        states.Add(BirdStateType.Fly, new BirdFlyState(this));

        transState(BirdStateType.Fly);

        
    }

    public void transState(BirdStateType state)
    {
        if (currentState != null)
            currentState.onExit();
        currentState = states[state];
        currentState.onEnter();
    }

    private void Update()
    {
        currentState.onUpdate();
    }

    private void FixedUpdate()
    {
        currentState.onFixedUpdate();   
    }

    



}
