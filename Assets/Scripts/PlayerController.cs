using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerReader playerReader;
    [SerializeField]
    private PlayerView[] playerViews;
    [SerializeField]
    private KeyCode updateKey = KeyCode.Space;
    private void Awake()
    {
        playerReader = GetComponent<PlayerReader>();
    }
    private IEnumerator Start()
    {
        while (true)
        {
            UpdateAllViews();
            yield return new WaitForSeconds(2f);
        }
    }
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
            playerViews[i].UpdateView(players[i]);
        }
    }
}
