using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealf : MonoBehaviour
{
    [SerializeField] private GameObject animDestr;
    [SerializeField] private GameObject animCoin;
    [SerializeField] private Image healfLine;

    Canvas canvas;
    float maxHealf = 100f;
    float healf = 100f;

    private void Start()
    {
        canvas = healfLine.gameObject.GetComponentInParent<Canvas>();
        canvas.enabled = false;
    }

    public void Damage(float damage)
    {
        healf -= damage;
        canvas.enabled = true;
        if (healf <= 0)
            Destroyer();
    }

    private void Update()
    {
        healfLine.fillAmount = healf / maxHealf;
    }

    private void Destroyer()
    {
        Instantiate(animCoin, transform.position, Quaternion.identity);
        Instantiate(animDestr, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
}
