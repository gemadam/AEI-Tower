using UnityEngine;

public enum EnumPlayerAnimation
{
    Idle,
    Jump,
}


public class PlayerAnimation : MonoBehaviour
{
    private GameObject _leftLeg;
    private Quaternion _leftLegQuaternion;
    private GameObject _rightLeg;
    private Quaternion _rightLegQuaternion;
    private GameObject _leftArm;
    private Quaternion _leftArmQuaternion;
    private GameObject _leftHand;
    private Quaternion _leftHandQuaternion;
    private GameObject _rightArm;
    private Quaternion _rightArmQuaternion;
    private GameObject _rightHand;
    private Quaternion _rightHandQuaternion;

    private EnumPlayerAnimation _animationState = EnumPlayerAnimation.Idle;

    private int _frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        _leftLeg = GameObject.Find("Player/bone_1/bone_7");
        _leftLegQuaternion = _leftLeg.transform.rotation;
        _rightLeg = GameObject.Find("Player/bone_1/bone_9");
        _rightLegQuaternion = _rightLeg.transform.rotation;

        _rightArm = GameObject.Find("Player/bone_1/bone_2/bone_3");
        _rightArmQuaternion = _rightArm.transform.rotation;
        _rightHand = GameObject.Find("Player/bone_1/bone_2/bone_3/bone_4");
        _rightHandQuaternion = _rightHand.transform.rotation;
        _leftArm = GameObject.Find("Player/bone_1/bone_2/bone_5");
        _leftArmQuaternion = _leftArm.transform.rotation;
        _leftHand = GameObject.Find("Player/bone_1/bone_2/bone_5/bone_6");
        _leftHandQuaternion = _leftHand.transform.rotation;

        RestartPosition();
    }

    public void SetAnimation(EnumPlayerAnimation animation)
    {
        if (animation == _animationState)
            return;

        RestartPosition();

        _animationState = animation;
    }

    void RestartPosition()
    {
        _frame = 0;
        _leftArm.transform.rotation = _leftArmQuaternion;
        _leftHand.transform.rotation = _leftHandQuaternion;

        _rightArm.transform.rotation = _rightArmQuaternion;
        _rightHand.transform.rotation = _rightHandQuaternion;

        _leftLeg.transform.rotation = _leftLegQuaternion;
        _rightLeg.transform.rotation = _rightLegQuaternion;
    }

    // Update is called once per frame
    void Update()
    {
        _frame++;

        switch (_animationState)
        {
            default:
            case EnumPlayerAnimation.Idle:
                IdleAnimation();
                break;
            case EnumPlayerAnimation.Jump:
                JumpAnimation();
                break;
        }

        _frame %= 240;
    }

    void IdleAnimation()
    {
        /*
            bone_5 -> rotate 313.7847
            bone_6 -> rotate 43.4138 - 355.4182
         
         */

        if (_frame < 120)
        {
            _leftArm.transform.Rotate(0, 0, -0.2f);
            _rightArm.transform.Rotate(0, 0, 0.2f);

            _rightHand.transform.Rotate(0, 0, 0.2f);
            _leftHand.transform.Rotate(0, 0, -0.2f);
        }
        else if (_frame < 240)
        {
            _leftArm.transform.Rotate(0, 0, 0.2f);
            _rightArm.transform.Rotate(0, 0, -0.2f);

            _rightHand.transform.Rotate(0, 0, -0.2f);
            _leftHand.transform.Rotate(0, 0, 0.2f);
        }
    }

    void JumpAnimation()
    {
        /*
            bone_5 -> rotate 313.7847
            bone_6 -> rotate 43.4138 - 355.4182
         
         */

        var legStep = 0.5f;
        var armStep = 1f;
        var handStep = 0.1f;

        if (_frame < 120)
        {
            _rightLeg.transform.Rotate(0, 0, -legStep);
            _leftLeg.transform.Rotate(0, 0, legStep);

            _leftArm.transform.Rotate(0, 0, armStep);
            _rightArm.transform.Rotate(0, 0, -armStep);

            _rightHand.transform.Rotate(0, 0, -handStep);
            _leftHand.transform.Rotate(0, 0, handStep);
        }
        else if (_frame < 240)
        {
            _rightLeg.transform.Rotate(0, 0, legStep);
            _leftLeg.transform.Rotate(0, 0, -legStep);

            _leftArm.transform.Rotate(0, 0, -armStep);
            _rightArm.transform.Rotate(0, 0, armStep);

            _rightHand.transform.Rotate(0, 0, handStep);
            _leftHand.transform.Rotate(0, 0, -handStep);
        }
    }
}
