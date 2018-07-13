using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    public EnemyBullet bullet;    
    private bool teletransport;
    private bool shooting;
    public Vector3 teletransportSize;
    void Start()
    {
        target = TempPlayerMov.Get().transform;
        currentState = STATES.CHASING;
        timerAttack = 0f;
        teletransport = false;
        shooting = false;
    }

    void Update()
    {
        StateMachine();
    }

    private void StateMachine()
    {
        switch (currentState)
        {
            case STATES.CHASING:
                if (timerAttack < timeToAttack)
                {                    
                    this.transform.LookAt(target);
                    if (!teletransport)
                    {
                        Vector3 pos = new Vector3(Random.Range(-teletransportSize.x / 2, teletransportSize.x / 2), 1, (Random.Range(-teletransportSize.z/2, teletransportSize.z / 2)));
                        Debug.Log(pos);
                        transform.position = pos;
                        teletransport = true;
                    }
                    timerAttack += Time.deltaTime;                    
                }
                else
                {
                    timerAttack = 0f;
                    teletransport = false;
                    currentState = STATES.ATTACKING;
                }
                break;
            case STATES.ATTACKING:
                if (timerAttack < timeToAttack)
                {
                    if (!shooting)
                    {
                        Instantiate(bullet, transform.position, bullet.transform.rotation, this.transform);
                        shooting = true;
                    }
                    timerAttack += Time.deltaTime;
                }
                else
                {
                    timerAttack = 0f;
                    shooting = false;
                    currentState = STATES.CHASING;
                }
                break;
        }
    }

    private void OnDrawGizmosSelected() //draw rango de teleport en la escena
    {
        Gizmos.color = new Color(1, 0, 0, 5f);
        Gizmos.DrawCube(Vector3.zero, teletransportSize);
    }
    override public void Kill()
    {
        Hitted(this);
        Destroy(this.gameObject);
    }
}
