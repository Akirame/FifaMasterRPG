using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMov : MonoBehaviour
{
	public float speed = 5f;
    public GameObject ball;
    public Vector3 direction;
    public float rotationSpeed = 30f;
    public bool ballInControl = false;

	void Update ()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);

        transform.Rotate(transform.up, horizontal * rotationSpeed * Time.deltaTime);

        ShootBehaviour();

        BallControlBehaviour();

	}

    private void BallControlBehaviour()
    {
        if (ball && ballInControl)
        {
            Vector3 ballPos = Vector3.zero;
            ballPos.y = ball.transform.position.y;
            ballPos.x = transform.position.x;
            ballPos.z = transform.position.z;
            ball.transform.position = ballPos + transform.forward * 1;
        }
    }

    internal void SetBall(GameObject _ball)
    {
        ballInControl = true;
        ball = _ball;
    }

    private void ShootBehaviour()
    {
        if (ball && Input.GetKeyDown(KeyCode.Space))
        {
            ballInControl = false;
            ball.GetComponent<Ball>().Shoot(transform.forward);
        }
    }

}
