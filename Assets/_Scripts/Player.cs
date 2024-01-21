using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 700f)][SerializeField] private float _speed = 400f;
    
    [SerializeField] private MoveController _controller;
    [SerializeField] private Animator _animator;

    private float _horizontalMove = 0f;
    private bool _jump = false;

    private void Update()
    {
        _horizontalMove = Input.GetAxis("Horizontal") * _speed;
        _animator.SetFloat("Speed",Mathf.Abs(_horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;
            _animator.SetBool("isJumping", true);
        }
    }

    private void FixedUpdate()
    {
        _controller.Move(_horizontalMove * Time.fixedDeltaTime, _jump);
        _jump = false;
    }

    public void OnLanding()
    {
        _animator.SetBool("isJumping", false);
    }

    public void ChangeLookInRoom()
    {

    }

    public void ChangeLookToAstral()
    {

    }
}
