using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    GameObject player;

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
        CameraFollow.Get().LookAtPlanet(Ship.Get().GetLastPlanetTouched());
        UIManager.Get().LandPlanet();
    }
    public void ExitPlanet()
    {
        player.SetActive(true);
        GameObject planet = Ship.Get().GetLastPlanetTouched();
        planet.transform.gameObject.GetComponent<Planet>().ShaderNormal(); // volver al shader normal del planeta
        CameraFollow.Get().LookAtShip(player);
        UIManager.Get().ExitPlanet();
    }
}
