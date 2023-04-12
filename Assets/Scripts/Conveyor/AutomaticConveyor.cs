using System.Collections;
using UnityEngine;

public class AutomaticConveyor : Conveyor
{
    private float automaticConveyorSpawnDelay => singletonController.Config.AutomaticConveyorSpawnDelay;

    private void Start()
    {
        StartCoroutine(Working());
    }

    public override IEnumerator Working()
    {
        while (true)
        {
            SpawnItem();
            yield return new WaitForSeconds(automaticConveyorSpawnDelay);
        }
    }

    public override void OnItemEndPath(ItemMoving _item)
    {
        _item.itemCollision.OnCollect();
    }
}
