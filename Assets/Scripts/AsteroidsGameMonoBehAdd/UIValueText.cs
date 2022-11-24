using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIValueText : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private int _roundDigits = 2;
    private float _oldValue = float.PositiveInfinity;

    public void Show(float value = 0)
    {
        gameObject.SetActive(true);
        SetValue(value);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void SetValue(float value)
    {
        if (_oldValue != value)
        {
            _valueText.text = MathF.Round(value, _roundDigits).ToString();
            _oldValue = value;
        }
    }
}
