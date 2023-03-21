using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private SingletonController singletonController => SingletonController.singletonController;

    public Animator characterAnimator;
    public Transform characterTr;
    public Rigidbody characterBody;

    private Vector3 _InputVector;
    public Joystick joystick => singletonController.UIController.characterJoystick;
    private float _MoveSpeed => singletonController.config.characterMoveSpeed;
    private float _RotateSpeed => singletonController.config.characterRotateSpeed;

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
