using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float movementSpeed;
    public float speedBoost;
    public float speedMax;

    int hitCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.StartBall());
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        //figure out which player is getting the ball, and send it their way after 2 seconds
        this.hitCounter = 0;
        yield return new WaitForSeconds(2);

        if (isStartingPlayer1)
        {
            // move Left
            this.BallStartMovement(new Vector2(-1, 0));
        } else
        {
            //move right
            this.BallStartMovement(new Vector2(1, 0));
        }
    }

    public void BallStartMovement(Vector2 dir)
    {

        dir = dir.normalized;

        float speed = this.movementSpeed + (this.hitCounter * this.speedBoost);


        //Get RigidBody Component from the game object
        Rigidbody2D rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();


        //This formula will give a consistent speed, regardless of the power of the users machine
        rigidBody2D.velocity = dir * speed * Time.deltaTime;

    }

    public void IncreaseHitCounter()
    {
        if(this.hitCounter * this.speedBoost <= this.speedMax)
        {
            this.hitCounter++;
        }
    }
}
