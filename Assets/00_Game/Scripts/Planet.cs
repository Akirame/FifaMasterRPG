using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public enum TYPE {

        PLANETRED,
        PLANETGREEN,
        PLANETBLUE,
    }
    public GameObject rotateAround;
    public TYPE typeOfPlanet;
    public float radius = 10;
    public float traslationSpeed = 10;
    public float angle;
    public float rotationSpeed;

    private Renderer rend;
    private Shader shader1;
    private Shader shader2;        

    private string[] names = { "Norfair","Dune","Hyperion","Andromeda","Exodus","Kashyyyk"};
    private string planetName;
    private string planetInfo;

    private void Start()
    {
        planetName = names[Random.Range(0, names.Length)];
        rend = GetComponent<Renderer>();
        shader1 = Shader.Find("Standard");
        shader2 = Shader.Find("Outlined/Custom");

        switch (typeOfPlanet)
        {
            case TYPE.PLANETRED:
                planetInfo = "A planet full of lava";
                break;
            case TYPE.PLANETGREEN:
                planetInfo = "A planet full of Shitty trees";
                break;
            case TYPE.PLANETBLUE:
                planetInfo = "A planet full of water";
                break;
        }
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
            ShaderOutLine();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            ShaderNormal();
    }
    public void ShaderNormal()
    {
        rend.material.shader = shader1;
    }
    public void ShaderOutLine()
    {
        rend.material.shader = shader2;
    }
    public string GetPlanetName()
    {
        return planetName;
    }
    public string GetPlanetInfo()
    {
        return planetInfo;
    }
    public TYPE GetTypeOfPlanet()
    {
        return typeOfPlanet;
    }
}
