using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticConveyor : Conveyor
{
    private void Start()
    {
        StartCoroutine(Working());
    }
}
