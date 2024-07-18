using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdFlyState : IState
{
    private Bird bird;
    private float timer;
    
    public BirdFlyState(Bird bird)
    {
        this.bird = bird;
    }
    public void onEnter()
    {
        bird.rd.velocity = new Vector2(bird.speed,0);
    }

    public void onExit()
    {
        
    }

    public void onFixedUpdate()
    {
        
    }

    public void onUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= bird.startTime)
        {
            bird.start = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //bird.rd.velocity = new Vector2(bird.speed, 5);
            bird.rd.velocity = new Vector2(bird.speed, 0);
            bird.rd.AddForce(Vector2.up * bird.jumpForce,ForceMode2D.Impulse);
        }
        if (bird.start)
            bird.rd.gravityScale = 9.8f;
        if (bird.rd.velocity.x != bird.speed)
            SceneManager.LoadScene("End");
    }
}
