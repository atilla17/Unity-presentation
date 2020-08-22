using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour {

    void Awake()
    {
        Debug.Log("Im alive");
    }



    void OnMouseDown()
    {
        Debug.Log("wooop");
    }
}
