using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [Header("Input Settings")]
    PlayerControls controls;
    
    public  Vector2 Move {get; private set;}

    public event Action JumpPressed, JumpReleased, DashPressed, GrapplePressed, GrappleReleased;

    void Awake() => controls =  new PlayerControls();

    void OnEnable()
    {
        var c = controls.Gameplay;
        c.Enable();
        c.Jump.started += OnJumpStarted;
        c.Jump.canceled += OnJumpCanceled;
        c.Dash.started += OnDashStarted;
        c.Grapple.started += OnGrappleStarted;
        c.Grapple.canceled += OnGrappleCanceled;
    }

    void OnDisable()
    {
        var c = controls.Gameplay;
        c.Disable();
        c.Jump.started -= OnJumpStarted;
        c.Jump.canceled -= OnJumpCanceled;
        c.Dash.started -= OnDashStarted;
        c.Grapple.started -= OnGrappleStarted;
        c.Grapple.canceled -= OnGrappleCanceled;
    }

    void Update() => Move = controls.Gameplay.Move.ReadValue<Vector2>();
    
    void OnJumpStarted(InputAction.CallbackContext _)
    {
        JumpPressed?.Invoke();
        Debug.Log("Jump Pressed");
    } //=> JumpPressed?.Invoke();
    void OnJumpCanceled(InputAction.CallbackContext _) => JumpReleased?.Invoke();
    void OnDashStarted(InputAction.CallbackContext _) => DashPressed?.Invoke();
    void OnGrappleStarted(InputAction.CallbackContext _) => GrapplePressed?.Invoke();
    void OnGrappleCanceled(InputAction.CallbackContext _) => GrappleReleased?.Invoke();
}
