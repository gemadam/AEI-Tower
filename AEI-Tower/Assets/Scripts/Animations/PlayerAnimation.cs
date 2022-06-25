using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private GameObject _leftLeg;
    private GameObject _rightLeg;
    private GameObject _leftArm;
    private GameObject _rightArm;

    private int _frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        _leftLeg = GameObject.Find("Player/LeftFoot");
        _rightLeg = GameObject.Find("Player/RightFoot");
        
        _leftArm = GameObject.Find("Player/LeftArm");
        _rightArm = GameObject.Find("Player/RightArm");
    }

    // Update is called once per frame
    void Update()
    {
        _frame++;

        if(_frame < 120)
        {
            _leftLeg.transform.Rotate(0, 0, -1);
            _rightLeg.transform.Rotate(0, 0, 1);

            _leftArm.transform.Rotate(0, 0, -1);
            _rightArm.transform.Rotate(0, 0, 1);
        }
        else if(_frame < 240)
        {
            _leftLeg.transform.Rotate(0, 0, 1);
            _rightLeg.transform.Rotate(0, 0, -1);

            _leftArm.transform.Rotate(0, 0, 1);
            _rightArm.transform.Rotate(0, 0, -1);
        }

        _frame %= 240;
    }
}
