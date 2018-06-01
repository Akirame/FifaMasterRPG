using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    public GameObject rotateAround;
    public float radius = 10;
    public float traslationSpeed = 10;
    public float angle;

    private Renderer rend;
    private Shader shader1;
    private Shader shader2;
    
    //Rotacion planeta
    public float rotationSpeed;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        shader1 = Shader.Find("Standard");
        shader2 = Shader.Find("Outlined/Custom");        
    }
    public void Set(GameObject _rotateAround, float _radius, float _size)
    {
        rotateAround = _rotateAround;
        int randomDir = Random.Range(0, 2);
        switch (randomDir)
        {
            case 0:
                radius = _radius;
                break;
            case 1:
                radius = -_radius;
                break;
        }
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
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            rend.material.shader = shader2;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")            
            rend.material.shader = shader1;
    }
}
