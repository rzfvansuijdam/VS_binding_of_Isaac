using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAxis : MonoBehaviour
{
    private float _shootHor;
    private float _shootVer;
    private float _horizontal;
    private float _vertical;

    private string _horizontalString = "Horizontal";
    private string _verticalString = "Vertical";
    private string _horizontalShootString = "ShootingHorizontal";
    private string _verticalShootString = "ShootingVertical";

    // Start is called before the first frame update
    private void Update()
    {
        _horizontal = Input.GetAxisRaw(_horizontalString);
        _vertical = Input.GetAxisRaw(_verticalString);
        _shootHor = Input.GetAxis(_horizontalShootString);
        _shootVer = Input.GetAxis(_verticalShootString);
    }

    //getters
    public float GetShootHor()
    {
        return _shootHor;
    }

    public float GetShootVer()
    {
        return _shootVer;
    }

    public float GetVertical()
    {
        return _vertical;
    }

    public float GetHorizontal()
    {
        return _horizontal;
    }
}