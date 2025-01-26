using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climate : MonoBehaviour
{
    public Color normalColor;
    public Color frozenColor;
    public Color overheatedColor;

    public GameObject tempIndicatorCold;
    public GameObject tempIndicatorHot;
    public SpriteRenderer spriteRenderer;

    public float coldThreshold;
    public float hotThreshold;

    public float coolingRate;
    public float heatingRate;
    public float normalizationRate;

    public float currentTemp;
    
    void Update()
    {
        bool cooling = GameManager.Instance.bubble.Area <= coldThreshold;
        bool heating = GameManager.Instance.bubble.Area >= hotThreshold;
        bool normal = !cooling && !heating;

        tempIndicatorCold.SetActive(cooling);
        tempIndicatorHot.SetActive(heating);
        
        if (cooling) currentTemp -= coolingRate * Time.deltaTime;
        if (heating) currentTemp += heatingRate * Time.deltaTime;
        if (normal) currentTemp += normalizationRate * (currentTemp > 0 ? -1 : 1) * Time.deltaTime;

        currentTemp = Mathf.Clamp(currentTemp, -1f, 1f);

        if(currentTemp < 0)
        {
            spriteRenderer.color = Color.Lerp(normalColor, frozenColor, currentTemp * -1);
        }
        else
        {
            spriteRenderer.color = Color.Lerp(normalColor, overheatedColor, currentTemp);
        }

        if(currentTemp <= -1) GameManager.Instance.GameOverCold();
        if(currentTemp >= 1) GameManager.Instance.GameOverHeat();
    }
}
