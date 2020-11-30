using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bullet
{
    public int x;
    public int y;
    public string type;
}
[System.Serializable]
public class BulletCollection
{
    public Bullet[] bullets;
}
