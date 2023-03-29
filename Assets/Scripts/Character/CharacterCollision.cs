using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    public IInteractable activeInteractableObject;
    private void OnTriggerEnter(Collider other)
    {
        activeInteractableObject = other.GetComponent<IInteractable>();

        if (activeInteractableObject != null) activeInteractableObject.OnInteractStart();
    }

    private void OnTriggerExit(Collider other)
    {
        if (activeInteractableObject == null) return;

        activeInteractableObject.OnInteractEnd();
        activeInteractableObject = null;
    }
}
