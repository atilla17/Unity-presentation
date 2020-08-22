using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Container for events for listening classes to reply to the main class
//and abtract methods for transitioning throgh slides in witch each slide may have its own logic
public abstract class slideEventCallBack : MonoBehaviour {

    public delegate void SlideEvent();

    //Called from the children of this class
    public static event SlideEvent OnSlideFinish;
    public static event SlideEvent OnSlideReverse;

    public string SlideName;

    protected void SlideFinish()
    {
        if (OnSlideFinish != null)
        {
            OnSlideFinish();
        }

        else
        {
            Debug.LogError("OnslideFinishEmpty");
        }
    }
    protected void SlideReverse()
    {
        if (OnSlideReverse != null)
        {
            OnSlideReverse();
        }
        else
        {
            Debug.LogError("OnSlideReverseEmpty");
        }
    }


    protected void Sub()
    {
        MainEventManager.OnMainEventSignalRequest += CycleSlide;
    }
    protected void Unsub()
    {
        MainEventManager.OnMainEventSignalRequest -= CycleSlide;
    }
    protected abstract void CycleSlide(bool forward);

}
