using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    private PlayerInput playerInput;

    private Vector2 movementInput = Vector2.zero;
    private Vector3 movementInput3D = Vector3.zero;
    private bool isMovementPressed;

    private void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.CharacterControls.Move.started += OnMovementInput;
        playerInput.CharacterControls.Move.canceled += OnMovementInput;
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        movementInput3D.x = movementInput.x;
        movementInput3D.z = movementInput.y;

        isMovementPressed = movementInput.x != 0 || movementInput.y != 0;
    }

    private void Update()
    {
        if (!isMovementPressed) return;

        playerController.Move(movementInput3D * Time.deltaTime);
    }

    private void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }
}
