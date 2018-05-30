using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Planet : MonoBehaviour
{

    public GameObject rotateAround;
    public float radius = 10;
    public float traslationSpeed = 10;
    public float angle;

    //Rotacion planeta
    public float rotationSpeed;

    public void Set(GameObject _rotateAround, float _radius, float _size)
    {
        rotateAround = _rotateAround;
        radius = _radius;
        transform.localScale = Vector3.one * _size;
    }

    // Update is called once per frame
    private void Update()
    {
        angle += traslationSpeed * Time.deltaTime;

        Vector3 newPos = Vector3.zero;

        newPos.x = rotateAround.transform.position.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        newPos.z = rotateAround.transform.position.z + radius * Mathf.Sin(angle * Mathf.Deg2Rad);

        transform.position = newPos;

        //Rotacion planeta
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime);
    }
}
