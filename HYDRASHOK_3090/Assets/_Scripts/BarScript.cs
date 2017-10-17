using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript: MonoBehaviour
{
     private float fillAmount;

    [SerializeField] private float LerpSpeed;

    [SerializeField] private Image content;


    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }

    }

    // Update is called once per frame
    void Update ()
    {
        HandleBar();
	}

    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * LerpSpeed);
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        //      (curHP 80 - 0)     *    (1-0)       /    (100 - 0)      + 0
    }   //         80 * 1 / 100 = 0.8

}
