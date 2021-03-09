using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bullet
{
    public float x1;
    public float y1;
    public float x2;
    public float y2;
    public string type;
}
[System.Serializable]
public class BulletCollection
{
    public Bullet[] bullets;
}
