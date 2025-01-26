using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Injector : MonoBehaviour
{
    public Goolet gooletPrefab;
    public float gooAmount;

    public void Inject()
    {
        Goolet goolet = Instantiate(gooletPrefab, transform.position, transform.rotation);
        goolet.target = GameManager.Instance.bubble.transform;
        goolet.gooAmount = gooAmount;
        goolet.ignoreBubbleExit = true;
    }
}
