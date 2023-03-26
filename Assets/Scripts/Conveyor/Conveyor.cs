using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public SingletonController singletonController => SingletonController.singletonController;

    public ItemMoving itemPrefab;
    public List<PathPoint> convoyerPathPoints;
    public List<ItemMoving> activeItems;

    private float _BasicSpawnDelay => singletonController.config.basicConveyorSpawnDelay;

    public virtual IEnumerator Working()
    {
        while (true)
        {
            SpawnItem();
            yield return new WaitForSeconds(_BasicSpawnDelay);
        }
    }

    public virtual void SpawnItem()
    {
        ItemMoving _newItem = Instantiate(itemPrefab, convoyerPathPoints[0].transform.position, Quaternion.identity);
        _newItem.convoyerPathPoints = convoyerPathPoints;

        _newItem.itemCollision.conveyor = this;

        activeItems.Add(_newItem);
    }

    public virtual void OnItemEndPath(ItemMoving _item)
    {

    }
}
