using UnityEngine;

public class ItemCollision : MonoBehaviour, IInteractable
{
    [HideInInspector] public Conveyor conveyor;
    public DataController.ItemTypes itemType;
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
        itemMoving.singletonController.dataController.ChangeItemData(itemType, 1);
        conveyor.activeItems.Remove(itemMoving);
        Destroy(gameObject);
    }
}
