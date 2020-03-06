using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BagView_2 : MonoBehaviour {

    public BagGridView_2[] grids;

    public Text text_index_page;
    public Button btn_turnleft;
    public Button btn_turnright;

    int index_page=1;
    int index_page_max;

    private void Awake()
    {
        btn_turnleft.onClick.AddListener(onClick_left);
        btn_turnright.onClick.AddListener(onClick_right);
        BagItemData_2.Instance.updateDataEvent += UpdatePanel;
    }

    // Use this for initialization
    void Start () {
        UpdatePanel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnDestroy()
    {
        BagItemData_2.Instance.updateDataEvent -= UpdatePanel;
    }

    void UpdatePanel()
    {
        index_page_max = BagItemData_2.Instance.items.Count / grids.Length + (BagItemData_2.Instance.items.Count % grids.Length > 0 ? 1 : 0);
        text_index_page.text = index_page.ToString();

        int start_point = (index_page - 1) * grids.Length;
        for(int i = 0; i < grids.Length; ++i)
        {
            if (start_point + i < BagItemData_2.Instance.items.Count)
            {
                grids[i].UpdateItem(BagItemData_2.Instance.items[start_point + i].Id, BagItemData_2.Instance.items[start_point + i].SpriteName);
            }else
            {
                grids[i].UpdateItem(-1, "");
            }
        }
    }

    void onClick_left()
    {
        if (index_page > 1)
        {
            index_page--;
            UpdatePanel();
        }
    }

    void onClick_right()
    {
        if (index_page < index_page_max)
        {
            index_page++;
            UpdatePanel();
        }
    }

}
