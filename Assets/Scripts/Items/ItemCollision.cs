using UnityEngine;

public class ItemCollision : MonoBehaviour, IInteractable
{
    [HideInInspector] public Conveyor Conveyor;

    [SerializeField] private DataController.ItemTypes itemType;
    [SerializeField] private ItemMoving itemMoving;

    public void OnInteractEnd() { }

    public void OnInteractStart()
    {
        OnCollect();
    }

    public void OnCollect()
    {
        itemMoving.singletonController.DataController.ChangeItemData(itemType, 1);
        Conveyor.activeItems.Remove(itemMoving);
        Destroy(gameObject);
    }
}
