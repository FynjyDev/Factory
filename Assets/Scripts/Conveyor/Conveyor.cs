using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public SingletonController singletonController => SingletonController.singletonController;

    public ItemMoving itemPrefab;
    public List<PathPoint> convoyerPathPoints;

    private float _SpawnDelay => singletonController.config.spawnDelay;

    public IEnumerator Working()
    {
        while (true)
        {
            SpawnItem();
            yield return new WaitForSeconds(_SpawnDelay);
        }
    }

    public virtual void SpawnItem()
    {
       ItemMoving _newItem = Instantiate(itemPrefab, convoyerPathPoints[0].transform.position, Quaternion.identity);
        _newItem.convoyerPathPoints = convoyerPathPoints;
    }
}
