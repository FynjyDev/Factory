using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour, Interactable
{
    [HideInInspector] public Conveyor conveyor;
    public ItemMoving itemMoving;

    public void OnInteractEnd()
    {
    }

    public void OnInteractStart()
    {
        OnCollect();
    }

    public void OnCollect()
    {
        conveyor.activeItems.Remove(itemMoving);
        Destroy(gameObject);
    }
}
