using UnityEngine;

public class SingletonController : MonoBehaviour
{
    public static SingletonController singletonController;

    private void Awake()
    {
        if (!singletonController) singletonController = this;
        else Destroy(this);
    }
}
