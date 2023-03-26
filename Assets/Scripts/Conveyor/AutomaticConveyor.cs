using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticConveyor : Conveyor
{
    private float _AutomaticConveyorSpawnDelay => singletonController.config.automaticConveyorSpawnDelay;

    private void Start()
    {
        StartCoroutine(Working());
    }

    public override IEnumerator Working()
    {
        while (true)
        {
            SpawnItem();
            yield return new WaitForSeconds(_AutomaticConveyorSpawnDelay);
        }
    }

    public override void OnItemEndPath(ItemMoving _item)
    {
        _item.itemCollision.OnCollect();
    }
}
