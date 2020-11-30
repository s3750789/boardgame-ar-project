using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameController : MonoBehaviour
{
    [SerializeField]
    private NameReader nameReader;
    [SerializeField]
    private NameView[] nameViews;
    private void Start()
    {
        UpdateViews();
    }
    private void UpdateViews()
    {
        string[] names = nameReader.GetAll();
        for (int i = 0; i < nameViews.Length; i++)
        {
            nameViews[i].UpdateView(names[i]);
        }
    }
}
