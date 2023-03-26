using UnityEngine;

public class SingletonController : MonoBehaviour
{
    public static SingletonController singletonController;

    public Config config;
    public UIController UIController;
    public DataController dataController;

    private void Awake()
    {
        if (!singletonController) singletonController = this;
        else Destroy(this);
    }
}
