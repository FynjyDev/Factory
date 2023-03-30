using UnityEngine;

public class SingletonController : MonoBehaviour
{
    public static SingletonController singletonController;

    public Config config;
    public UIController UIController;
    public DataController dataController;
    public SaveLoadSystem saveLoadSystem;
    private void Awake()
    {
        if (!singletonController) singletonController = this;
        else Destroy(this);
    }
}
