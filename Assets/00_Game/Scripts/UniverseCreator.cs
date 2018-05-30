using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseCreator : MonoBehaviourSingleton<UniverseCreator>
{
    public GameObject planetPrefab;

    public float minPlanetSize;
    public float maxPlanetSize;

    public float minPlanetDistanceToSun;
    public float maxPlanetDistanceToSun;

    public int minPlanetsToCreate;
    public int maxPlanetsToCreate;

    public GameObject Sun;

    public void CreateUniverse()
    {
        int planetCount = Random.Range(minPlanetsToCreate, maxPlanetsToCreate);

        for (int i = 0; i < planetCount; i++)
        {
            GameObject newPlanetGO = Instantiate(planetPrefab);
            Planet newPlanet = newPlanetGO.GetComponent<Planet>();

            float distanceToSun = Random.Range(minPlanetDistanceToSun, maxPlanetDistanceToSun);

            float planetSize = Random.Range(minPlanetSize, maxPlanetSize);

            newPlanet.Set(Sun, distanceToSun, planetSize);
            newPlanet.traslationSpeed = Random.Range(1f,3f);
            newPlanet.transform.parent = transform;
        }
    }
}
