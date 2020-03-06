using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerGridView_2 : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler {

    public Transform trans_image;

    public Transform obj_temp;
    public Text text_itemType;

    Vector2 pos;
    Vector2 offset;

    Image _image;

    int itemId = -1;

    public ItemType_2 itemType;

    public string str_text_itemType
    {
        get
        {
            string temp = "";
            switch (itemType)
            {
                case ItemType_2.Armour:
                    temp = "铠甲";
                    break;
                case ItemType_2.Belt:
                    temp = "腰带";
                    break;
                case ItemType_2.Caliga:
                    temp = "战靴";
                    break;
                case ItemType_2.Headwear:
                    temp = "头饰";
                    break;
                case ItemType_2.Helmet:
                    temp = "头盔";
                    break;
                case ItemType_2.Necklace:
                    temp = "项链";
                    break;
                case ItemType_2.Ring:
                    temp = "戒指";
                    break;
                case ItemType_2.Weapon:
                    temp = "武器";
                    break;
            }
            return temp;
        }
    }

    private void Awake()
    {
        _image = trans_image.GetComponent<Image>();
        text_itemType.text = str_text_itemType;
        text_itemType.enabled = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateItem(int id, string spriteName)
    {
        this.itemId = id;
        if (itemId >= 0)
        {
            trans_image.gameObject.SetActive(true);
            Sprite sp = Resources.Load<Sprite>("Texture/Icon/" + spriteName);
            _image.sprite = sp;
            text_itemType.enabled = false;
        }
        else
        {
            trans_image.gameObject.SetActive(false);
            text_itemType.enabled = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, Input.mousePosition, eventData.pressEventCamera, out pos))
        {
            trans_image.localPosition = pos - offset;
        }
        text_itemType.enabled = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        trans_image.SetParent(obj_temp);
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, Input.mousePosition, eventData.pressEventCamera, out pos))
        {
            offset = pos - new Vector2(trans_image.localPosition.x, trans_image.localPosition.y);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.tag == "itemGrid")
        {
            Controller_2.Instance.UnloadItem(itemType);
        }

        trans_image.SetParent(transform);
        trans_image.localPosition = Vector2.zero;
        text_itemType.enabled = false;
    }
}
