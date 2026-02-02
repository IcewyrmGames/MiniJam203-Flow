using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class detect_objects : MonoBehaviour
{
    public Dictionary<String, int> objects = new Dictionary<string, int>();
    public static event Action<detect_objects> OnIngredientAdd;

    void OnTriggerEnter2D(Collider2D other)
    {
        String obj_name = other.name.Split(" ")[0];
        AddObjectToDict(obj_name);
        if (OnIngredientAdd != null)
        {
            OnIngredientAdd(this);
        }
        Debug.Log(display_objects(objects));
    }

    void OnTriggerExit2D(Collider2D other)
    {
        String obj_name = other.name.Split(" ")[0];
        RemoveObjectFromDict(obj_name);

    }

    String display_objects(Dictionary<String, int> objList)
    {
        String log_objects = "";
        foreach (String key in objects.Keys)
        {
            log_objects += $"({key} {objList[key]}) ";
        }
        return log_objects;
    }

    private void AddObjectToDict(String obj)
    {
        if (objects.Keys.Contains(obj))
        {
            objects[obj] += 1;
        }
        else
        {
            objects[obj] = 1;
        }
    }

    private void RemoveObjectFromDict(String obj)
    {
        if (objects.Keys.Contains(obj))
        {
            if (objects[obj] == 1)
            {
                objects.Remove(obj);
            }
            else
            {
                objects[obj] -= 1;
            }
        }
        // We don't care if an object that didn't exist was removed
    }

}
