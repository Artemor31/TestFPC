using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;

    private float _verticalRotation; 
    private InputManager _input; 

    private void Awake()
    {
        _input = FindObjectOfType<InputManager>();
        _playerBody = GetComponentInParent<Transform>().parent.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _verticalRotation -= _input.MouseY;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -90, 90);
        
        transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * _input.MouseX);
    }
}