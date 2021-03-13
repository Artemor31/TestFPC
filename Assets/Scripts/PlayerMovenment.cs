using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovenment : MonoBehaviour
{
    private const float Gravitation = -9.8f;

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpPower = 100f;
    
    private CharacterController _characterController;
    private InputManager _input; 
    private Vector3 _velocity;

    private void Awake()
    {
        _input = FindObjectOfType<InputManager>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _input.OnJumpClicked += Jump;
    }
    
    private void Update()
    {
        Move();
        ApplyGravity();
    }

    private void Move()
    {
        if (!_input.IsMoving()) 
            return;
        
        var thisTransform = transform;
        var moveDirection = thisTransform.right * _input.MoveX + thisTransform.forward * _input.MoveY;
        _characterController.Move(Time.deltaTime * _speed * moveDirection);
    }

    private bool OnGround()
    {
        return Physics.Raycast(
            transform.position + Vector3.zero,
            Vector3.down, 
            0.05f);
    }

    private void ApplyGravity()
    {
        if (!OnGround())
        {
            _velocity.y += Gravitation * Time.deltaTime;
            _characterController.Move(Time.deltaTime * _velocity);
        }
        else
        {
            _velocity.y = 0;
        }
    }

    private void Jump()
    {
        if (!OnGround())
            return;

        _velocity.y = Mathf.Sqrt(_jumpPower * -2f * Gravitation);
    }
    
}