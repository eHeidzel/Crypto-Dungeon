using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;


    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0, rotationY;

    public bool CanMove = true;


    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;

        if (!CanMove)
        {
            moveDirection.x = 0;
            moveDirection.z = 0;
            characterController.Move(moveDirection * Time.deltaTime);
            return;
        }

        #region Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = CanMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = CanMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Jumping
        if (Input.GetButton("Jump") && CanMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

		#endregion

		characterController.Move(moveDirection * Time.deltaTime);

		#region Handles Rotation

		if (CanMove)
        {
			float mouseX = Input.GetAxis("Mouse X");
			float mouseY = Input.GetAxis("Mouse Y");
        
			rotationX += -mouseY * lookSpeed;
            rotationY += mouseX * lookSpeed;
			rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

			transform.rotation *= Quaternion.Euler(0, mouseX * lookSpeed, 0);

			playerCamera.transform.localRotation = 
                Quaternion.Euler(0, rotationY, 0) * 
                Quaternion.Euler(rotationX, 0, 0);
		}

        #endregion
    }

    public void AddPlayerCameraRotation(Quaternion rotation)
    {
        playerCamera.transform.localRotation *= rotation;
    }
}