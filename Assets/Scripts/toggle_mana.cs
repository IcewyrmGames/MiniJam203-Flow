using System;
using UnityEngine;

public class toggle_mana : MonoBehaviour
{

    public static event Action<bool> OnManaFlowClicked;
    private bool lowered = false;

    void OnEnable()
    {
        if (OnManaFlowClicked != null)
        {
            OnManaFlowClicked(lowered);
        }
    }

    public void LeverClicked()
    {
        lowered = !lowered;
        Vector2 pos = this.transform.position;
        if (!lowered)
        {
            pos.y += 0.5f;
        }
        else
        {
            pos.y -= 0.5f;
        }
        this.transform.position = pos;

        if (OnManaFlowClicked != null)
        {
            OnManaFlowClicked(lowered);
        }



    }
}
