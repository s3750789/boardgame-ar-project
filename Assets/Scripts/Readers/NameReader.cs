using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NameReader
{
    [SerializeField]
    private string path = "/names.json";

    public string[] GetAll()
    {
        return JsonUtility.FromJson<NameCollecton>(StreamingAssetsUtil.GetContent(path)).names;
    }
}
