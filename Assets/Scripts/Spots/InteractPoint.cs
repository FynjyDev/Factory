using UnityEngine;

public class InteractPoint : MonoBehaviour
{
    [HideInInspector] public CharacterCollision CharacterCollision;

    [SerializeField] private GameObject interactableObject;
    [SerializeField] private bool isInteractable;

    private IInteractable interactable;

    private void Start()
    {
        if (interactableObject) interactable = interactableObject.GetComponentInParent<IInteractable>();
        else Debug.Log($"interactableObject is null: {transform.parent.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterCollision = other.GetComponent<CharacterCollision>();
        if (CharacterCollision == null) return;

        if (interactableObject)
        interactable.OnInteractStart();
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterCollision = other.GetComponent<CharacterCollision>();

        if (CharacterCollision != null) CharacterCollision = null;
        else return;

        if (interactableObject)
            interactable.OnInteractEnd();
    }
}
