using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour, IView<Player>
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI cashText;
    [SerializeField] private Color emptyHeartColor;
    [SerializeField] private TextMeshProUGUI bangBulletCountText;
    [SerializeField] private TextMeshProUGUI clickBulletCountText;
    [SerializeField] private TextMeshProUGUI diamondCountText;
    [SerializeField] private TextMeshProUGUI pictureCountText;
    [SerializeField] private Image[] hearts;
    public void UpdateView(Player player)
    {
        nameText.text = player.name;
        cashText.text = string.Format("${0}", player.money);
        bangBulletCountText.text = string.Format("x{0}", player.bangBulletCount);
        clickBulletCountText.text = string.Format("x{0}", player.clickBulletCount);
        diamondCountText.text = string.Format("x{0}", player.diamondCount);
        pictureCountText.text = string.Format("x{0} (+{1})", player.pictureCount, player.cashFromPicture);

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
