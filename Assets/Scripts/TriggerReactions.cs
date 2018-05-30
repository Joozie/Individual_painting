using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReactions : MonoBehaviour
{

	public AudioClip chairClip;
	public AudioClip chairClip2;

	public AudioClip lampClip;
	public AudioClip lampClip2;

	public GameObject chair;
	public GameObject oilLamp;

	private Vector3 lastLocationChair;
	private Vector3 currentLocationChair;

	private Vector3 lastLocationOilLamp;
	private Vector3 currentLocationOilLamp;

	public AudioSource source;
	private float vol;

	private int secLeftSound = 0;

	private int nextUpdate = 1;

	// Use this for initialization
	void Start ()
	{
		lastLocationChair = chair.transform.position;
		lastLocationOilLamp = oilLamp.transform.position;

		source = GetComponent<AudioSource> ();
		vol = Random.Range (.5f, 1.0f);

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time >= nextUpdate) {
			nextUpdate = Mathf.FloorToInt (Time.time) + 1;
			UpdateEverySecond ();
			soundsLeftPlaying ();
		}
	}

	void UpdateEverySecond ()
	{
		currentLocationChair = chair.transform.position;
		currentLocationOilLamp = oilLamp.transform.position;

		bool movedChair = checkMovement (currentLocationChair, lastLocationChair);
		bool movedLamp = checkMovement (currentLocationOilLamp, lastLocationOilLamp);

		if (movedChair) {
			chairTriggered ();
		}
		if (movedLamp) {
			lampTriggered ();
		}

		lastLocationChair = currentLocationChair;
		lastLocationOilLamp = currentLocationOilLamp;
	}

	bool checkMovement (Vector3 current, Vector3 last)
	{
		float dist = Vector3.Distance (current, last);
		float angle = Vector3.Angle (current, last);

		return (dist > 0.5 || angle > 0.5);
	}


	void chairTriggered ()
	{
		if (Random.value > 0.5) {
			playSound (chairClip);
		} else {
			playSound (chairClip2);
		}
	}

	void lampTriggered ()
	{
		if (Random.value > 0.5) {
			playSound (lampClip);
		} else {
			playSound (lampClip2);
		}
 	}

	void soundsLeftPlaying ()
	{
		if (secLeftSound > 0) {
			secLeftSound = secLeftSound - 1;
		}
	}

	void playSound (AudioClip clip)
	{
		if (source != null) {
			if (source.isPlaying && secLeftSound < 5) {
				source.PlayDelayed (secLeftSound);
			} else if (!source.isPlaying) {
				source.PlayOneShot (clip, vol);
			}
		}
	}
}
