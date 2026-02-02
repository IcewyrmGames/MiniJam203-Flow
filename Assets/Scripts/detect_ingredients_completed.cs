using System;
using System.Collections.Generic;
using UnityEngine;

public class detect_ingredients_completed : MonoBehaviour
{

    Dictionary<String, int> required_objects = new Dictionary<String, int> { { "OBJ_component_10_0", 1 }, { "OBJ_component_014_0", 2 } };

    void OnEnable()
    {
        detect_objects.OnIngredientAdd += ShowWin;
    }

    void OnDisable()
    {
        detect_objects.OnIngredientAdd -= ShowWin;
    }

    private void ShowWin(detect_objects detection)
    {
        if (compareObjectList(detection.objects))
        {
            transform.position = Vector2.zero;
        }
    }

    private bool compareObjectList(Dictionary<String, int> toCompare)
    {
        foreach (String item in required_objects.Keys)
        {
            if (!toCompare.ContainsKey(item))
            {
                return false;
            }
            else if (toCompare[item] != required_objects[item])
            {
                return false;
            }

        }
        return true;

    }

}
