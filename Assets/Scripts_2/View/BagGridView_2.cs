using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BagGridView_2 : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler {

    public Transform trans_image;

    public Transform obj_temp;

    Vector2 pos;
    Vector2 offset;

    Image _image;

    int itemId = -1;

    private void Awake()
    {
        _image = trans_image.GetComponent<Image>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateItem(int id,string spriteName)
    {
        this.itemId = id;
        if (itemId >= 0)
        {
            trans_image.gameObject.SetActive(true);
            Sprite sp = Resources.Load<Sprite>("Texture/Icon/" + spriteName);
            _image.sprite = sp;
        }else
        {
            trans_image.gameObject.SetActive(false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, Input.mousePosition, eventData.pressEventCamera, out pos))
        {
            trans_image.localPosition = pos - offset;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        trans_image.SetParent(obj_temp);
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform,Input.mousePosition,eventData.pressEventCamera,out pos))
        {
            offset = pos - new Vector2(trans_image.localPosition.x, trans_image.localPosition.y);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.tag == "playerGrid")
        {
            Controller_2.Instance.EquipmentItem(this.itemId, eventData.pointerCurrentRaycast.gameObject.GetComponent<PlayerGridView_2>().itemType);
        }else if (eventData.pointerCurrentRaycast.gameObject.tag == "background")
        {
            Controller_2.Instance.SellItem(itemId);
        }
        trans_image.SetParent(transform);
        trans_image.localPosition = Vector2.zero;
        
    }

    
}
