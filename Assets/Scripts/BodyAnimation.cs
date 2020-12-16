using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    
    public string CalculateBodyAnimation(float _horizontalSpeed, float _verticalSpeed, float _horizontalMovepower, float _verticalMovepower)
    {
        string moveVertical;
        string moveHorizontal;

        if (_horizontalSpeed == 0 && _verticalSpeed == 0) return "idle";
        
        if (_horizontalMovepower > 0) moveHorizontal = "right";
        else if (_horizontalMovepower < 0) moveHorizontal = "left";
        else moveHorizontal = null; 
        
        if (_verticalMovepower > 0) moveVertical = "up";
        else if (_verticalMovepower < 0) moveVertical = "down";
        else moveVertical = null;

        if (moveVertical == null && moveHorizontal == null) return "idle";
        if (moveVertical != null && moveHorizontal == null) return moveVertical;
        if (moveVertical == null && moveHorizontal != null) return moveHorizontal;

        //moving horizontal an moving vertical (Mathf.Abs because it can be in the min or plus but it has to be the same..) 
        if (moveHorizontal == "right")
        {
            if (Mathf.Abs(_horizontalSpeed) >= Mathf.Abs(_verticalSpeed)) return moveHorizontal;
            return moveVertical;
        }
        if (Mathf.Abs(_verticalSpeed) >= Mathf.Abs(_horizontalSpeed)) return moveVertical;
        return moveHorizontal;
    }
    
    public void Animate(string value)
    {
        //reset rotation
        switch (value)
        {
            case "idle":
                _anim.SetBool("Idle", true);
                break;
            case "left":
                _anim.SetBool("WalkingHorizontal", true);
                this.transform.rotation = new Quaternion(0, 180, 0, 0);
                break;
            case "right":
                _anim.SetBool("WalkingHorizontal", true);
                this.transform.rotation = new Quaternion(0, 0, 0, 0);
                break;
            case "up":
                _anim.SetBool("WalkingVertical", true);
                break;
            case "down":
                _anim.SetBool("WalkingVertical", true);
                break;
            default:
                _anim.SetBool("Idle", true);
                break;
        }
    }

}
