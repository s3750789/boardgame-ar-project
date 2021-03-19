using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bullet
{
    public float x1, x2, y1, y2, x3, y3, x4, y4;
    public string type;
}
[System.Serializable]
public class BulletCollection
{
    public Bullet[] bullets;
}
