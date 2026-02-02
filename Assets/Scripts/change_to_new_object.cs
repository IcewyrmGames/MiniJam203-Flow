using UnityEngine;

public class change_to_new_object : MonoBehaviour
{

    void OnEnable()
    {
        detect_mana_for_conversion.OnManaTouch += ChangeToNewObject;
    }

    void ChangeToNewObject(GameObject obj)
    {
        if (obj.GetInstanceID() == this.gameObject.GetInstanceID())
        {
            GameObject new_object = Instantiate(Resources.Load<GameObject>("component"));
            new_object.transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
            new_object.GetComponent<Rigidbody2D>().linearVelocity = this.GetComponent<Rigidbody2D>().linearVelocity;
            new_object = null;
            Destroy(this.gameObject);
        }
    }
}
