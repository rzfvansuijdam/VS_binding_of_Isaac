// Gemaakt door Emile
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lastFire;
    [SerializeField] private float _fireDelay;
    [SerializeField] private InputAxis _inputAxis;

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
        rigidbody.velocity = new Vector3(_inputAxis.GetHorizontal() * _speed, _inputAxis.GetVertical() * _speed, 0);
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