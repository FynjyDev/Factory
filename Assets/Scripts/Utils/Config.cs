using UnityEngine;

[CreateAssetMenu(fileName ="Config", menuName ="Data/Config")]
public class Config : ScriptableObject
{
    public enum ChangerStates { take, give, disabled }

    [Header("Character Pharameters")]
    [Range(1,10)] public float CharacterMoveSpeed;
    [Range(0.1f, 1)] public float CharacterRotateSpeed;

    [Header("Item Changer Pharameters")]
    [Range(1, 5)] public float ChangeDelay;

    [Header("Delivery Spot Pharameters")]
    [Range(5, 50)] public int MaxItemsCount;
    [Range(10, 20)] public int DeliveryDelay;

    [Header("Basic Conveyor Pharameters")]
    [Range(1, 5)] public float BasicConveyorSpawnDelay;

    [Header("Automatic Conveyor Pharameters")]
    [Range(1, 5)] public float AutomaticConveyorSpawnDelay;

    [Header("Manual Conveyor Pharameters")]
    [Range(1, 5)] public float ManualConveyorSpawnDelay;

    [Header("Item Pharameters")]
    [Range(2, 5)] public float MoveSpeed;
}
