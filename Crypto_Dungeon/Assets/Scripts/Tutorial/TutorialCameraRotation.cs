using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Sensivity")]
    [SerializeField] float mouseSensitivity = 100f;
    [Header("Zoom")]
    [SerializeField] float maxZoomDistance;
    [SerializeField] float smoothSpeed;
    [Header("Angles")]
    [SerializeField] float yMinMaxAngle;
    [SerializeField] float xMinMaxAngle;
    [SerializeField] Transform forwardTr;

    private float rotationY = 0f;
    private float rotationX = 0f;
    Vector3 startPos, targetPos;

    void Start()
    {
        startPos = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationY -= mouseY;
        rotationX += mouseX;

        rotationY = Mathf.Clamp(rotationY, -yMinMaxAngle, yMinMaxAngle); // Ограничение по вертикали
        rotationX = Mathf.Clamp(rotationX, -xMinMaxAngle, xMinMaxAngle); // Ограничение по горизонтали

        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);

        if (Input.GetKey(KeyCode.C))
        {
            if (targetPos == startPos)
                targetPos = transform.position + transform.forward * maxZoomDistance;
        }
        else
        {
            targetPos = startPos;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
    }
}
