using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private Text gemText;
    public static int coin = 0;
    public static int gem = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bonus")
        {
            if (other.gameObject.name.Contains("Coin"))
            {
                coin++;
                PlayerPrefs.SetInt("Coin", coin);
            }
            if (other.gameObject.name.Contains("Gem"))
            {
                gem++;
                PlayerPrefs.SetInt("Gem", gem);
            }
            Destroy(other.gameObject);
        }
        coinText.text = coin.ToString();
        gemText.text = gem.ToString();
    }
}
