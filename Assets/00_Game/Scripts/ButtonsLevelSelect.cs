using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsLevelSelect : MonoBehaviour
{
    public void LandPressed()
    {        
        GameManager.Get().LandOnPlanet();
    }
    public void ExitPressed()
    {
        GameManager.Get().ExitPlanet();
    }
    public void EnterPressed()
    {
        GameManager.Get().LoadLevel();
    }
}
