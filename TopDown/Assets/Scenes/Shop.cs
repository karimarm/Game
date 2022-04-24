using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private Text gemText;

    [SerializeField] private int smallElixirCost = 5;
    [SerializeField] private int bigElixirCost = 10;
    [SerializeField] private int heartElixirCost = 3;

    [SerializeField] private Text smallElixirText;
    [SerializeField] private Text bigElixirText;
    [SerializeField] private Text heartElixirText;

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject[] Elixires;

    Vector3 vec;

    void Start()
    {
        smallElixirText.text = smallElixirCost.ToString();
        bigElixirText.text = bigElixirCost.ToString();
        heartElixirText.text = heartElixirCost.ToString();
    }

    void Update()
    {
        coinText.text = PlayerCollect.coin.ToString();
        gemText.text = PlayerCollect.gem.ToString();
    }

    public void SendMessage(string str)
    {
        foreach (GameObject i in Elixires)
        {
            if (i.name.Contains(str))
            {
                vec.x = Player.gameObject.transform.position.x + Random.Range(-2f, 2f);
                vec.y = Player.gameObject.transform.position.y + Random.Range(-2f, 2f);
                vec.z = 0;

                if (PlayerCollect.coin >= smallElixirCost)
                {
                    PlayerCollect.coin -= smallElixirCost;
                    Instantiate(i, vec, Quaternion.identity);
                }
                break;
            }
        }
    }
}
