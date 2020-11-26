using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAxis : MonoBehaviour
{
    private float _shootHor;
    private float _shootVer;
    private float _horizontal;
    private float _vertical;

    // Start is called before the first frame update
    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _shootHor = Input.GetAxis("ShootingHorizontal");
        _shootVer = Input.GetAxis("ShootingVertical");
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