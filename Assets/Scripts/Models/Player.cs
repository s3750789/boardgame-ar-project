using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public int cash;
    public int life;
    public int bangBulletCount;
    public int clickBulletCount;
    public int diamondCount;
    public int pictureCount;
    public bool hasSurrender;
    public bool isDead;
    public Card[] cards;
}
[System.Serializable]
public class PlayerCollection
{
    public Player[] players;
}