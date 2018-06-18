using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    GameObject player;
    GameObject planet;

    private void Start()
    {
        player = Ship.Get().transform.gameObject;
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
                break;
            case Planet.TYPE.PLANETGREEN:
                Debug.Log("level2");
                break;
            case Planet.TYPE.PLANETBLUE:
                Debug.Log("level3");
                break;
        }
    }

    public GameObject GetPlayer()
    {
        return player;
    }

}
