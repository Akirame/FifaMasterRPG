using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject lookAtGameObj;
    public Vector3 offSet;

    private void Update()
    {        
        transform.position = lookAtGameObj.transform.position + offSet;
    }
}
