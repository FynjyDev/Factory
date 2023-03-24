using UnityEngine;

[CreateAssetMenu(fileName ="Config", menuName ="Data/Config")]
public class Config : ScriptableObject
{
    [Header("Character Pharameters")]
    public float characterMoveSpeed;
    public float characterRotateSpeed;

    [Header("Conveyor Pharameters")]
    public float spawnDelay;

    [Header("Item Pharameters")]
    public float moveSpeed;
}
