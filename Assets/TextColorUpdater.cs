using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextColorUpdater : MonoBehaviour
{
    public Color enabledColor;
    public Color disabledColor;
    public TextMeshProUGUI buttonText;

    public void UpdateTextColor(bool enabled)
    {
        buttonText.color = enabled ? enabledColor : disabledColor;
    }
}
