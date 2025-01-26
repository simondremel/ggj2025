using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempIndicator : MonoBehaviour
{
    public GameObject tempIndicatorCold;
    public GameObject tempIndicatorHot;

    private void Update()
    {
        tempIndicatorCold.SetActive(GameManager.Instance.bubble.Area <= 9f);
        tempIndicatorHot.SetActive(GameManager.Instance.bubble.Area >= 16f);
    }
}
