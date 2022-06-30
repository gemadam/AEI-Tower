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
        _leftLeg = GameObject.Find("Player/Body/LeftFoot");
        _rightLeg = GameObject.Find("Player/Body/RightFoot");

        _leftArm = GameObject.Find("Player/Body/LeftArm");
        _rightArm = GameObject.Find("Player/Body/RightArm");
    }

    // Update is called once per frame
    void Update()
    {
        _frame++;

        if (_frame < 120)
        {
            _leftLeg.transform.Rotate(0, 0, -0.75f);
            _rightLeg.transform.Rotate(0, 0, 0.75f);

            _leftArm.transform.Rotate(0, 0, -1);
            _rightArm.transform.Rotate(0, 0, 1);
        }
        else if (_frame < 240)
        {
            _leftLeg.transform.Rotate(0, 0, 0.75f);
            _rightLeg.transform.Rotate(0, 0, -0.75f);

            _leftArm.transform.Rotate(0, 0, 1);
            _rightArm.transform.Rotate(0, 0, -1);
        }

        _frame %= 240;
    }
}
