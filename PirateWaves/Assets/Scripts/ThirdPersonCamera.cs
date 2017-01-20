﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    #region Fields/Properties

    public GameObject Target;
    public float DistanceFromTarget = 5.0f;
    public float OffsetY;
    public float SlerpSpeed = 1;

    private Vector3 _offset;
    private Vector3 _offsetY;

    #endregion

    #region Events

    // Use this for initialization
    void Start ()
    {
        

        transform.position = Target.transform.position - Target.transform.forward * DistanceFromTarget;              
        //transform.rotation = Quaternion.Euler(0, Target.transform.rotation.eulerAngles.y, 0);

        _offset = transform.position - Target.transform.position;
        _offsetY = new Vector3(0, OffsetY, 0);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void LateUpdate()
    {
        var newRotationY = Quaternion.AngleAxis(Target.transform.rotation.eulerAngles.y, Vector3.up);
        var newPosition = newRotationY * _offset + Target.transform.position + _offsetY;

        //Vector3.Slerp(transform.position, Target.transform.position, Time.deltaTime * SlerpSpeed) :
        //transform.position = _offset + Target.transform.position + _offsetY;
        transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime* SlerpSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotationY, Time.deltaTime* SlerpSpeed);
    }

    #endregion
}
