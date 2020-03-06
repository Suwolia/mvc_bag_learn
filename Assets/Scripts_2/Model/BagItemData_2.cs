using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class BagItemData_2 {

    private BagItemData_2()
    {

    }

    private static BagItemData_2 _instance;

    public static BagItemData_2 Instance
    {
        get
        {
            if (null == _instance)
            {
                //_instance = new BagItemData_2();
                //_instance.items = new List<ItemData_2>();
                //ItemData_2 item1 = new ItemData_2(1, "FaShiYaoDai_06", ItemType_2.Belt, 10, 20, 30, 40, 50, 60);
                //ItemData_2 item2 = new ItemData_2(2, "DaJian_01", ItemType_2.Weapon, 70, 80, 30, 40, 20, 90);
                //ItemData_2 item3 = new ItemData_2(3, "DaJian_06", ItemType_2.Weapon, 70, 80, 30, 40, 20, 90);
                //ItemData_2 item4 = new ItemData_2(4, "FaShi_TouKui_4", ItemType_2.Helmet, 70, 80, 30, 40, 20, 90);
                //ItemData_2 item5 = new ItemData_2(5, "FaShi_TouKui_8", ItemType_2.Helmet, 70, 80, 30, 40, 20, 90);
                //ItemData_2 item6 = new ItemData_2(6, "DaJian_04", ItemType_2.Weapon, 70, 80, 30, 40, 20, 90);
                //_instance.items.Add(item1);
                //_instance.items.Add(item2);
                //_instance.items.Add(item3);
                //_instance.items.Add(item4);
                //_instance.items.Add(item5);
                //_instance.items.Add(item6);
                StreamReader sr = new StreamReader(Application.streamingAssetsPath + "/Json/BagItemsData.txt", Encoding.UTF8);
                try
                {
                    string json = sr.ReadToEnd();
                    _instance = JsonUtility.FromJson<BagItemData_2>(json);
                    if (_instance.items == null)
                    {
                        _instance.items = new List<ItemData_2>();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                sr.Close();
            }
            return _instance;
        }
    }

    public List<ItemData_2> items;

    public event Action updateDataEvent;

    public ItemData_2 GetItem(int id)
    {
        for(int i = 0; i < items.Count; ++i)
        {
            if (items[i].Id == id)
            {
                return items[i];
            }
        }
        return null;
    }

    public void AddItem(ItemData_2 data)
    {
        items.Add(data);

        if (null != updateDataEvent)
        {
            updateDataEvent();
        }
    }

    public void RemoveItem(ItemData_2 data)
    {
        items.Remove(data);

        if (null != updateDataEvent)
        {
            updateDataEvent();
        }
    }

    public void ExchangeItem(int index,ItemData_2 data)
    {
        if (index < items.Count)
        {
            items[index] = data;

            if (null != updateDataEvent)
            {
                updateDataEvent();
            }
        }
        else
        {
            Debug.Log("插入失败");
        }
    }

    public void ExchangeItemInBag(int id_1,int id_2)
    {
        ItemData_2 item_1 = GetItem(id_1);
        ItemData_2 item_2 = GetItem(id_2);
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(_instance, true);
        StreamWriter sw = new StreamWriter(Application.streamingAssetsPath + "/Json/BagItemsData.txt", false, Encoding.UTF8);
        try
        {
            sw.Write(json);
        }
        catch (Exception e)
        {
            throw e;
        }
        sw.Close();
    }
}
