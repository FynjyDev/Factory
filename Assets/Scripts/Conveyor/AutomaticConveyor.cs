using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticConveyor : Conveyor
{
    private void Start()
    {
        StartCoroutine(Working());
    }

    public override void OnItemEndPath(ItemMoving _item)
    {
        _item.itemCollision.OnCollect();
    }
}
