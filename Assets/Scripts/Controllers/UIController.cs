using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Joystick CharacterJoystick;
    public List<DataPanel> DataPanels;

    public void UpdateDataPanel(DataController.ItemTypes _itemType, float _count)
    {
        for (int i = 0; i < DataPanels.Count; i++)
            if (DataPanels[i].ItemType == _itemType)
                DataPanels[i].ItemCountText.text = _count.ToString();
    }
}

