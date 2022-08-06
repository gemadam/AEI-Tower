using UnityEngine;

public enum EnumPlayerAnimation
{
    Idle,
    Jump,
}


public class PlayerAnimation : MonoBehaviour
{
    private GameObject _leftLeg;                                                /*!< Players left leg */
    private Quaternion _leftLegQuaternion;                                      /*!< Players left leg start position */
    private GameObject _rightLeg;                                               /*!< Players right leg */
    private Quaternion _rightLegQuaternion;                                     /*!< Players right leg start position */
    private GameObject _leftArm;                                                /*!< Players left arm */
    private Quaternion _leftArmQuaternion;                                      /*!< Players left arm start position */
    private GameObject _leftHand;                                               /*!< Players left hand */
    private Quaternion _leftHandQuaternion;                                     /*!< Players left hand start position */
    private GameObject _rightArm;                                               /*!< Players right arm */
    private Quaternion _rightArmQuaternion;                                     /*!< Players right arm start position */
    private GameObject _rightHand;                                              /*!< Players right hand */
    private Quaternion _rightHandQuaternion;                                    /*!< Players right hand start position */

    private EnumPlayerAnimation _animationState = EnumPlayerAnimation.Idle;     /*!< Current player animation */

    private int _frame = 0;                                                     /*!< Current animation frame */

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

    /**
        Sets current animation of the player.
     */
    public void SetAnimation(EnumPlayerAnimation animation)
    {
        if (animation == _animationState)
            return;

        RestartPosition();

        _animationState = animation;
    }

    /**
        Clears effects of animation of the player.
     */
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

    /**
        Animation of the player in idle state.
     */
    void IdleAnimation()
    {
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

    /**
        Animation of the player in jump state.
     */
    void JumpAnimation()
    {
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
