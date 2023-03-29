using System.Collections;
using UnityEngine;

public class ItemsChanger : MonoBehaviour, IInteractable
{
    [Header("Basic")]
    public DataController.ItemTypes takeItemType;
    public DataController.ItemTypes giveItemType;

    public int tempItemCount;

    private DataController _DataController => SingletonController.singletonController.dataController;    
    private float _SellDelay => SingletonController.singletonController.config.changeDelay;

    public virtual void OnInteractStart()
    {
        StartCoroutine(Change());
    }

    private IEnumerator Change()
    {
        ItemData _itemData = _DataController.FindDataByType(takeItemType);

        if (_itemData.itemCount > 0) yield return null;

        while (_itemData.itemCount > 0)
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
        _DataController.ChangeItemData(takeItemType, -1);
        _DataController.ChangeItemData(giveItemType, 1);
        tempItemCount++;
    }

    public virtual void OnInteractEnd()
    {
        StopAllCoroutines();
    }
}
