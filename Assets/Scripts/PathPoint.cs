using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    public GameObject previewModel;

    private void Awake()
    {
        previewModel.SetActive(false);
    }
}
