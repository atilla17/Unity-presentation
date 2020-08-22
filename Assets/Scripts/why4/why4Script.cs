using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class why4Script : slideEventCallBack {

    public delegate void ActionStage4();
    public static event ActionStage4 OnProceed;
    public static event ActionStage4 OnResset;
    bool done = false;
    
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

    protected override void CycleSlide(bool forward)
    {
        if (forward)
        {
            if (!done)
            {
                OnProceed();
                done = true;
                Debug.Log("1");
            }
            else
            {
                SlideFinish();
                Debug.Log("2");
            }
        }
        else
        {
            SlideReverse();
            Debug.Log("3");
            if(OnResset != null)
                OnResset();
            else
                Debug.Log("OnResset Empty");
            
        }
    }
}
