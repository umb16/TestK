using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIValueText : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private string _stringFormat = "0.00";
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
            _valueText.text = value.ToString(_stringFormat);
            _oldValue = value;
        }
    }
}
