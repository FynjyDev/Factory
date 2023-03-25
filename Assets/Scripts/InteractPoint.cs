using UnityEngine;

public class InteractPoint : MonoBehaviour
{
    public GameObject interactableObject;
    private Interactable _Interactable;

    private void Start()
    {
        if (interactableObject) _Interactable = interactableObject.GetComponentInParent<Interactable>();
        else Debug.Log($"interactableObject is null: {transform.parent.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        _Interactable.OnInteractStart();
    }

    private void OnTriggerExit(Collider other)
    {
        _Interactable.OnInteractEnd();
    }
}
