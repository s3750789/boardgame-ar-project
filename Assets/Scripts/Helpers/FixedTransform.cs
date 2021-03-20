using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTransform : MonoBehaviour
{
    public Vector3 Position {get;set;}
    public Quaternion Rotation {get;set;}
    private void LateUpdate() {
        transform.position = Position;
        transform.rotation = Rotation;
    }
}
