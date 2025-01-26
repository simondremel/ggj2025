using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extractor : MonoBehaviour
{
    private Vector3 bubbleCenter;
    public GameObject gooletPrefab;
    public float extractionSpeed;
    public float extractionAmount;

    // Start is called before the first frame update
    void Start()
    {
        bubbleCenter = GameManager.Instance.bubble.transform.position;
    }

    public void StartSucking()
    {
        Goolet goolet = Instantiate(gooletPrefab, bubbleCenter, Quaternion.identity).GetComponent<Goolet>();
        goolet.target = transform;
        goolet.speed = extractionSpeed;
        goolet.gooAmount = extractionAmount;
        goolet.ignoreBubbleEnter = true;
    }

    public void Collect()
    {
        GameManager.Instance.Goo++;
    }
}
