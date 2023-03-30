using System.Collections;
using UnityEngine;

public class ItemsChanger : MonoBehaviour, IInteractable
{
    [Header("Basic")]
    public DataController.ItemTypes takeItemType;
    public DataController.ItemTypes giveItemType;

    public int tempItemCount = 0;

    private DataController _DataController => SingletonController.singletonController.dataController;    
    private float _SellDelay => SingletonController.singletonController.config.changeDelay;

    public virtual void OnInteractStart()
    {
        StartCoroutine(Change());
    }

    private IEnumerator Change()
    {
        while (_DataController.FindDataByType(takeItemType).itemCount > 0)
        {
            float _sellDelayTemp = _SellDelay;

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
        tempItemCount++;
        _DataController.ChangeItemData(takeItemType, -1);
        _DataController.ChangeItemData(giveItemType, 1);
    }

    public virtual void OnInteractEnd()
    {
        StopAllCoroutines();
    }
}
