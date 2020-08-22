using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeParticleController : MonoBehaviour {


    ParticleSystem myParticle;
    // Use this for initialization

    void OnEnable()
    {
        HomeLogoSploosh.OnSplooshReady += StartEffect;
        HomeLogoSploosh.OnSlideFinish += StopEffect;
    }
    void OnDisable()
    {
        HomeLogoSploosh.OnSplooshReady -= StartEffect;
        HomeLogoSploosh.OnSlideFinish -= StopEffect;
    }

    void Start () {
        myParticle = transform.GetComponent<ParticleSystem>();
	}
	
	void StartEffect()
    {
        myParticle.Play();
    }
    void StopEffect()
    {
        //myParticle.Stop();
    }
}
