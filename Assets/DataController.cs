using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public enum ItemTypes { box, coin }
    public List<ItemData> itemsData;

    public void ChangeItemData(ItemTypes _itemType, int _changeValue)
    {
        ItemData _data = FindDataByType(_itemType);
        _data.itemCount += _changeValue;
    }

    public ItemData FindDataByType(ItemTypes _itemType)
    {
        ItemData _data = new ItemData();

        for (int i = 0; i < itemsData.Count; i++)
            if (itemsData[i].itemType == _itemType) _data = itemsData[i];

        return _data;
    }
}
[System.Serializable] public class ItemData
{
    public DataController.ItemTypes itemType;
    public int itemCount;
}
