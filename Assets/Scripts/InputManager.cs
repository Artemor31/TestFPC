using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 10f;

    public event Action OnJumpClicked;
    public float MouseX { private set; get;}
    public float MouseY { private set; get;}
    public float MoveX { private set; get;}
    public float MoveY { private set; get;}


    private void Update()
    {
        ListenInput();
    }

    private void ListenInput()
    {
        MouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
            OnJumpClicked?.Invoke();
    }

    public bool IsMoving()
    {
        return MoveX != 0 || MoveY != 0;
    }
}
