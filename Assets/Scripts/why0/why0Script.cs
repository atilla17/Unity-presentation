using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class why0Script : slideEventCallBack {

    public delegate void OutMessage();
    public static event OutMessage OnMoneyStart;
    public static event OutMessage OnMoneyStop;


    [SerializeField]
    public Text moneyText;
    [SerializeField]
    public Color targetColor;

    public Text text1;

    public Text text2;

    uint dollars = 0;
    int index = 0;
    bool countStarted = false;

    RectTransform newTarget;

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
        newTarget = text2.GetComponent<RectTransform>();
        //text2.GetComponent<RectTransform>().position = moneyText.GetComponent<RectTransform>().position;       
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void CycleSlide(bool forward)
    {
        if (forward)
        {
            if(countStarted && dollars < 260000000)
            {
                dollars = 260000000;
                moneyText.text = dollars.ToString("c");
                OnMoneyStop();
            }
            else if (index < 2)
            {
                countStarted = true;
                ActionSelect(index);
                index++;
                OnMoneyStart();
            }
            else
            {
                SlideFinish();
            }
        }
        else
            SlideReverse();
    }

    void ActionSelect(int arg)
    {
        switch (arg) {
            case 0:
                StartCoroutine(numberEffect1(260000000));
                break;
            case 1:
                StartCoroutine(numberEffect2(1500000000)); 
                break;

                    }
    }

    IEnumerator numberEffect1(uint target)
    {
        text1.enabled = true;
        moneyText.enabled = true;
        dollars++;
        while(dollars < target)
        {
            if (dollars < 9)
                dollars += 1;
            else if (dollars < 90)
                dollars += 100;
            else if (dollars < 9000)
                dollars += 1000;
            else
                dollars += 100000;

            moneyText.text = dollars.ToString("c");
            yield return new WaitForSeconds(0.000001f);
        }
        if (dollars > target)
        {
            dollars = target;
            moneyText.text = dollars.ToString("c");
        }
        OnMoneyStop();
        yield break;
    }

    IEnumerator numberEffect2(uint target)
    {
        dollars++;
        while (dollars < target)
        {
            dollars += 10000000;
            text2.text = dollars.ToString("c");

            float setC = dollars / target;
            text2.color = Color.Lerp(text2.color, targetColor, setC);
            yield return new WaitForSeconds(0.000001f);

        }
        if (dollars > target)
        {
            dollars = target;
            text2.text = dollars.ToString("c");
        }
        OnMoneyStop();
        yield break;
    }

     IEnumerator textTrans()
    {
        //move
        RectTransform myTrans = text2.GetComponent<RectTransform>();
        Vector3 myPos = myTrans.position;
        Vector3 targetPos = newTarget.position;
        while(myPos != targetPos)
        {
           myPos = Vector3.Lerp(myPos, targetPos, 0.1f );
            text2.GetComponent<RectTransform>().position = myPos;

        }
        //Blink

        //countdown
        StartCoroutine(numberEffect2(1500000000));
        yield break;
    }


    void Resset()
    {
        //resset this slide
    }

}


