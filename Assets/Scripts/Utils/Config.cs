using UnityEngine;

[CreateAssetMenu(fileName ="Config", menuName ="Data/Config")]
public class Config : ScriptableObject
{
    public enum ChangerStates { take, give, disabled }

    [Header("Character Pharameters")]
    public float characterMoveSpeed;
    public float characterRotateSpeed;

    [Header("Item Changer Pharameters")]
    public float changeDelay;

    [Header("Delivery Spot Pharameters")]
    public int maxItemsCount;
    public int deliveryDelay;

    [Header("Basic Conveyor Pharameters")]
    public float basicConveyorSpawnDelay;

    [Header("Automatic Conveyor Pharameters")]
    public float automaticConveyorSpawnDelay;

    [Header("Manual Conveyor Pharameters")]
    public float manualConveyorSpawnDelay;

    [Header("Item Pharameters")]
    public float moveSpeed;
}
