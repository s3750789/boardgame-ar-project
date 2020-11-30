using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletReader
{
    [SerializeField]
    private string path = "/bullets.json";
    public Bullet[] GetAll()
    {
        return JsonUtility.FromJson<BulletCollection>(StreamingAssetsHelper.GetContent(path)).bullets;
    }
}
