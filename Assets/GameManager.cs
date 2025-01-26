using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : SingletonComponent<GameManager>
{
    [SerializeField] TextMeshProUGUI gooCounter;
    public Bubble bubble;
    public Transform buttonContainer;

    public float timePassed;
    public int productionTarget;

    [SerializeField] TextMeshProUGUI productionTargetLabel;

    private List<BuyButton> buyButtons;

    private int goo;
    public int Goo
    {
        set
        {
            goo = value;
            gooCounter.text = $"{goo}";
            UpdateButtonVisibility();
            if (goo > productionTarget) Victory();
        }
        get
        {
            return goo;
        }
    }

    private void Start()
    {
        buyButtons = new(buttonContainer.GetComponentsInChildren<BuyButton>());
        timePassed = 0;
        UpdateButtonVisibility();
        productionTargetLabel.text = $"Production Target: {productionTarget}";
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
            if (buyButton.GooCost <= Goo)
            {
                buyButton.unlocked = true;
                buyButton.gameObject.SetActive(true);
                buyButton.GetComponent<Button>().interactable = true;
                buyButton.GetComponent<TextColorUpdater>().UpdateTextColor(true);
            }
            else
            {
                buyButton.gameObject.SetActive(buyButton.unlocked);
                buyButton.GetComponent<Button>().interactable = false;
                buyButton.GetComponent<TextColorUpdater>().UpdateTextColor(false);
            }
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

    private void Update()
    {
        timePassed += Time.deltaTime;
    }

    public Popup gameOverHeat;
    public Popup gameOverCold;
    public Popup victory;

    public void Victory()
    {
        Time.timeScale = 0;
        victory.Show();
        victory.GetComponent<Timer>().UpdateLabel();
    }

    public void GameOverHeat()
    {
        gameOverHeat.Show();
    }

    public void GameOverCold()
    {
        gameOverCold.Show();
    }

}
