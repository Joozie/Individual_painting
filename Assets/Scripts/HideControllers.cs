using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideControllers : MonoBehaviour {

    public GameObject left, right;

    public Renderer[] renderers;



    // Use this for initialization
    void Start () {
        renderers = new Renderer[] { left.GetComponent<Renderer>(), right.GetComponent<Renderer>() };
        hideThem();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void hideThem() {
        for (int i = 0; i < renderers.Length; i++) {
            if (renderers[i].material.name == "Standard (Instance)") {
                renderers[i].enabled = false;
            }
        }
    }

}
