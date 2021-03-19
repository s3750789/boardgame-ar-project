using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string name;
    public int money;
    public int[] cash;
    public int life;
    public int bangBulletCount;
    public int clickBulletCount;
    public int diamondCount;
    public int pictureCount;
    public int cashFromPicture;
    public bool hasSurrender;
}
[System.Serializable]
public class PlayerCollection
{
    public Player[] players;
}