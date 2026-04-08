using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    private InputSystem_Actions _actions;
    
    public event Action FirePressed;
    public Vector2 LookPosition => _actions.Player.Look.ReadValue<Vector2>();

    private void Awake()
    {
        _actions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _actions.Enable();
        _actions.Player.Attack.performed += OnAttack;
    }

    private void OnDisable()
    {
        _actions.Disable();
        _actions.Player.Attack.performed -= OnAttack;
    }
    
    private void OnAttack(InputAction.CallbackContext obj)
    {
        FirePressed?.Invoke();
    }
}
