using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private float Amount { get; set; } = 0;
    public float Max { get; set; }

    [SerializeField]
    private Image _mask;
    [SerializeField]
    private Image _fill;

    public void SetMax(float max)
    {
        Max = max;
        UpdateDisplay(Amount);
    }

    public void UpdateAmount(float amount)
    {
        Amount = amount;
        UpdateDisplay(Amount);
    }

    private void UpdateDisplay(float amount)
    {
        float fill = (float)amount / Max;
        _mask.fillAmount = fill;
    }
}
