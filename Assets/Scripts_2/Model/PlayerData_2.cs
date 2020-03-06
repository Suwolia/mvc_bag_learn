using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;

public class PlayerData_2 {

    float atk;
    float defence;
    float thump;
    float hp;
    float mp;
    float anger;

    float additionAtk;
    float additionDefence;
    float additionThump;
    float additionHP;
    float additionMP;
    float additionAnger;

    public List<ItemData_2> items;

    public event Action updateDataEvent;

    static PlayerData_2 _instance;

    public static PlayerData_2 Instance
    {
        get
        {
            if (null == _instance)
            {
                //_instance = new PlayerData_2();
                //_instance.items = new List<ItemData_2>();
                //ItemData_2 item1 = new ItemData_2(1, "FaShiYaoDai_06", ItemType_2.Belt, 10, 20, 30, 40, 50, 60);
                //ItemData_2 item2 = new ItemData_2(2, "DaJian_04", ItemType_2.Weapon, 70, 80, 30, 40, 20, 90);
                //ItemData_2 item3 = new ItemData_2(10, "FaShi_BeiJia_1", ItemType_2.Headwear, 10, 10, 10, 10, 10, 10);
                //_instance.items.Add(item1);
                //_instance.items.Add(item2);
                //_instance.items.Add(item3);

                StreamReader sr = new StreamReader(Application.streamingAssetsPath + "/Json/PlayerData.txt", Encoding.UTF8);
                try
                {
                    string json = sr.ReadToEnd();
                    _instance = JsonUtility.FromJson<PlayerData_2>(json);
                    if (_instance.items == null)
                    {
                        _instance.items = new List<ItemData_2>();
                    }
                }catch(Exception e)
                {
                    throw e;
                }
                sr.Close();
                _instance.UpdateAdditionData();
            }
            return _instance;
        }
    }



    PlayerData_2()
    {

    }
    PlayerData_2(float atk, float defence, float thump, float hp, float mp, float anger)
    {
        this.atk = atk;
        this.defence = defence;
        this.thump = thump;
        this.hp = hp;
        this.mp = mp;
        this.anger = anger;
    }

    void UpdateAdditionData()
    {
        additionAtk = 0;
        additionDefence = 0;
        additionThump = 0;
        additionHP = 0;
        additionMP = 0;
        additionAnger = 0;
        for (int i = 0; i < items.Count; ++i)
        {
            additionAtk += items[i].AdditionAtk;
            additionDefence += items[i].AdditionDefence;
            additionThump += items[i].AdditionThump;
            additionHP += items[i].AdditionHP;
            additionMP += items[i].AdditionMP;
            additionAnger += items[i].AdditionAnger;
        }
    }

    public ItemData_2 GetItem(ItemType_2 itemType)
    {
        for(int i = 0; i < items.Count; ++i)
        {
            if (items[i].ItemType == itemType)
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
            UpdateAdditionData();
            updateDataEvent();
        }
    }

    public void RemoveItem(ItemData_2 data)
    {
        items.Remove(data);

        if (null != updateDataEvent)
        {
            UpdateAdditionData();
            updateDataEvent();
        }
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(_instance, true);
        StreamWriter sw = new StreamWriter(Application.streamingAssetsPath + "/Json/PlayerData.txt", false, Encoding.UTF8);
        try
        {
            sw.Write(json);
        }catch(Exception e)
        {
            throw e;
        }
        sw.Close();
    }


    public float Atk
    {
        get
        {
            return atk;
        }
    }

    public float Defence
    {
        get
        {
            return defence;
        }
    }

    public float Thump
    {
        get
        {
            return thump;
        }
    }

    public float Hp
    {
        get
        {
            return hp;
        }
    }

    public float Mp
    {
        get
        {
            return mp;
        }
    }

    public float Anger
    {
        get
        {
            return anger;
        }
    }

    public float AdditionAtk
    {
        get
        {
            return additionAtk;
        }
    }

    public float AdditionDefence
    {
        get
        {
            return additionDefence;
        }
    }

    public float AdditionThump
    {
        get
        {
            return additionThump;
        }
    }

    public float AdditionHP
    {
        get
        {
            return additionHP;
        }
    }

    public float AdditionMP
    {
        get
        {
            return additionMP;
        }
    }

    public float AdditionAnger
    {
        get
        {
            return additionAnger;
        }
    }
}
