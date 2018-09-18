using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubblesManager : MonoBehaviour {

    public ParticleSystem bubblesparticules;
    public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //print("mic: " + MicInput.MicLoudnessinDecibels);
        text.text = "mic: " + MicInput.MicLoudnessinDecibels;
        //bubblesparticules.enableEmission = true;
        if (MicInput.MicLoudnessinDecibels > -50)
        {
            //var em = bubblesparticules.emission;
            //em.enabled = true;
            bubblesparticules.enableEmission = true;
        }
        else
        {
            bubblesparticules.enableEmission = false;
        }

        
    }
}
