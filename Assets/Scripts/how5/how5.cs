using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class how5 : slideEventCallBack {

    public Text moneyText;

    uint dollars = 1500000000;
    int pos = 0;
    // Use this for initialization
    void OnEnable()
    {
        Sub();
    }
    void OnDisable()
    {
        Unsub();
    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    protected override void CycleSlide(bool forward)
    {
        if (forward)
            selectAction();
        else
            SlideReverse();
    }

    void selectAction()
    {
        switch (pos)
        {
            case 0:
                StartCoroutine(numberEffect2(63000000));
                pos++;
                break;
            case 1:
                SlideFinish();
                break;
        }
    }

    IEnumerator numberEffect2(uint target )
    {
        while (dollars > target)
        {
            dollars -= 10000000;
            moneyText.text = dollars.ToString("c");

            yield return new WaitForSeconds(0.000001f);
        }
        if (dollars < target)
        {
            dollars = target;
            moneyText.text = dollars.ToString("c");
        }
        yield break;
    }
}



