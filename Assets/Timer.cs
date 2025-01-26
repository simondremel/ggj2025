using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI label;

    public void UpdateLabel()
    {
        label.text = $"Time: {(int)GameManager.Instance.timePassed}s";
    }
}
