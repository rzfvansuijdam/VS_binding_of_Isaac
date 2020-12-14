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

    [SerializeField] private Transform _spawningLocation;
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
        GameObject bullet = Instantiate(_bulletPrefab, _spawningLocation.position, transform.rotation);
        BoxCollider2D coll = bullet.AddComponent<BoxCollider2D>();
        coll.size = new Vector2(.1f,.1f);
        Rigidbody2D rigidbody = bullet.AddComponent<Rigidbody2D>();
        BulletCollision bulletCollision = bullet.AddComponent<BulletCollision>();
        Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), coll, true);
        rigidbody.gravityScale = 0;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (x != 0 && y != 0) y = 0; //making sure that you cant shoot diagonal
        rigidbody.velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * _bulletSpeed : Mathf.Ceil(x) * _bulletSpeed,
            (y < 0) ? Mathf.Floor(y) * _bulletSpeed : Mathf.Ceil(y) * _bulletSpeed,
            0
       );
    }
}