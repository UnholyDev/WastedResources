using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prototyping : MonoBehaviour
{

    //Called before Start() and before OnEnable()
    //Best used for initializations or references to other scripts/objects
    void Awake()
    {
        Debug.Log("Awake");
    }

    //Called before Start(), and each time this script (or it's object) is enabled in a scene
    void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("Start");
    }

    //Called once every physics frame (approx every 0.02 seconds)
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }

    //Called when the gameobject is disabled in the scene
    void OnDisable()
    {
        Debug.Log("OnEnable");
    }
}
