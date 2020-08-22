using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleExampleController : MonoBehaviour {

    public Camera myCam;
    public List<Transform> targetPos;
    public List<Transform> lookAtPos;
    private int index = 0;

    void OnEnable()
    {
        why4Script.OnProceed += CyclePositionsForward;
        slideEventCallBack.OnSlideFinish += Resset;
        slideEventCallBack.OnSlideReverse += Resset;
    }
    void OnDisable()
    {
        why4Script.OnProceed -= CyclePositionsForward;
        slideEventCallBack.OnSlideFinish -= Resset;
        slideEventCallBack.OnSlideReverse -= Resset;

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        myCam.transform.position = Vector3.Lerp(myCam.transform.position, targetPos[index].position, 1 * Time.deltaTime);
        myCam.transform.LookAt(lookAtPos[index].position);
	}

    void CyclePositionsForward()
    {
        if(index < targetPos.Capacity - 1)
        index++;
    }
    void CyclePositionsBackward()
    {
        if(index > 0)
        index--;
    }
    void Resset()
    {
        index = 0;
    }
}
