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

    private Dictionary<string, int> itemCount = new();

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
        itemCount["Injector"] = 0;
        itemCount["Extractor"] = 0;

        buyButtons = new(buttonContainer.GetComponentsInChildren<BuyButton>());
        timePassed = 0;
        UpdateButtonVisibility();
        productionTargetLabel.text = $"Production Target: {productionTarget}";
    }


    public void SpawnPrefab(float orbitalRadius, GameObject prefab, float orbitalRadiusVariance = 0f)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);

        float radius = orbitalRadius + Random.Range(orbitalRadiusVariance * -1, orbitalRadiusVariance);
        Vector3 spawnPosition = GetOrbitPosition(angle, bubble.transform.position, radius * 3);
        GameObject instance = Instantiate(prefab, spawnPosition, Quaternion.identity);
        WarpDrive warpDrive = instance.GetComponent<WarpDrive>();
        warpDrive.targetPosition = GetOrbitPosition(angle, bubble.transform.position, radius);
        warpDrive.Engage();
    }


    [SerializeField] TextMeshProUGUI injectorCounter;
    [SerializeField] TextMeshProUGUI extractorCounter;
    public void AddItem(string itemName)
    {
        if (!itemCount.ContainsKey(itemName))
        {
            itemCount[itemName] = 0;
        }

        itemCount[itemName]++;

        injectorCounter.text = itemCount["Injector"].ToString() + (itemCount["Injector"] == 1 ? " Injector" : " Injectors");
        //injectorCounter.gameObject.SetActive(itemCount["Injector"] > 0);

        extractorCounter.text = itemCount["Extractor"].ToString() + (itemCount["Extractor"] == 1 ? " Extractor" : " Extractors");
        //extractorCounter.gameObject.SetActive(itemCount["Extractor"] > 0);
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

    public Vector3 GetOrbitPosition(float angle, Vector3 center, float radius)
    {
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
