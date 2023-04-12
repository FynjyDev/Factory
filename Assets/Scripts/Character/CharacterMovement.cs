using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private SingletonController singletonController => SingletonController.singletonController;

    [SerializeField] private Animator characterAnimator;
    [SerializeField] private Transform characterTr;
    [SerializeField] private Rigidbody characterBody;

    private Vector3 inputVector;
    public Joystick Joystick => singletonController.UIController.CharacterJoystick;
    private float moveSpeed => singletonController.Config.CharacterMoveSpeed;
    private float rotateSpeed => singletonController.Config.CharacterRotateSpeed;

    private void FixedUpdate()
    {
        CharacterMove();
        CharacterRotate();
    }

    private void CharacterMove()
    {
        inputVector.x = Joystick.Horizontal;
        inputVector.z = Joystick.Vertical;

        characterBody.velocity = inputVector * moveSpeed;
        characterAnimator.SetBool("IsRun", inputVector != Vector3.zero);
    }

    private void CharacterRotate()
    {
        if (inputVector == Vector3.zero) return;

        characterTr.rotation = Quaternion.Lerp(characterTr.rotation, 
            Quaternion.LookRotation(new Vector3(inputVector.x, 0, inputVector.z)), rotateSpeed);
    }
}
