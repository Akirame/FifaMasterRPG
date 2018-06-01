using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public GameObject toFollow;
    public Vector3 offSet;
    
	void Update ()
    {
        transform.LookAt(toFollow.transform);
        transform.position = toFollow.transform.position + offSet;
	}
}
