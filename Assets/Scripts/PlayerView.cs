using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI cashText;
    [SerializeField]
    private Image[] hearts;

    public void UpdateView(Player player)
    {
        nameText.text = player.name;
        cashText.text = player.cash.ToString();
        foreach (var heart in hearts)
        {
            heart.gameObject.SetActive(false);
        }
        for (int i = 0; i < Mathf.Min(hearts.Length, player.life); i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
    }
}
