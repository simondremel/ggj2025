using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public GameObject prefab;
    public int gooCost;
    public float orbitalRadius;
    public float orbitalRadiusVariance;

    public void Buy()
    {
        GameManager.Instance.Goo -= gooCost;
        GameManager.Instance.SpawnPrefab(orbitalRadius, prefab, orbitalRadiusVariance);
    }
}
