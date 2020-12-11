// Gemaakt door Emile

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.WSA;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private float _horizonalSpeed;
    [SerializeField] private float _maxSpeedVertical;
    [SerializeField] private float _maxspeedHorizontal;
    [SerializeField] private float _deceleration;
    [SerializeField] private float _acceleration;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private InputAxis _inputAxis;

    [SerializeField] private Animator _bodyAnimator;
    [SerializeField] private GameObject _playerBody;

    [SerializeField] private BodyAnimation _bodyAnimation;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _bodyAnimation = GetComponent<BodyAnimation>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        _verticalSpeed = CalculateMovement(_inputAxis.GetVertical(), _verticalSpeed, _maxSpeedVertical);
        _horizonalSpeed = CalculateMovement(_inputAxis.GetHorizontal(), _horizonalSpeed, _maxspeedHorizontal);
        //animation
        string value = _bodyAnimation.CalculateBodyAnimation(_horizonalSpeed, _verticalSpeed,
            _inputAxis.GetHorizontal(), _inputAxis.GetVertical());
        _bodyAnimation.Animate(value);
        //move character
        Vector3 newPosition = this.transform.position + new Vector3(_horizonalSpeed, _verticalSpeed, 0) * Time.deltaTime;
        _rigidbody.MovePosition(newPosition);
    }

    private float CalculateMovement(float input, float speed, float maxspeed)
    {
        if (input == 0)
        {
            return Mathf.Clamp(Mathf.MoveTowards(speed, 0f, _deceleration * Time.deltaTime), -maxspeed, maxspeed);
        }
        return Mathf.Clamp(speed += input * _acceleration * Time.deltaTime, -maxspeed, maxspeed);
    }
}