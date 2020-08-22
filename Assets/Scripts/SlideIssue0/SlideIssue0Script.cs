using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideIssue0Script : slideEventCallBack {

    public Image image1;
    public Image image2;

    public Text text1;
    public Text text2;
    public Text text3;

    public string Message1;
    public string Message2;
    public string Message3;

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
    void Start () {

        StartCoroutine(textWriter(Message1, text1));
    }
	
	// Update is called once per frame
	void Update () {
		
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
        switch(pos)
        {
            case 0:
                StartCoroutine(textWriter(Message2, text2));
                StartCoroutine(textWriter(Message3, text3));
                pos++;
            break;
            case 1:
                SlideFinish();
                break;
        }
    }

    IEnumerator textWriter (string write, Text to)
    {
        int i = 0;
        while(i <write.Length)
        {
            to.text += write[i];
            i++;
            yield return new WaitForSeconds(0.05f);
        }

        yield break;
    }
}
