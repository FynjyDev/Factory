using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public enum ItemTypes { box, coin }
    public List<ItemData> itemsData;

    private UIController _UIController => SingletonController.singletonController.UIController;
    private SaveLoadSystem _SaveLoadSystem => SingletonController.singletonController.saveLoadSystem;

    public void Start()
    {
        LoadAllData();
    }

    public void ChangeItemData(ItemTypes _itemType, int _changeValue)
    {
        ItemData _data = FindDataByType(_itemType);
        _data.itemCount += _changeValue;

        _UIController.UpdateDataPanel(_itemType, _data.itemCount);
        _SaveLoadSystem.Save(itemsData);
    }

    public ItemData FindDataByType(ItemTypes _itemType)
    {
        ItemData _data = new ItemData();

        for (int i = 0; i < itemsData.Count; i++)
            if (itemsData[i].itemType == _itemType) _data = itemsData[i];

        return _data;
    }

    private void LoadAllData()
    {
        List<ItemData> _loadInfo = _SaveLoadSystem.Load();

        if (_loadInfo != null && _loadInfo.Count > 0)itemsData = _loadInfo;
        else _SaveLoadSystem.Save(itemsData);

        for (int i = 0; i < itemsData.Count; i++)
            _UIController.UpdateDataPanel(itemsData[i].itemType, itemsData[i].itemCount);
    }
}
[System.Serializable] public class ItemData
{
    public DataController.ItemTypes itemType;
    public int itemCount;
}
