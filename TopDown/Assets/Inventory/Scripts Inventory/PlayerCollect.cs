using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public int money = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bonus")
        {
            if (other.gameObject.name == "Coin" || other.gameObject.name == "Coin(Clone)")
            {
                money++;
                PlayerPrefs.SetInt("Money", money);
            }
            Destroy(other.gameObject);
        }
    }
}
