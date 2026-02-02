using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class detect_objects_for_deletion : MonoBehaviour
{
    public static event Action<GameObject> OnObjectTouchBoundaries;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (OnObjectTouchBoundaries != null)
        {
            OnObjectTouchBoundaries(other.gameObject);
        }
    }
}
