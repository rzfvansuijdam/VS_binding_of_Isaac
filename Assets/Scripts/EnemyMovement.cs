using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _cooldown;
    [SerializeField] private float _cooldownTime;
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private float _horizonalSpeed;
    [SerializeField] private float _maxSpeedVertical;
    [SerializeField] private float _maxspeedHorizontal;
    [SerializeField] private float _deceleration;
    [SerializeField] private float _acceleration;
    [SerializeField] private Rigidbody2D _rigidbody;
    
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _thisObject;

    [SerializeField] private int _horizontalMovepower;
    [SerializeField] private int _verticalMovepower;
    
    [SerializeField] private BodyAnimation _bodyAnimation;
    [SerializeField] private GameObject _player;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _bodyAnimation = GetComponent<BodyAnimation>();
        Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), _player.GetComponent<BoxCollider2D>(), true);
    }

    private void Update()
    {
        _cooldown -= Time.deltaTime;
        if (_cooldown <= 0)
        {
            _horizontalMovepower = Random.Range(-1, 2);
            _verticalMovepower = Random.Range(-1, 2);
            _cooldown = _cooldownTime;
        }
        _verticalSpeed = CalculateMovement(_verticalMovepower, _verticalSpeed, _maxSpeedVertical);
        _horizonalSpeed = CalculateMovement(_horizontalMovepower, _horizonalSpeed, _maxspeedHorizontal);

        _bodyAnimation.Animate(_bodyAnimation.CalculateBodyAnimation(_horizonalSpeed, _verticalSpeed, _horizontalMovepower, _verticalMovepower));

        Vector3 newPosition = transform.position + new Vector3(_horizonalSpeed, _verticalSpeed, 0) * Time.deltaTime;
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