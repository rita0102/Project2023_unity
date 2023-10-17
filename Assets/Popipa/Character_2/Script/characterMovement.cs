using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _damping = 0.1f;

    private Vector2 _moveInput;
    private Vector2 _smoothMovement;
    private Vector2 _smoothVelocity;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    
    private void SetMoveInput()
    {
        //smooth the  movement
        _smoothMovement = Vector2.SmoothDamp(_smoothMovement, _moveInput, ref _smoothVelocity, 0.5f);
        _rigidbody.velocity = _moveInput * _speed;
    }

    private void SetLookDirection()
    {
        if (_moveInput == Vector2.zero)
        {
            _animator.SetBool("Walk", false);
            return;
        }
        _animator.SetBool("Walk", true);
        if (_moveInput.x > 0)
        {
            _spriteRenderer.flipX = false;
        }else if (_moveInput.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetMoveInput();
        SetLookDirection();

    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    
}
