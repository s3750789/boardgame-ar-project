using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI cashText;
    [SerializeField]
    private Color emptyHeartColor;
    [SerializeField]
    private Image[] hearts;
    public void UpdateView(Player player)
    {
        cashText.text = string.Format("{0}", player.cash);
        foreach (var heart in hearts)
        {
            heart.color = emptyHeartColor;
        }
        for (int i = 0; i < Mathf.Min(hearts.Length, player.life); i++)
        {
            hearts[i].color = Color.white;
        }
    }
}
