using System.Collections;
using UnityEngine;

public class ItemsChanger : MonoBehaviour, IInteractable
{
    [Header("Basic")]
    public DataController.ItemTypes TakeItemType;
    public DataController.ItemTypes GiveItemType;

    [HideInInspector] 
    public int TempItemCount = 0;

    private DataController dataController => SingletonController.singletonController.DataController;    
    private float sellDelay => SingletonController.singletonController.Config.ChangeDelay;

    public virtual void OnInteractStart()
    {
        StartCoroutine(Change());
    }

    private IEnumerator Change()
    {
        while (dataController.FindDataByType(TakeItemType).itemCount > 0)
        {
            float _sellDelayTemp = sellDelay;

            while (_sellDelayTemp > 0)
            {
                _sellDelayTemp -= Time.fixedDeltaTime;
                yield return null;
            }
            OnChange();
        }
    }

    public virtual void OnChange()
    {
        TempItemCount++;
        dataController.ChangeItemData(TakeItemType, -1);
        dataController.ChangeItemData(GiveItemType, 1);
    }

    public virtual void OnInteractEnd()
    {
        StopAllCoroutines();
    }
}
