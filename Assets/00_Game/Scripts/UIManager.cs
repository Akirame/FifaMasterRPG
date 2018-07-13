using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    #region singleton
    private static UIManager instance;
    public static UIManager Get()
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
    public GameObject landButton;
    public GameObject exitButton;
    public GameObject enterButton;
    public GameObject planetText;
    public Image fuelBar;
    public Text planetName;
    public Text planetInfo; 
    public void OnPlanet()
    {
        landButton.SetActive(true);
    }
    public void OffPlanet()
    {
        landButton.SetActive(false);
    }

    private Planet planet;

    public void LandPlanet()
    {        
        landButton.SetActive(false);
        exitButton.SetActive(true);
        enterButton.SetActive(true);
        planetName.text = planet.GetPlanetName();
        planetInfo.text = planet.GetPlanetInfo();
        fuelBar.gameObject.SetActive(false);
        planetText.SetActive(true);        
    }
    public void ExitPlanet()
    {
        planetText.SetActive(false);        
        exitButton.SetActive(false);
        enterButton.SetActive(false);
        fuelBar.gameObject.SetActive(true);
    }
    public void SetPlanet(Planet _planet)
    {
        planet = _planet;
    }

    private void Update()
    {
        UpdateLabels();
    }

    private void UpdateLabels()
    {
        Ship player = GameManager.Get().GetShip().GetComponent<Ship>();
        fuelBar.fillAmount = player.GetFuel() / player.GetMaxFuel();
    }
}
