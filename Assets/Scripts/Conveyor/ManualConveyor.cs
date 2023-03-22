using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualConveyor : Conveyor, Interactable
{
    public void OnInteractStart()
    {
        StartCoroutine(Working());
    }
    public void OnInteractEnd()
    {
        StopAllCoroutines();
    }
}
