using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Gun gun;
    [SerializeField] private float interactDistance;

    private float xRotation;

    private Transform currentSelection;

    public bool canMove = false;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSelection == null)
        {
            FindObjectOfType<InteractTooltip>().HideInteractText();
        }
        if(canMove)
        {
            LookAround();
            ShootGun();
            SelectInteractables();
            InteractWithObject();
        }
    }

    private void FixedUpdate()
    {
        if(canMove)
        {
            Move();
        }
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
        //GetComponent<CharacterController>().Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        GetComponent<Rigidbody>().velocity = moveDirection * moveSpeed * Time.deltaTime;

    }

    private void SelectInteractables()
    {
        if(currentSelection != null)
        {
            currentSelection = null;
            FindObjectOfType<InteractTooltip>().HideInteractText();
        }

        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, interactDistance))
        {
            if(hit.transform.CompareTag("Selectable"))
            {
                currentSelection = hit.transform;
                FindObjectOfType<InteractTooltip>().ShowInteractText();
            }
        }
    }

    private void InteractWithObject()
    {
        if(Input.GetKeyDown(KeyCode.E) && currentSelection != null)
        {
            if(currentSelection.GetComponent<IInteractable>() != null)
            {
                currentSelection.GetComponent<IInteractable>().Interact();
                currentSelection = null;
                FindObjectOfType<InteractTooltip>().HideInteractText();
            }
        }
    }

    private void ShootGun()
    {
        if(Input.GetMouseButtonDown(0) && canMove == true)
        {
            gun.Shoot();
            FindObjectOfType<InteractTooltip>().HideInteractText();
        }
    }
}
