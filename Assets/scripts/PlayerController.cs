// Gemaakt door Emile

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lastFire;
    [SerializeField] private float _fireDelay;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        CheckForShooting();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidbody.velocity = new Vector3(horizontal * _speed, vertical * _speed, 0);
    }

    private void CheckForShooting()
    {
        float shootHor = Input.GetAxis("ShootingHorizontal");
        float shootVer = Input.GetAxis("ShootingVertical");

        if ((shootHor != 0 || shootVer != 0) && Time.time > _lastFire + _fireDelay)
        {
            shoot(shootHor, shootVer);
            _lastFire = Time.time;
        }
    }

    public void shoot(float x, float y)
    {
        GameObject bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        //if statment in vector ? if true : if false;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * _bulletSpeed : Mathf.Ceil(x) * _bulletSpeed,
            (y < 0) ? Mathf.Floor(y) * _bulletSpeed : Mathf.Ceil(y) * _bulletSpeed,
            0
       );
    }
}