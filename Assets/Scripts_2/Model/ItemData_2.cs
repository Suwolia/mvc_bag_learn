using UnityEngine;
using System.Collections;

[System.Serializable]
public class ItemData_2  {

    [SerializeField]
    int id;

    [SerializeField]
    string name;

    [SerializeField]
    string spriteName;

    [SerializeField]
    ItemType_2 itemType;

    [SerializeField]
    int price;

    [SerializeField]
    float additionAtk;

    [SerializeField]
    float additionDefence;

    [SerializeField]
    float additionThump;

    [SerializeField]
    float additionHP;

    [SerializeField]
    float additionMP;

    [SerializeField]
    float additionAnger;

    public int Id
    {
        get
        {
            return id;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
    }

    public string SpriteName
    {
        get
        {
            return spriteName;
        }
    }

    public ItemType_2 ItemType
    {
        get
        {
            return itemType;
        }
    }

    public int Price
    {
        get
        {
            return price;
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

    public ItemData_2(int id, string spriteName)
    {
        this.id = id;
        this.spriteName = spriteName;
    }

    public ItemData_2(int id, string spriteName, ItemType_2 itemType)
    {
        this.id = id;
        this.spriteName = spriteName;
        this.itemType = itemType;
    }

    public ItemData_2(int id, string spriteName, ItemType_2 itemType, float additionAtk, float additionDefence, float additionThump, float additionHP, float additionMP, float additionAnger)
    {
        this.id = id;
        this.spriteName = spriteName;
        this.itemType = itemType;
        this.additionAtk = additionAtk;
        this.additionDefence = additionDefence;
        this.additionThump = additionThump;
        this.additionHP = additionHP;
        this.additionMP = additionMP;
        this.additionAnger = additionAnger;
    }

    public ItemData_2()
    {

    }
}
