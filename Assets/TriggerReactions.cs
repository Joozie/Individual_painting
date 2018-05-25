using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReactions : MonoBehaviour {

    public GameObject chair;
    public GameObject oilLamp;

    private Vector3 lastLocationChair;
    private Vector3 currentLocationChair;

    private Vector3 lastLocationOilLamp;
    private Vector3 currentLocationOilLamp;


    private int nextUpdate = 1;

    // Use this for initialization
    void Start () {
        lastLocationChair = chair.transform.position;
        lastLocationOilLamp = oilLamp.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextUpdate) {
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }
    }

    void UpdateEverySecond() {
        currentLocationChair = chair.transform.position;
        currentLocationOilLamp = oilLamp.transform.position;

        bool movedChair = checkMovement(currentLocationChair, lastLocationChair);
        bool movedLamp = checkMovement(currentLocationOilLamp, lastLocationOilLamp);

        lastLocationChair = currentLocationChair;
        lastLocationOilLamp = currentLocationOilLamp;
    }

    bool checkMovement(Vector3 current, Vector3 last) {
        float dist = Vector3.Distance(current, last);
        float angle = Vector3.Angle(current, last);

        return (dist > 0.5 || angle > 0.5);
    }
}
