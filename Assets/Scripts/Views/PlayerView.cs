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
    private TextMeshProUGUI bangBulletCountText;
    [SerializeField]
    private TextMeshProUGUI clickBulletCountText;
    [SerializeField]
    private TextMeshProUGUI diamondCountText;
    [SerializeField]
    private TextMeshProUGUI pictureCountText;
    [SerializeField]
    private Image[] hearts;
    public void UpdateView(Player player)
    {
        cashText.text = string.Format("Cash: {0}", player.cash);
        bangBulletCountText.text = string.Format("Bang: {0}", player.bangBulletCount);
        clickBulletCountText.text = string.Format("Click: {0}", player.clickBulletCount);
        diamondCountText.text = string.Format("Diamond: {0}", player.diamondCount);
        pictureCountText.text = string.Format("Picture: {0}", player.pictureCount);

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
