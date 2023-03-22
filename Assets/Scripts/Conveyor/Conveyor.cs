using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public SingletonController singletonController => SingletonController.singletonController;

    public GameObject itemPrefab;
    public Transform itemSpawnPos;

    public float spawnDelay;

    public IEnumerator Working()
    {
        while (true)
        {
            SpawnItem();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public virtual void SpawnItem()
    {
        Instantiate(itemPrefab, itemSpawnPos.position, Quaternion.identity);
    }
}
