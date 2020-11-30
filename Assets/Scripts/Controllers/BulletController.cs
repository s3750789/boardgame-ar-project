using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private BulletReader bulletReader;
    [SerializeField]
    private GameObject bulletPrefab;
    private Camera cam;
    private GameObject bulletContainer;
    private void Awake()
    {
        cam = Camera.main;
        bulletContainer = new GameObject();
    }
    private void Update()
    {
        UpdateViews();
    }
    public void UpdateViews()
    {
        Bullet[] bullets = bulletReader.GetAll();
        foreach (Transform bullet in bulletContainer.transform)
        {
            Destroy(bullet.gameObject);
        }
        foreach (var bullet in bullets)
        {
            Vector3 position = cam.ScreenToWorldPoint(new Vector3(bullet.x, Screen.height - bullet.y, 10));
            print(position);
            Instantiate(bulletPrefab, position, Quaternion.identity, bulletContainer.transform);
        }
    }

}
