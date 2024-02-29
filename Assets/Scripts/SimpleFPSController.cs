using System;
using UnityEngine;

public class SimpleFPSController : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    public float moveSpeed = 5.0f;

    private Camera playerCamera;
    private CharacterController characterController;

    public static event Action<WeaponData> InteractWeaponEvent;

    private float rotationX = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TryInteractWithWeapon();

        // Camera rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);

        // Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.forward * vertical) + (transform.right * horizontal);
        characterController.SimpleMove(moveDirection * moveSpeed);
    }


    void TryInteractWithWeapon()
    {
        // Perform a raycast to check for weapon pickups on the floor
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            var pickupData = hit.collider.GetComponent<Iinteractable>();
            if (pickupData != null)
                InteractWeaponEvent.Invoke(pickupData.GetWeaponData());
        }
    }
}
