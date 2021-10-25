using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Camera playerCamera;

    private float xRotation;

    private Transform currentSelection;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        Move();
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotate camera to make it look up or down based on vertical mouse movement
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //Rotate player based on horizontal mouse movement
        transform.Rotate(Vector3.up * mouseX);
    }

    private void Move()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = xMove * transform.right + zMove * transform.forward;
        GetComponent<CharacterController>().Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
    }
}
