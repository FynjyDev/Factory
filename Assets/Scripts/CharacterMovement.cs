using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Animator characterAnimator;
    public Transform characterTr;
    public Rigidbody characterBody;

    public Joystick joystick => SingletonController.singletonController.UIController.characterJoystick;
    private float _MoveSpeed => SingletonController.singletonController.config.characterMoveSpeed;
    private float _RotateSpeed => SingletonController.singletonController.config.characterRotateSpeed;

    private Vector3 _InputVector;

    private void FixedUpdate()
    {
        CharacterMove();
        CharacterRotate();
    }

    private void CharacterMove()
    {
        _InputVector.x = joystick.Horizontal;
        _InputVector.z = joystick.Vertical;

        characterBody.velocity = _InputVector * _MoveSpeed;
        characterAnimator.SetBool("IsRun", _InputVector != Vector3.zero);
    }

    private void CharacterRotate()
    {
        if (_InputVector == Vector3.zero) return;

        characterTr.rotation = Quaternion.Lerp(characterTr.rotation, 
            Quaternion.LookRotation(new Vector3(_InputVector.x, 0, _InputVector.z)), _RotateSpeed);
    }
}
