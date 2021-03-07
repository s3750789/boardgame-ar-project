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
    private Transform bulletContainer;
    private int currentBulletCount = 0;
    [SerializeField] private int bulletCap = 20;
    [SerializeField] private Vector3 offset;
    private void Awake()
    {
        cam = Camera.main;
        bulletContainer = new GameObject().transform;
        bulletContainer.name = "BulletContainer";
        for (int i = 0; i < bulletCap; i++)
        {
            GameObject g = Instantiate(bulletPrefab);
            g.transform.SetParent(bulletContainer);
            g.SetActive(false);
        }
    }
    private void Update()
    {
        UpdateViews();
    }
    public void UpdateViews()
    {
        Bullet[] bullets = bulletReader.GetAll();
        int bulletCount = bullets.Length;
        if (currentBulletCount != bulletCount)
        {
            foreach (Transform bullet in bulletContainer)
            {
                bullet.gameObject.SetActive(false);
            }
            for (int i = 0; i < bulletCount; i++)
            {
                bulletContainer.GetChild(i).gameObject.SetActive(true);
            }
        }
        for (int i = 0; i < bulletCount; i++)
        {
            Bullet bullet = bullets[i];
            bulletContainer.GetChild(i).transform.position = cam.ScreenToWorldPoint(new Vector3(bullet.x, Screen.height - bullet.y, 10)+offset);
        }
    }

}
