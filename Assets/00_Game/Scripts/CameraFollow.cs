using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    #region singleton
    private static CameraFollow instance;
    public static CameraFollow Get()
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
    private GameObject toFollow;
    public Vector3 offSetShip;
    public Vector3 offSetPlanet;
    private Vector3 offSet;

    private void Start()
    {
        offSet = offSetShip;
        toFollow = GameManager.Get().GetShip();
    }
    void Update ()
    {
        transform.LookAt(toFollow.transform);
        transform.position = toFollow.transform.position + offSet;
	}
    public void LookAtPlanet(GameObject planet)
    {
        toFollow = planet;
        offSet = offSetPlanet;
    }
    public void LookAtShip(GameObject ship)
    {
        toFollow = ship;
        offSet = offSetShip;
    }
}
