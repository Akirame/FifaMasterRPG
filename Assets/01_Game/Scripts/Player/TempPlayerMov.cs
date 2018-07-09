using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMov : MonoBehaviour
{
    #region Singleton
    public static TempPlayerMov instance;
    public static TempPlayerMov Get()
    {
        return instance;
    }

    void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(this);
    }
    #endregion

    public float speed = 5f;
    public GameObject ball;
    public Vector3 direction;
    public float rotationSpeed = 30f;
    public bool ballInControl = false;
    public float ballForceForward;
    public float ballForceUpward;
    public float maxForceUp;
    public float maxForceForw;

	private PlayerStats playerStats;
    private float distanceBallFromPlayer;
    private float forceUp;
    private float forceForw;    
    private bool shooting;    

    private void Start()
    {
        forceUp = 0;
        forceForw = 0;        
        shooting = false;        
        distanceBallFromPlayer = 1;

		// Permite acceder a los stats modificados en el player
		playerStats = GetComponent<PlayerStats>();
    }
    void Update ()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * vertical * (speed + playerStats.speed.GetValue()) * Time.deltaTime);

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
            ball.transform.position = ballPos + transform.forward * distanceBallFromPlayer;
        }
    }

    internal void SetBall(GameObject _ball)
    {
        ballInControl = true;
        ball = _ball;
    }

    private void ShootBehaviour()
    {
        if (ball &&  ballInControl && Input.GetKey(KeyCode.Space) & !shooting)
        {
            forceForw += ballForceForward * Time.deltaTime;
            forceUp += ballForceUpward * Time.deltaTime;
            if (forceForw >= maxForceForw)
                forceForw = maxForceForw;
            if (forceUp >= maxForceUp)
                forceUp = maxForceUp;            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shooting = true;
        }
        if (ball && ballInControl && shooting)
        {
			int forceFromItems = playerStats.power.GetValue();
            Vector3 dir =  (transform.forward * (forceForw + forceFromItems) + (transform.up * forceUp));
            ballInControl = false;
            ball.GetComponent<Ball>().Shoot(dir);
            forceForw = 0;
            forceUp = 0;
            shooting = false;
        }
    }
    public float GetForce()
    {
        return forceForw;
    }
    public float GetMaxForce()
    {
        return maxForceForw;
    }
}
