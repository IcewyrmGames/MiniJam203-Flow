using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class detect_mana_for_conversion : MonoBehaviour
{
    public static event Action<GameObject> OnManaTouch;
    public GameObject convert_to;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (OnManaTouch != null)
        {
            String other_name = other.gameObject.name;
            if (other_name == convert_to.name)
            {
                return;
            }
            OnManaTouch(other.gameObject);
        }
    }
}

