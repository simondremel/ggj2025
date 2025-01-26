using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : SingletonComponent<GameManager>
{
    [SerializeField] TextMeshProUGUI gooCounter;
    public Bubble bubble;
    public Transform buttonContainer;

    private List<BuyButton> buyButtons;

    private int goo;
    public int Goo
    {
        set
        {
            goo = value;
            gooCounter.text = $"{goo}";
            UpdateButtonVisibility();
        }
        get
        {
            return goo;
        }
    }

    private void Start()
    {
        buyButtons = new(buttonContainer.GetComponentsInChildren<BuyButton>());
        UpdateButtonVisibility();
    }


    public void SpawnPrefab(float orbitalRadius, GameObject prefab, float orbitalRadiusVariance = 0f)
    {
        float radius = orbitalRadius + Random.Range(orbitalRadiusVariance * -1, orbitalRadiusVariance);
        Vector3 spawnPosition = GetRandomOrbitPosition(bubble.transform.position, radius);
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    void UpdateButtonVisibility()
    {
        foreach (var buyButton in buyButtons)
        {
            buyButton.gameObject.SetActive(Goo >= buyButton.gooCost);
        }
    }

    public Vector3 GetRandomOrbitPosition(Vector3 center, float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);

        // Calculate the position on the circle
        Vector3 orbitPosition = new Vector3(
            center.x + radius * Mathf.Cos(angle),
            center.y + radius * Mathf.Sin(angle),
            0f
        );

        return orbitPosition;
    }

}
