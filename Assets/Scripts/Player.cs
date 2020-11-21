using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string name;
    public int cash;
    public int life;
}
[System.Serializable]
public class PlayerCollection
{
    public Player[] players;
}