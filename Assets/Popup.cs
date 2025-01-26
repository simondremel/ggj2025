using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject darkenBackground;

    public void Show()
    {
        darkenBackground.SetActive(true);
    }
}
