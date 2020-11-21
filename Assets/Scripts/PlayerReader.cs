using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReader : MonoBehaviour
{
    [SerializeField]
    private TextAsset playersFile;
    private void Start()
    {
        print(GetAll().Length);
    }
    public Player[] GetAll()
    {
        return JsonUtility.FromJson<PlayerCollection>(playersFile.text).players;
    }

}
