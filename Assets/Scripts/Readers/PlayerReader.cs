using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayerReader : IReader<Player>
{
    [SerializeField]
    private string path = "/players.json";

    public Player[] GetAll()
    {
        return JsonUtility.FromJson<PlayerCollection>(StreamingAssetsHelper.GetContent(path)).players;
    }

}
