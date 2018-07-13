using System;
using UnityEngine;

public class EnemyMelee : Enemy
{

    // Use this for initialization
    void Start()
    {
        target = TempPlayerMov.Get().transform;
        currentState = STATES.ROAMING;
        chasingDistance = 7;
        attackingDistance = 1.5f;
        timeToAttack = 2f;
    }
    // Update is called once per frame
    void Update()
    {
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
        else 
            currentState = STATES.CHASING;        
        //else
        //{
        //    currentState = STATES.ROAMING;
        //}
    }


    override public void Kill()
    {
        Hitted(this);        
        Destroy(this.gameObject);
    }
}
