using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseCreator : MonoBehaviour
{

    #region singleton
    private static UniverseCreator instance;
    public static UniverseCreator Get()
    {
        return instance;
    }
    public virtual void Awake()
    {
        if (instance == null)
        {
            GameManager.Get().SetUniverse(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public GameObject planet1;
    public GameObject planet2;
    public GameObject planet3;

    public float minPlanetSize;
    public float maxPlanetSize;

    public float planetDistanceToSun;

    public int minPlanetsToCreate;
    public int maxPlanetsToCreate;

    private List<GameObject> PlanetList = new List<GameObject>();

    public GameObject Sun;

    private void Start()
    {
        PlanetList.Add(planet1);
        PlanetList.Add(planet2);
        PlanetList.Add(planet3);
        CreateUniverse();        
    }
    public void CreateUniverse()
    {
        int planetCount = Random.Range(minPlanetsToCreate, maxPlanetsToCreate);
        
        for (int i = 1; i < planetCount + 1; i++)
        {

            int randomIndex = Random.Range(0, PlanetList.Count);
            
            GameObject newPlanetGO = Instantiate(PlanetList[randomIndex]);
            Planet newPlanet = newPlanetGO.GetComponent<Planet>();

            float distanceToSun = i * planetDistanceToSun;

            float planetSize = Random.Range(minPlanetSize, maxPlanetSize);

            newPlanet.Set(Sun, distanceToSun, planetSize);
            newPlanet.traslationSpeed = Random.Range(2f, 7f);
            newPlanet.transform.parent = transform;
        }
    }
}

