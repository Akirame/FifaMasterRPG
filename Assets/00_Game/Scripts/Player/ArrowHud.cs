using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArrowHud : MonoBehaviour {

    public Image arrowImage;

    private void Start()
    {
        arrowImage.fillAmount = PlayerController.Get().GetForce();
    }
    private void Update()
    {                
        arrowImage.fillAmount = PlayerController.Get().GetForce() / PlayerController.Get().GetMaxForce();
    }
}
