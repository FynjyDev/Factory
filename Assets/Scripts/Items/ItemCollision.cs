using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour, Interactable
{
    public void OnInteractEnd()
    {
    }

    public void OnInteractStart()
    {
        Destroy(gameObject);
    }
}
