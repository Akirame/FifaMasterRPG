using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviourSingleton<UIManager>
{
    public GameObject landButton;
    public GameObject exitButton;

    public void OnPlanet()
    {
        landButton.SetActive(true);
    }
    public void OffPlanet()
    {
        landButton.SetActive(false);
    }
    public void LandPlanet()
    {
        landButton.SetActive(false);
        exitButton.SetActive(true);
    }
    public void ExitPlanet()
    {
        exitButton.SetActive(false);

    }
}
