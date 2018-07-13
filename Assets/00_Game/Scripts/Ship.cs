﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    #region singleton
    private static Ship instance;
    public static Ship Get()
    {
        return instance;
    }
    public virtual void Awake()
    {
        if (instance == null)
        {
            GameManager.Get().SetShip(this.gameObject);
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public float speed = 10;
    public float rotationSpeed = 10;
    public float angle;
    public float fuel;
    public float timerFuel;
    public const int fuelControl = 2;
    public const int MAX_FUEL = 100;
    private GameObject planetTouched;

    private void Start()
    {
        fuel = MAX_FUEL;
        Debug.Log("shipholi");
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal * speed, 0, vertical * speed);

        Vector3 lastPosition = transform.position;

        Vector3 newPosition = transform.position + movement * Time.deltaTime;

        float newAngleY = GetRealAngle(lastPosition, newPosition);

        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = Quaternion.Slerp(currentRotation, Quaternion.AngleAxis(newAngleY, Vector3.up),
            rotationSpeed * Time.deltaTime);

        transform.position = newPosition;
        if (horizontal != 0 || vertical != 0)
        {
            angle = newAngleY;
            transform.rotation = newRotation;
        }

        FuelControl(movement);

    }

    private void FuelControl(Vector3 movement)
    {
        if (movement != Vector3.zero)
        {
            timerFuel += Time.deltaTime;
            if (timerFuel > fuelControl)
            {
                timerFuel = 0;
                fuel--;
            }
        }
    }

    private float GetRealAngle(Vector3 from, Vector3 to)
    {
        Vector3 right = Vector3.right;

        Vector3 dir = to - from;

        float angleBtw = Vector3.Angle(right, dir);
        Vector3 cross = Vector3.Cross(right, dir);
        if (cross.y < 0)
        {
            angleBtw = 360 - angleBtw;
        }

        return angleBtw;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Planet")
        {
            planetTouched = other.transform.gameObject;
            GameManager.Get().ShipOnPlanet();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Planet")
        {
            GameManager.Get().ShipOffPlanet();
        }
    }
    public GameObject GetLastPlanetTouched()
    {
        return planetTouched;
    }

    public float GetFuel()
    {
        return fuel;
    }

    public int GetMaxFuel()
    {
        return MAX_FUEL;
    }

}