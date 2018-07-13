using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArrowHud : MonoBehaviour {

    public Image arrowImage;

    private void Start()
    {
        arrowImage.fillAmount = TempPlayerMov.Get().GetForce();
    }
    private void Update()
    {                
        arrowImage.fillAmount = TempPlayerMov.Get().GetForce() / TempPlayerMov.Get().GetMaxForce();
    }
}
