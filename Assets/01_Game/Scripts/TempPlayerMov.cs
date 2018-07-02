using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMov : MonoBehaviour
{
	public float speed = 5f;
    public GameObject ball;
    public Vector3 direction;

	void Update ()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 mov = transform.position;

		mov.x += horizontal * speed * Time.deltaTime;
		mov.z += vertical * speed * Time.deltaTime;

		transform.position = mov;

        ShootBehaviour();

	}

    private void ShootBehaviour()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball.GetComponent<Ball>().Shoot(direction);
        }
    }

}
