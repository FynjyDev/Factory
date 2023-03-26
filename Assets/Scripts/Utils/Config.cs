using UnityEngine;

[CreateAssetMenu(fileName ="Config", menuName ="Data/Config")]
public class Config : ScriptableObject
{
    [Header("Character Pharameters")]
    public float characterMoveSpeed;
    public float characterRotateSpeed;

    [Header("Basic Conveyor Pharameters")]
    public float basicConveyorSpawnDelay;

    [Header("Automatic Conveyor Pharameters")]
    public float automaticConveyorSpawnDelay;

    [Header("Manual Conveyor Pharameters")]
    public float manualConveyorSpawnDelay;


    [Header("Item Pharameters")]
    public float moveSpeed;
}
