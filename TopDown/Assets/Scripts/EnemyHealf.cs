using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealf : MonoBehaviour
{
    [SerializeField] private GameObject animDestr;
    [SerializeField] private GameObject animBonus;
    [SerializeField] private Image healfLine;

    Canvas canvas;
    [SerializeField] private float maxHealf = 100f;
    float healf = 100f;

    private void Start()
    {
        if (gameObject.name.Contains("Mole"))
            maxHealf = 100f;
        if (gameObject.name.Contains("Treant"))
            maxHealf = 200f;

        canvas = healfLine.gameObject.GetComponentInParent<Canvas>();
        canvas.enabled = false;
        healf = maxHealf;
        Debug.Log(maxHealf);
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
        Instantiate(animBonus, transform.position, Quaternion.identity);
        Instantiate(animDestr, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
}
