using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEventMessageSender : MonoBehaviour {

    public delegate void ActionSignal();
    public static event ActionSignal OnStartSignal;


    public void FncStartSignal()
    {
        OnStartSignal();
    }

}
