using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyButton : MonoBehaviour
{
    public GameObject prefab;
    public float gooCost;
    public int GooCost { get { return (int)gooCost;  } }
    public float costIncrease;
    public float orbitalRadius;
    public float orbitalRadiusVariance;
    public bool unlocked;

    public string objectName;
    public TextMeshProUGUI buttonText;

    public void Buy()
    {
        GameManager.Instance.Goo -= GooCost;
        GameManager.Instance.SpawnPrefab(orbitalRadius, prefab, orbitalRadiusVariance);
        gooCost += costIncrease;
        buttonText.text = $"{objectName} ({GooCost})";
    }
}
