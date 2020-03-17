using UnityEngine.EventSystems;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.back, -rotX);
    }
}
