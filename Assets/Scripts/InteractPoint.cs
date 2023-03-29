using UnityEngine;

public class InteractPoint : MonoBehaviour
{
    [HideInInspector] public CharacterCollision characterCollision;

    public GameObject interactableObject;
    public bool isInteractable;

    private IInteractable _Interactable;

    private void Start()
    {
        if (interactableObject) _Interactable = interactableObject.GetComponentInParent<IInteractable>();
        else Debug.Log($"interactableObject is null: {transform.parent.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        characterCollision = other.GetComponent<CharacterCollision>();
        if (characterCollision == null) return;

        if (interactableObject)
        _Interactable.OnInteractStart();
    }

    private void OnTriggerExit(Collider other)
    {
        characterCollision = other.GetComponent<CharacterCollision>();

        if (characterCollision != null) characterCollision = null;
        else return;

        if (interactableObject)
            _Interactable.OnInteractEnd();
    }
}
