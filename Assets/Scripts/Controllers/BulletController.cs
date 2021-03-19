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
    [SerializeField] private float bulletScaleFactor = 0.3f;
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
            Transform bulletTransform = bulletContainer.GetChild(i);
            Vector3 topLeft = cam.ScreenToWorldPoint(new Vector3(bullet.x1, Screen.height - bullet.y1) + offset);
            Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(bullet.x2, Screen.height - bullet.y2) + offset);
            Vector3 bottomRight = cam.ScreenToWorldPoint(new Vector3(bullet.x3, Screen.height - bullet.y3) + offset);
            Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(bullet.x4, Screen.height - bullet.y4) + offset);
            Debug.DrawLine(topLeft, topRight, Color.red);
            Debug.DrawLine(topRight, bottomRight, Color.green);
            Debug.DrawLine(bottomRight, bottomLeft);
            Debug.DrawLine(bottomLeft, topLeft);
            Vector3 head = (topLeft + topRight) / 2;
            Vector3 tail = (bottomLeft + bottomRight) / 2;
            Vector3 diff = head - tail;
            Vector3 center = (head + tail) / 2;
            float size = diff.magnitude;
            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            bulletTransform.position = center;
            bulletTransform.rotation = Quaternion.Euler(-angle, 90, 0);
            bulletTransform.localScale = new Vector3(1, 1, 1) * size * bulletScaleFactor;
        }
    }

}
