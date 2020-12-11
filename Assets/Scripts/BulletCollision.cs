using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;
    private string explodeString = "Explode";
    private void Start()
    {
        _animator = this.GetComponent<Animator>();
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _boxCollider2D = this.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _animator.SetBool(explodeString, true);
        Destroy(_rigidbody2D);
        Destroy(_boxCollider2D);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _animator.SetBool(explodeString, true);
        Destroy(_rigidbody2D);
        Destroy(_boxCollider2D);
    }
}
