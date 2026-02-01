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
    }

    void AutoDestroy()
    {
        Destroy(this.gameObject);
    }
}
