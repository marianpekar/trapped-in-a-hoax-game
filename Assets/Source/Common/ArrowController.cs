﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] 
    private float rotationSpeed = 3f;

    [SerializeField]
    private float bobAmount = 0.1f;

    [SerializeField]
    private float bobSpeed = 4f;

    [SerializeField]
    private Vector3 offset = new Vector3(0f, 4f, 0);


    private Transform playerTransform;

    void Start()
    {
        PlayerEvents.Instance.OnPlayerSelected += (transform) => playerTransform = transform;
    }

    void FixedUpdate()
    {
        transform.Rotate((transform.position - playerTransform.position).normalized, rotationSpeed, Space.World);
        transform.position = new Vector3(offset.x + playerTransform.position.x,
                                         offset.y + playerTransform.position.y + Mathf.Sin(Time.time * bobSpeed) * bobAmount, 
                                         offset.z + playerTransform.position.z);
    }
}
