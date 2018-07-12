﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    GameObject player;
    GameObject planet;
    GameObject universeCreator;
    GameObject ship;    

    private void Start()
    {
        ship = Ship.Get().transform.gameObject;
        player = TempPlayerMov.Get().transform.gameObject;
        universeCreator = UniverseCreator.Get().transform.gameObject;
    }
    public void ShipOnPlanet()
    {
        UIManager.Get().OnPlanet();
    }
    public void ShipOffPlanet()
    {
        UIManager.Get().OffPlanet();
    }
    public void LandOnPlanet()
    {
        player.SetActive(false);

        planet = Ship.Get().GetLastPlanetTouched();
        planet.transform.gameObject.GetComponent<Planet>().ShaderNormal(); // volver al shader normal del planeta

        CameraFollow.Get().LookAtPlanet(Ship.Get().GetLastPlanetTouched());

        UIManager.Get().SetPlanet(planet.GetComponent<Planet>());
        UIManager.Get().LandPlanet();
    }
    public void ExitPlanet()
    {
        player.SetActive(true);          
        CameraFollow.Get().LookAtShip(player);
        UIManager.Get().ExitPlanet();
    }
    public void LoadLevel()
    {        
        switch (planet.transform.gameObject.GetComponent<Planet>().GetTypeOfPlanet())
        {
            case Planet.TYPE.PLANETRED:
                Debug.Log("level1");
                SceneManager.LoadScene(1);
                break;
            case Planet.TYPE.PLANETGREEN:
                SceneManager.LoadScene(1);
                Debug.Log("level2");
                break;
            case Planet.TYPE.PLANETBLUE:
                SceneManager.LoadScene(1);
                Debug.Log("level3");
                break;
        }
    }

    public GameObject GetPlayer()
    {
        return player;
    }

}
