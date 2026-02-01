using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class trigger_delete_components : MonoBehaviour
{

    public static event Action OnDeleteButtonClicked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TaskOnClick()
    {
        Debug.Log("CLick");
        if (OnDeleteButtonClicked != null)
        {
            OnDeleteButtonClicked();
        }
    }
}
