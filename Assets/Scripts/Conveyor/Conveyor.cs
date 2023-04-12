using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public SingletonController singletonController => SingletonController.singletonController;

    [SerializeField] private ItemMoving itemPrefab;
    [SerializeField] private List<PathPoint> convoyerPathPoints;
    public List<ItemMoving> activeItems;

    private float basicSpawnDelay => singletonController.Config.BasicConveyorSpawnDelay;

    public virtual IEnumerator Working()
    {
        while (true)
        {
            SpawnItem();
            yield return new WaitForSeconds(basicSpawnDelay);
        }
    }

    public virtual void SpawnItem()
    {
        ItemMoving _newItem = Instantiate(itemPrefab, convoyerPathPoints[0].transform.position, Quaternion.identity);
        _newItem.convoyerPathPoints = convoyerPathPoints;

        _newItem.itemCollision.Conveyor = this;

        activeItems.Add(_newItem);
    }

    public virtual void OnItemEndPath(ItemMoving _item)
    {

    }
}
