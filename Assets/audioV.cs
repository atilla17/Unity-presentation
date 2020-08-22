using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioV : MonoBehaviour {

    public AudioSource mySource;
    public List<Image> bars;
    public int visualizerSimples = 64;
    float[] sampleA;

    // Use this for initialization
    void Start () {
        sampleA = new float[5];
	}
	
	// Update is called once per frame
	void Update () {

        float[] spectrumData;// = mySource.GetSpectrumData(visualizerSimples, 0, FFTWindow.Rectangular);
        mySource.GetSpectrumData(sampleA , 5, FFTWindow.Rectangular);
        for (int i = 0; i< bars.Capacity; i++)
        {
            float fillamt = sampleA[i] * 3f;
            bars[i].fillAmount = Mathf.Lerp(bars[i].fillAmount, fillamt, 5 * Time.deltaTime);
        }
	}
}
