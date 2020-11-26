// Gemaakt door Emile
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private float _horizonalSpeed;
    [SerializeField] private float _maxSpeedVertical;
    [SerializeField] private float _maxspeedHorizontal;
    [SerializeField] private float _deceleration;
    [SerializeField] private float _eceleration;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lastFire;
    [SerializeField] private float _fireDelay;
    [SerializeField] private InputAxis _inputAxis;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        CheckForShooting();
    }

    private void Movement()
    {
        //verticle
        if (_inputAxis.GetVertical() == 0) _verticalSpeed = Mathf.MoveTowards(_verticalSpeed, 0f, _deceleration * Time.deltaTime);
        else _verticalSpeed += _inputAxis.GetVertical() * _eceleration * Time.deltaTime;
        //horizontal
        if (_inputAxis.GetHorizontal() == 0) _horizonalSpeed = Mathf.MoveTowards(_horizonalSpeed, 0f, _deceleration * Time.deltaTime);
        else _horizonalSpeed += _inputAxis.GetHorizontal() * _eceleration * Time.deltaTime;
        //if needed we can clamp it (in this case the maxspeed)
        _verticalSpeed = Mathf.Clamp(_verticalSpeed, -_maxSpeedVertical, _maxSpeedVertical);
        _horizonalSpeed = Mathf.Clamp(_horizonalSpeed, -_maxspeedHorizontal, _maxspeedHorizontal);
        //move character
        Vector3 newPosition = this.transform.position + new Vector3(_horizonalSpeed, _verticalSpeed, 0) * Time.deltaTime;
        _rigidbody.MovePosition(newPosition);
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