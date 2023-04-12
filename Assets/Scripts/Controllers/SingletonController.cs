using UnityEngine;

public class SingletonController : MonoBehaviour
{
    public static SingletonController singletonController;

    public Config Config;
    public UIController UIController;
    public DataController DataController;
    public SaveLoadSystem SaveLoadSystem;

    private void Awake()
    {
        if (!singletonController) singletonController = this;
        else Destroy(this);
    }
}
