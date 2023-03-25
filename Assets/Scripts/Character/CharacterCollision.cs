using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    public Interactable activeInteractableObject;
    private void OnTriggerEnter(Collider other)
    {
        activeInteractableObject = other.GetComponent<Interactable>();

        if (activeInteractableObject != null) activeInteractableObject.OnInteractStart();
    }

    private void OnTriggerExit(Collider other)
    {
        if (activeInteractableObject == null) return;

        activeInteractableObject.OnInteractEnd();
        activeInteractableObject = null;
    }
}
