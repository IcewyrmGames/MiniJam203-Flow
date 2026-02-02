using System;s
using UnityEngine;

public class select_object_for_mana : MonoBehaviour
{
    public static event Action<GameObject> OnManaTypeSelect;

    void OnEnable()
    {
        if (OnManaTypeSelect != null)
        {
            OnManaTypeSelect(this.gameObject);
        }
    }
}
