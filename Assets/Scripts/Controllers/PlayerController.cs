using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerReader playerReader;
    [SerializeField] private PlayerView[] playerViews;
    [SerializeField] private KeyCode updateKey = KeyCode.Space;
    [SerializeField] private int updateInterval = 2;
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private Transform[] textSpawnTransforms;
    [SerializeField] private int[] pictureValues = { 4000, 12000, 30000, 60000, 100000, 150000, 200000, 300000, 400000, 500000 };
    private int[] moneySnapshots = { 0, 0, 0, 0 };
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
            int previousMoney = moneySnapshots[i];
            player.money = player.cash.Sum();
            int cashFromPicture = 0;
            if (player.pictureCount > 0) cashFromPicture = pictureValues[player.pictureCount - 1];
            player.money += cashFromPicture;
            player.cashFromPicture = cashFromPicture;
            if (previousMoney != player.money)
            {
                int diff = player.money - previousMoney;
                GameObject g = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
                g.transform.position = textSpawnTransforms[i].position;
                char sign = diff >= 0 ? '+' : '-';
                g.GetComponent<TextMeshProUGUI>().text = sign + diff.ToString();
            }
            moneySnapshots[i] = player.money;
            playerViews[i].UpdateView(player);
        }
    }
}
