using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerReader playerReader;
    [SerializeField] private PlayerView[] playerViews;
    [SerializeField] private KeyCode updateKey = KeyCode.Space;
    [SerializeField] private int updateInterval = 2;
    [SerializeField] private int[] pictureValues = { 4000, 12000, 30000, 60000, 100000, 150000, 200000, 300000, 400000, 500000 };

    private IEnumerator Start()
    {
        while (true)
        {
            UpdateViews();
            yield return new WaitForSeconds(updateInterval);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(updateKey))
        {
            UpdateViews();
        }
    }
    private void UpdateViews()
    {
        Player[] players = playerReader.GetAll();
        for (int i = 0; i < playerViews.Length; i++)
        {
            Player player = players[i];
            player.money = player.cash.Sum();
            if (player.pictureCount > 0) player.money += pictureValues[player.pictureCount-1];
            playerViews[i].UpdateView(player);
        }
    }
}
