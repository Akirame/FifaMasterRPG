using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour {

    private float moving;
    private bool dead;
    private bool kick;
    public Animator anim;

    private void Start()
    {
               
        moving = 0;
        dead = false;
        kick = false;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moving = Mathf.Abs(vertical );
        anim.SetFloat("moving", moving);        
        if (Input.GetKeyDown(KeyCode.J) && !kick)
        {
            Debug.Log("holi");
            kick = true;
            anim.SetBool("kicking", kick);
        }
        if (Input.GetKeyDown(KeyCode.K) && !dead)
        {
            dead = true;
            anim.SetBool("dead", dead);
        }
    }
    public void stopKick()
    {
        Debug.Log("stop");
        kick = false;
        anim.SetBool("kicking", kick);
    }
    public void stopDead()
    {
        dead = false;
        anim.SetBool("dead", dead);
    }
}
