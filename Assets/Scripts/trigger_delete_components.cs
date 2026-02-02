using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class trigger_delete_components : MonoBehaviour
{

    public static event Action OnDeleteButtonClicked;

    public void TaskOnClick()
    {
        Debug.Log("CLick");
        if (OnDeleteButtonClicked != null)
        {
            OnDeleteButtonClicked();
        }
    }
}
