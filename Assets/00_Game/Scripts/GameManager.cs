using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region singleton
    private static GameManager instance;
    public static GameManager Get()
    {
        return instance;
    }
    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
	#endregion
    GameObject player;
    GameObject planet;
    GameObject universeCreator;
    GameObject ship;
    GameObject inventory;

    private void Update()
    {
        SceneManager.sceneLoaded += ManageDontDestroys;
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
        ship.SetActive(false);
        planet = Ship.Get().GetLastPlanetTouched();
        planet.transform.gameObject.GetComponent<Planet>().ShaderNormal(); // volver al shader normal del planeta

        CameraFollow.Get().LookAtPlanet(Ship.Get().GetLastPlanetTouched());

        UIManager.Get().SetPlanet(planet.GetComponent<Planet>());
        UIManager.Get().LandPlanet();
    }

    public void ExitPlanet()
    {
        ship.SetActive(true);
        ship.transform.position = Ship.Get().GetLastPlanetTouched().transform.position;
        CameraFollow.Get().LookAtShip(ship);
        UIManager.Get().ExitPlanet();
    }
    public void LoadLevel()
    {
        switch (planet.transform.gameObject.GetComponent<Planet>().GetTypeOfPlanet())
        {
            case Planet.TYPE.PLANETRED:
                LoaderManager.Get().LoadScene("Level1");
                break;
            case Planet.TYPE.PLANETGREEN:
                LoaderManager.Get().LoadScene("Level2");
                break;
            case Planet.TYPE.PLANETBLUE:
                LoaderManager.Get().LoadScene("Level3");                
                break;
        }
    }
    public void SetPlayer(GameObject p)
    {        
        player = p;
    }
    public void SetShip(GameObject s)
    {                
            ship = s;
    }
    public void SetUniverse(GameObject u)
    {        
            universeCreator = u;
    }
    public void SetInventory(GameObject i)
    {
        inventory = i;
    }
    public GameObject GetShip()
    {
        return ship;
    }
    private void ManageDontDestroys(Scene scene, LoadSceneMode mode)
    {
        if (LoaderManager.Get().OnLevel())
        {
            if (player)
                player.SetActive(true);
            if (ship)
                ship.SetActive(false);
            if (universeCreator)
                universeCreator.SetActive(false);
            if (inventory)
                inventory.SetActive(true);
        }
        else if (LoaderManager.Get().OnLevelSelect())
        {            
            if (player)
                player.SetActive(false);
            if (ship)
                ship.SetActive(true);
            if (universeCreator)
                universeCreator.SetActive(true);
            if (inventory)
                inventory.SetActive(false);
        }
        else
        {            
            if (player)
                player.SetActive(false);
            if (ship)
                ship.SetActive(false);
            if (universeCreator)
                universeCreator.SetActive(false);
            if (inventory)
                inventory.SetActive(false);
        }
    }
}
