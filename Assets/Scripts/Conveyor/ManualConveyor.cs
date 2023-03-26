using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualConveyor : Conveyor, Interactable
{
    private float _ManualConveyorSpawnDelay => singletonController.config.manualConveyorSpawnDelay;

    public override IEnumerator Working()
    {
        while (true)
        {
            SpawnItem();
            yield return new WaitForSeconds(_ManualConveyorSpawnDelay);
        }
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
