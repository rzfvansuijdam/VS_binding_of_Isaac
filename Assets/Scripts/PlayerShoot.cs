using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lastFire;
    [SerializeField] private float _fireDelay;
    [SerializeField] private InputAxis _inputAxis;

    // Update is called once per frame
    private void Update()
    {
        CheckForShooting();
    }

    private void CheckForShooting()
    {
        if ((_inputAxis.GetShootHor() != 0 || _inputAxis.GetShootVer() != 0) && Time.time > _lastFire + _fireDelay)
        {
            Shoot(_inputAxis.GetShootHor(), _inputAxis.GetShootVer());
            _lastFire = Time.time;
        }
    }

    public void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation) as GameObject;
        Rigidbody2D rigidbody = bullet.AddComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        rigidbody.velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * _bulletSpeed : Mathf.Ceil(x) * _bulletSpeed,
            (y < 0) ? Mathf.Floor(y) * _bulletSpeed : Mathf.Ceil(y) * _bulletSpeed,
            0
       );
    }
}