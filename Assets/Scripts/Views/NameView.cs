using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NameView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;
    public void UpdateView(string name)
    {
        nameText.text = name;
    }
}
