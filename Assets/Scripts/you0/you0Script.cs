using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class you0Script : slideEventCallBack {

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
            SlideFinish();
        else
            SlideReverse();
    }
}
