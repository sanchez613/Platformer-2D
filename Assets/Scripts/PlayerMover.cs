using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundChecker _groundCheker;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _motionVector;
    private bool _isLooksRight = true;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.A))
            {
                _motionVector = Vector2.left;
                Move(_motionVector);
            }

            if (Input.GetKey(KeyCode.D))
            {
                _motionVector = Vector2.right;
                Move(_motionVector);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            _motionVector = Vector2.zero;
            _animator.SetFloat("Speed", Mathf.Abs(_motionVector.x));
        }
    }

    public void Move(Vector2 moveDirection)
    {
        transform.Translate(moveDirection * _moveSpeed * Time.deltaTime);
        _animator.SetFloat("Speed", Mathf.Abs(_motionVector.x));

        if (_motionVector.x > 0 && _isLooksRight == false)
            Flip();
        else if (_motionVector.x < 0 && _isLooksRight)
            Flip();
    }

    public void Jump()
    {
        if (_groundCheker.IsGround)
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void Flip()
    {
        _isLooksRight = !_isLooksRight;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}
