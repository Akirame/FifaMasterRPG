using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 300;
    public Vector3 velocity;
    public GameObject player;


    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<EnemyMelee>().Kill();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            other.GetComponent<TempPlayerMov>().SetBall(gameObject);
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player = null;
            other.GetComponent<TempPlayerMov>().ball = null;
        }
    }*/

}
