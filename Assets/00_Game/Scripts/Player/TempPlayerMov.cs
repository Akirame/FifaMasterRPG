using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMov : MonoBehaviour
{
    #region singleton
    private static TempPlayerMov instance;
    public static TempPlayerMov Get()
    {
        return instance;
    }
    public virtual void Awake()
    {
        if (instance == null)
        {
            //GameManager.Get().SetPlayer(this.gameObject);
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
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

    private float moving;
    private bool dead;    
    public Animator anim;


    private void Start()
    {
        moving = 0;
        dead = false;
        forceUp = 0;
        forceForw = 0;        
        shooting = false;        
        distanceBallFromPlayer = 1;

		// Permite acceder a los stats modificados en el player
		playerStats = GetComponent<PlayerStats>();
    }
    void Update()
    {
        if (!shooting)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            if (vertical < 0)            
                anim.SetBool("runBackward", true);            
            else
                anim.SetBool("runBackward", false);
            moving = (Mathf.Abs(vertical)+ Mathf.Abs(horizontal));
            anim.SetFloat("moving", moving);           
            transform.Translate(Vector3.forward * vertical * (speed + playerStats.speed.GetValue()) * Time.deltaTime);

            transform.Rotate(transform.up, horizontal * rotationSpeed * Time.deltaTime);
        }

        ShootBehaviour();

        BallControlBehaviour();
        if (Input.GetKeyDown(KeyCode.Z))
            LoaderManager.Get().LoadScene("LevelSelect");

		Inventory.Get().playerSpeed = playerStats.speed.GetValue();
		Inventory.Get().playerPower = playerStats.power.GetValue();
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
            anim.SetBool("kicking", true);
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
    public void BallShoot()
    {
        anim.SetBool("kicking", false);
        if (ball && ballInControl)
        {
            int forceFromItems = playerStats.power.GetValue();
            Vector3 dir = (transform.forward * (forceForw + forceFromItems) + (transform.up * forceUp));
            ballInControl = false;
            ball.GetComponent<Ball>().Shoot(dir);
            forceForw = 0;
            forceUp = 0;            
        }
        shooting = false;
    }
}
