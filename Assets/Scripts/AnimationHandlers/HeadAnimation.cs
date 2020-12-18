using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAnimation : MonoBehaviour
{
    [SerializeField] private InputAxis _inputAxis;
    [SerializeField] private Sprite shootLeft;
    [SerializeField] private Sprite shootRight;
    [SerializeField] private Sprite shootUp;
    [SerializeField] private Sprite shootDown;
    [SerializeField] private Sprite shootIdle;

    [SerializeField] private float backToIdle = 1f;
    [SerializeField] private float currentTime = 0f;

    private void Update()
    {
        CheckForAnimation();
    }

    private void CheckForAnimation()
    {
        currentTime += Time.deltaTime;

        if (_inputAxis.GetShootVer() > 0)
        {
            //shooting up
            gameObject.GetComponent<SpriteRenderer>().sprite = shootUp;
            currentTime = 0;
        }

        if (_inputAxis.GetShootVer() < 0)
        {
            //shooting down
            this.gameObject.GetComponent<SpriteRenderer>().sprite = shootDown;
            currentTime = 0;
        }

        if (_inputAxis.GetShootHor() < 0)
        {
            //shooting left
            transform.rotation = new Quaternion(0, 180, 0, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = shootLeft;
            currentTime = 0;
        }

        if (_inputAxis.GetShootHor() > 0)
        {
            //shooting right
            transform.rotation = new Quaternion(0, 0, 0, 0);
            gameObject.GetComponent<SpriteRenderer>().sprite = shootRight;
            currentTime = 0;
        }

        if (currentTime > backToIdle)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = shootIdle;
            currentTime = 0;
        }
    }
}
