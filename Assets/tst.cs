using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tst : MonoBehaviour {

    public Vector3 center;
    public Vector3 size;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 5f);
        Gizmos.DrawCube(center, size);
    }
}
