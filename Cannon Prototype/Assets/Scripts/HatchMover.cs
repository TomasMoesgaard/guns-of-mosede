﻿using UnityEngine;
using System.Collections;

public class HatchMover : MonoBehaviour {

    public HingeJoint Handle;

    private Vector3 startPosistion;

	// Use this for initialization
	void Start () {

        startPosistion = transform.localPosition;

	}
	
	// Update is called once per frame
	void Update () {

       // Debug.Log(Utility.MapRange(Handle.angle, 0f, -90f, 0f, 0.3f));



        transform.localPosition = startPosistion + new Vector3(Utility.MapRange(Handle.angle, 0f, -90f, 0f, -0.31f), 0, 0);

	}
}
