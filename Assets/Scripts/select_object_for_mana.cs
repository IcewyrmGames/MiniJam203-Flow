using System;
using UnityEngine;

public class select_object_for_mana : MonoBehaviour
{
    public static event Action<GameObject> OnManaTypeSelect;
    public GameObject prefabToSpawn;

    void OnEnable()
    {

    }

    public void OnClick()
    {
        if (OnManaTypeSelect != null)
        {
            OnManaTypeSelect(prefabToSpawn);
        }
    }
}
