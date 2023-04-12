using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    [SerializeField] private Transform stratPos;
    [SerializeField] private GameObject stackPrefab;

    [Header("Steps")]
    [SerializeField]
    private float xStep;
    [SerializeField]
    private float yStep;
    [SerializeField]
    private float zStep;

    [Header("Ranges")]
    [SerializeField] [Min(2)] private int xMaxCount;
    [SerializeField] [Min(2)] private int zMaxCount;

    private float tempX, tempY, tempZ;

    [HideInInspector] public List<GameObject> StackObjects;

    public void AddElement()
    {
        Vector3 _pos = new Vector3()
        {
            z = stratPos.position.z - tempZ,
            x = stratPos.position.x + tempX,
            y = stratPos.position.y + tempY
        };

        tempZ += zStep;
        if ((StackObjects.Count + 1) % zMaxCount == 0) { tempX += xStep; tempZ = 0; }
        if ((StackObjects.Count + 1) % (zMaxCount * xMaxCount) == 0) { tempX = 0; tempZ = 0; tempY += yStep; }

        GameObject _stackGO = Instantiate(stackPrefab, _pos, Quaternion.identity, stratPos);
        StackObjects.Add(_stackGO);
    }

    public void ClearStack()
    {
        for (int i = 0; i < StackObjects.Count; i++) DestroyImmediate(StackObjects[i]);
        StackObjects.Clear();

        tempZ = 0;
        tempX = 0;
        tempY = 0;
    }
}
