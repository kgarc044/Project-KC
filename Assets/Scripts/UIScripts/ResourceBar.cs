using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
    //private Resource re;
    /*public Image bar;
    public float regen;

    private void Start()
    {
        //bar.fillAmount = .5f;
        bar = transform.Find("Bar").GetComponent<Image>();
        //re = new Resource();
    }

    void Update()
    {
        if (!UIManager.gameIsPaused)
        {
            bar.fillAmount += regen;
        }
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
    }*/

    /*public float ReturnVal()
    {
        return bar.fillAmount;
    }

    void Update()
    {
        ReAmount += ReRegenAmount * Time.deltaTime;
    }*/
}
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
        public Resource(float amount, float regen)
        {
            ReAmount = amount;
            ReRegenAmount = regen;
        }

        public void Update()
        {
            ReAmount += ReRegenAmount;
            if (ReAmount > 1) ReAmount = 1;
        }

        public void SetRegen(float Regen)
        {
            ReRegenAmount = Regen;
        }

        public void SetResource(float Resource)
        {
            ReAmount = Resource;
        }

        public void Increase(float incriment)
        {
            ReAmount += incriment;
            if (ReAmount > 1) ReAmount = 1;
        }

        public void Decrease(float reduce)
        {
            ReAmount -= reduce;
            if (ReAmount < 0) ReAmount = 0;
        }

        public float ReturnResource() { return ReAmount; }
        public float ReturnRegen() { return ReRegenAmount; }
        /*public float GetNormalized()
        {
            return ReAmount / RE_MAX;
        }*/
    }


