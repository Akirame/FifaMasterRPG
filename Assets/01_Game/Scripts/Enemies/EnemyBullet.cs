using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    public float speed;
    public float aliveTime;

    private float timer;

    private void Start()
    {
        transform.LookAt(TempPlayerMov.Get().transform);
        timer = 0;
    }

    private void Update()
    {
        if (timer < aliveTime)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
            timer = 0;
        }
    }
}
