using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using R3;
using R3.Triggers;
using System;

/// <summary>
/// 
/// </summary>
public class Opening_ : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text_percent;
    IDisposable disposable;

    
    public Button myButton;
    private void Start()
    {
        disposable=slider.OnValueChangedAsObservable()
            .Subscribe(_ => {
                float num=_ * 100;
                int a = (int)num;
                text_percent.text = a.ToString();

                //
                if (a==100){
                    myButton.interactable = true;
                    disposable?.Dispose();
                }
                else
                {
                    myButton.interactable = false;
                }
            }).AddTo(this);
    }
}
