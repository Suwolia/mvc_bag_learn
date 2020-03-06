using UnityEngine;
using System.Collections;
using System;

public class Controller_2{

    private Controller_2()
    {

    }
    private static Controller_2 _instance;

    public static Controller_2 Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new Controller_2();
            }
            return _instance;
        }
    }

    public void EquipmentItem(int id,ItemType_2 gridType)
    {
        ItemData_2 item_bag = BagItemData_2.Instance.GetItem(id);
        int index_itemOfBag = BagItemData_2.Instance.items.IndexOf(item_bag);
        ItemData_2 item_player = PlayerData_2.Instance.GetItem(gridType);

        if (item_bag.ItemType == gridType)
        {
            if (null == item_player)
            {
                PlayerData_2.Instance.AddItem(item_bag);
                BagItemData_2.Instance.RemoveItem(item_bag);
            }
            else
            {
                PlayerData_2.Instance.RemoveItem(item_player);
                PlayerData_2.Instance.AddItem(item_bag);
                BagItemData_2.Instance.ExchangeItem(index_itemOfBag, item_player);
            }
        }else
        {
            Debug.Log("类型不对，无法装备");
        }
        Debug.Log("iii");
    }

    public void UnloadItem(ItemType_2 gridType)
    {
        ItemData_2 temp = PlayerData_2.Instance.GetItem(gridType);
        BagItemData_2.Instance.AddItem(temp);
        PlayerData_2.Instance.RemoveItem(temp);

    }

    public void SellItem(int id)
    {
        ItemData_2 temp = BagItemData_2.Instance.GetItem(id);
        BagItemData_2.Instance.RemoveItem(temp);
    }
}
