// Gemaakt door Emile
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
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
        string value = CalculateBodyAnimation();
        Animate(value);
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

    private string CalculateBodyAnimation()
    {
        string moveVertical;
        string moveHorizontal;
        
        if (_inputAxis.GetHorizontal() > 0) moveHorizontal = "right";
        else if (_inputAxis.GetHorizontal() < 0) moveHorizontal = "left"; 
        else moveHorizontal = null; 
        
        if (_inputAxis.GetVertical() > 0) moveVertical = "up";
        else if (_inputAxis.GetVertical() < 0) moveVertical = "down";
        else moveVertical = null;

        if (moveVertical == null && moveHorizontal == null) return "idle";
        if (moveVertical != null && moveHorizontal == null) return moveVertical;
        if (moveVertical == null && moveHorizontal != null) return moveHorizontal;

        //moving horizontal an moving vertical
        if (moveHorizontal == "right")
        {
            if (Mathf.Abs(_horizonalSpeed) >= Mathf.Abs(_verticalSpeed)) return moveHorizontal;
            return moveVertical;
        }
        if (Mathf.Abs(_verticalSpeed) > Mathf.Abs(_horizonalSpeed)) return moveVertical;
        return moveHorizontal;
    }
    private void Animate(string value)
    {
        //reset rotation
        _playerBody.transform.rotation = new Quaternion(0, 0, 0, 0);
        if(value == "idle")
        {
            //idle
            _bodyAnimator.SetBool("Idle", true);
        }
        if (value == "left")
        {
            //moving left
            _bodyAnimator.SetBool("WalkingHorizontal", true);
            _playerBody.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        if (value == "right")
        {
            //moving right
            _bodyAnimator.SetBool("WalkingHorizontal", true);
        }
        if (value == "up")
        {
            //moving up
            _bodyAnimator.SetBool("WalkingVertical", true);
        }
        if (value == "down")
        {
            //moving down
            _bodyAnimator.SetBool("WalkingVertical", true);
        }
        
        //if nothing what isnt possible.. just idle
        _bodyAnimator.SetBool("Idle", true);
    }
}