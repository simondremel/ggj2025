using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float growthRate = 1f;

    public Color yellow = new Color(224 / 255f, 202 / 255f, 60 / 255f); // Yellow (E0CA3C)
    public Color red = Color.red; // Red (#FF0000)

    private float startingArea;
    private const float maxAreaFactor = 2f;
    private SpriteRenderer spriteRenderer;

    private float area;
    public float Area { get => area; }

    void Start()
    {
        float startingDiameter = transform.localScale.x;
        startingArea = CircleArea(startingDiameter);
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = yellow;
    }

    public void Grow(float delta)
    {
        //Adjust size

        float currentDiameter = transform.localScale.x;
        float currentArea = CircleArea(currentDiameter);
        float newArea = currentArea + delta;

        if (newArea < 0)
            newArea = 0;

        area = newArea;

        float newDiameter = CircleDiameter(newArea);
        transform.localScale = new Vector3(newDiameter, newDiameter, 1f);

        //Set color based on size
        Color newColor;

        if (newArea < startingArea)
        {
            float areaRatio = (currentArea / startingArea);
            newColor = Color.Lerp(Color.black, yellow, areaRatio);
        }
        else
        {
            float areaRatio = (currentArea - startingArea) / (startingArea * (maxAreaFactor - 1));
            newColor = Color.Lerp(yellow, red, areaRatio);
        }
        spriteRenderer.color = newColor;
    }

    private float CircleArea(float diameter)
    {
        float radius = diameter / 2;
        return Mathf.PI * Mathf.Pow(radius, 2);
    }

    private float CircleDiameter(float area)
    {
        float radius = Mathf.Sqrt(area / Mathf.PI);
        return 2 * radius;
    }

    private void OnMouseUp()
    {
        Grow(growthRate * -10);
        GameManager.Instance.Goo += 1;
    }

    private void Update()
    {
        Grow(growthRate * Time.deltaTime);
    }
}
