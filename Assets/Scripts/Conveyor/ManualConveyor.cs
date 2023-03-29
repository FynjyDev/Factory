using System.Collections;
using UnityEngine;

public class ManualConveyor : Conveyor, IInteractable
{
    private float _ManualConveyorSpawnDelay => singletonController.config.manualConveyorSpawnDelay;
    private float _TempSpawnTime;

    private void Start()
    {
        _TempSpawnTime = _ManualConveyorSpawnDelay;
    }

    public override IEnumerator Working()
    {
        while (true)
        {
            while (_TempSpawnTime > 0)
            {
                _TempSpawnTime -= Time.fixedDeltaTime;
                yield return null;
            }
            SpawnItem();
        }
    }

    public override void SpawnItem()
    {
        base.SpawnItem();
        _TempSpawnTime = _ManualConveyorSpawnDelay;
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
