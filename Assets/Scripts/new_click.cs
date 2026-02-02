using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class click : MonoBehaviour
{

    [SerializeField]
    private InputAction mouseClick;

    [SerializeField]
    private float mouseDragPhysicsSpeed = 10;
    [SerializeField]
    private float mouseDragSpeed = .1f;

    private Camera mainCamera;
    private Vector2 velocity = Vector2.zero;
    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        mouseClick.Enable();
        mouseClick.performed += MousePressed;
    }
    private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        mouseClick.Disable();
    }
    private void MousePressed(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        if (hit2D.collider != null && hit2D.collider.gameObject.CompareTag("Draggable"))
        {
            StartCoroutine(DragUpdate(hit2D.collider.gameObject));
        }

    }

    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        float initialDistance = Vector2.Distance(clickedObject.transform.position, mainCamera.transform.position);
        clickedObject.TryGetComponent<Rigidbody2D>(out var rb);
        while (mouseClick.ReadValue<float>() != 0)
        {
            Vector3 ray = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            if (rb != null)
            {
                Vector2 direction = ray - clickedObject.transform.position;
                rb.linearVelocity = direction * mouseDragPhysicsSpeed;
                yield return waitForFixedUpdate;
            }
            else
            {
                clickedObject.transform.position = Vector2.SmoothDamp(clickedObject.transform.position, ray, ref velocity, mouseDragSpeed);
                yield return null;
            }
        }
    }
}
