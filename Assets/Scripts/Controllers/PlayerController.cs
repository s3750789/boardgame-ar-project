using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerReader playerReader;
    [SerializeField]
    private PlayerView[] playerViews;
    [SerializeField]
    private KeyCode updateKey = KeyCode.Space;
    [SerializeField]
    private GameObject bullet;
    private Camera cam;
    private void Awake()
    {
        cam = Camera.main;
    }
    // private IEnumerator Start()
    // {
    //     while (true)
    //     {
    //         UpdateAllViews();
    //         yield return new WaitForSeconds(2f);
    //     }
    // }
    private void Update()
    {
        if (Input.GetKeyDown(updateKey))
        {
            UpdateAllViews();
        }
    }
    private void UpdateAllViews()
    {
        Player[] players = playerReader.GetAll();
        for (int i = 0; i < playerViews.Length; i++)
        {
            Player player = players[i];
            playerViews[i].UpdateView(player);
            foreach (var card in player.cards)
            {
                Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, -10));

                print(position);
                Instantiate(bullet, position, Quaternion.identity);
            }
        }
    }
}
