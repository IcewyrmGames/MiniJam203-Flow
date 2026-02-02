using Unity.VisualScripting;
using UnityEngine;

public class detect_deletion_clicked : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnEnable()
    {
        trigger_delete_components.OnDeleteButtonClicked += AutoDestroy;
        detect_objects_for_deletion.OnObjectTouchBoundaries += SingleDestroy;
    }

    void AutoDestroy()
    {
        if (this == null) return;
        if (this.gameObject != null)
        Destroy(this.gameObject);
    }

    void SingleDestroy(GameObject obj)
    {
        if (this == null) return;
        if (this.gameObject != null && obj.GetInstanceID() == this.gameObject.GetInstanceID())
        Destroy(this.gameObject);
    }
}
