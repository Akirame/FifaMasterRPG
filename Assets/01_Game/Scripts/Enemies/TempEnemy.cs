using System;
using UnityEngine;

public class TempEnemy : MonoBehaviour {

    public enum STATES {ROAMING, CHASING, ATTACKING, LAST}
    public STATES currentState;
    public float speed;
    public Vector3 direction;
    private Vector3 velocity;
    public Transform target;
    public Vector3 steering;
    public float chasingDistance = 7;
    public float attackingDistance = 1.5f;
    public float timeToAttack = 2f;
    public float timerAttack;
    public int damage;

    // Use this for initialization
    void Start () {
        currentState = STATES.ROAMING;
	}
	
	// Update is called once per frame
	void Update () {
        StateMachine();
	}

    private void FixedUpdate()
    {
        ChaseBehaviour();
        AttackBehaviour();
    }

    private void AttackBehaviour()
    {
        if (currentState == STATES.ATTACKING)
        {
            timerAttack += Time.deltaTime;
            if (timerAttack > timeToAttack)
            {
                //target.GetComponent<Player>().TakeDamage(damage);
                timerAttack = 0;
            }
        }
        else
        {
            timerAttack = 0;
        }
    }

    private void ChaseBehaviour()
    {
        if (currentState == STATES.CHASING)
        {
            direction = (target.position - transform.position).normalized;
            velocity.x = speed * direction.x;
            velocity.z = speed * direction.z;
            steering = velocity - GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = (GetComponent<Rigidbody>().velocity + steering) * Time.deltaTime;
            transform.LookAt(target);
        }
    }

    private void StateMachine()
    {
        float distanceToTarget = Vector3.Magnitude(target.position - transform.position);
        if (distanceToTarget < attackingDistance)
        {
            currentState = STATES.ATTACKING;
        }
        else if (distanceToTarget < chasingDistance)
        {
            currentState = STATES.CHASING;
        }
        else
        {
            currentState = STATES.ROAMING;
        }
    }


    public void Kill()
    {
        gameObject.SetActive(false);
    }

}
