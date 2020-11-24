using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerReader : MonoBehaviour
{
    [SerializeField]
    private string playersPath = "/players.json";

    public Player[] GetAll()
    {
        string path = Application.streamingAssetsPath + playersPath;
        string content = File.ReadAllText(path);
        return JsonUtility.FromJson<PlayerCollection>(content).players;
    }

}
