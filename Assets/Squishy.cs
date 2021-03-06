﻿using UnityEngine;
using System.Collections;

public class Squishy : MonoBehaviour {

	public GameObject splat;
	public bool isGuard = false;

	public void Squish() {
		if (isGuard)
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<PointsTracker> ().guardsKilled++;
		else
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<PointsTracker> ().civiliansKilled++;
		splat = Instantiate (splat);
		Vector3 splatPosition = transform.position;
		splatPosition.y = 0.01f;
		splat.transform.position = splatPosition;
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<Screams> ().Scream (transform.position);
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.GetComponent<Heavy> ())
			Squish ();
	}
}
