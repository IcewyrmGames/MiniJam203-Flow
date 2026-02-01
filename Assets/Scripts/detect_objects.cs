using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class detect_objects : MonoBehaviour
{
    List<String> objects = new List<string>();


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
        Debug.Log("TRIGGERED");
        Debug.Log(other.name);
        objects.Add(other.name);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        objects.Remove(other.name);
        String log_objects = "";
        foreach (String item in objects)
        {
            log_objects += ',' + item;
        }
        Debug.Log(log_objects);
    }

}
