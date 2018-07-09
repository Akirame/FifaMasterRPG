using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuiciderEnemy : Enemy {

    void Start()
    {
        target = TempPlayerMov.Get().transform;
        currentState = STATES.CHASING;
    }

    private void FixedUpdate()
    {
        ChaseBehaviour();
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
    override public void Kill()
    {        
        Hitted(this);
        Destroy(this.gameObject);
    }
}
