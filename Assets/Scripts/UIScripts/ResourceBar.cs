using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
    private Resource re;
    public Image bar;
    public float regen;

    private void Start()
    {
        //bar = transform.Find("Manabar").GetComponent<Image>();
        //bar.fillAmount = .3f;
        re = new Resource();
    }

    private void update()
    {
        bar.fillAmount += regen;
    }

    public void SetSize(float currentSize)
    {
        bar = transform.Find("Bar").GetComponent<Image>();
        bar.fillAmount = currentSize;
    }

    public void SetRegen(float RegenNum)
    {
        regen = RegenNum;
    }

    public void Increase(float incriment)
    {
        bar.fillAmount += incriment;
    }

    public void Decrease(float reduce)
    {
        bar.fillAmount -= reduce;
    }

    public float ReturnVal()
    {
        return bar.fillAmount;
    }

    /*public void Update()
    {
        ReAmount += ReRegenAmount * Time.deltaTime;
    }*/

    public class Resource
    {
        public const int RE_MAX = 100;

        private float ReAmount;
        private float ReRegenAmount;

        public Resource()
        {
            ReAmount = 100;
            ReRegenAmount = 0;
        }

        public void Update()
        {
            ReAmount += ReRegenAmount * Time.deltaTime;
        }

        public void SetRegen(float RegenNum)
        {
            ReRegenAmount = RegenNum;
        }

        public float GetNormalized()
        {
            return ReAmount / RE_MAX;
        }
    }

}
