using System.Collections;
using UnityEngine;

public class ManualConveyor : Conveyor, IInteractable
{
    private float manualConveyorSpawnDelay => singletonController.Config.ManualConveyorSpawnDelay;
    private float tempSpawnTime;

    private void Start()
    {
        tempSpawnTime = manualConveyorSpawnDelay;
    }

    public override IEnumerator Working()
    {
        while (true)
        {
            while (tempSpawnTime > 0)
            {
                tempSpawnTime -= Time.fixedDeltaTime;
                yield return null;
            }
            SpawnItem();
        }
    }

    public override void SpawnItem()
    {
        base.SpawnItem();
        tempSpawnTime = manualConveyorSpawnDelay;
    }

    public void OnInteractStart()
    {
        StartCoroutine(Working());
    }
    public void OnInteractEnd()
    {
        StopAllCoroutines();
    }
}
