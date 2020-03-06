using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerView_2 : MonoBehaviour {

    /*    float atk;
    float defence;
    float thump;
    float hp;
    float mp;
    float anger;*/

    public Text text_atk;
    public Text text_defence;
    public Text text_thump;
    public Text text_hp;
    public Text text_mp;
    public Text text_anger;

    public PlayerGridView_2[] grids;

    private void Awake()
    {
        PlayerData_2.Instance.updateDataEvent += updatePanel;
    }
    // Use this for initialization
    void Start () {
        updatePanel();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnDestroy()
    {
        PlayerData_2.Instance.updateDataEvent -= updatePanel;
    }

    void updatePanel()
    {
        text_atk.text = "" + (int)PlayerData_2.Instance.Atk + "<color='green'>(+" + (int)PlayerData_2.Instance.AdditionAtk + ")</color>";
        text_defence.text = "" + (int)PlayerData_2.Instance.Defence + "<color='green'>(+" + (int)PlayerData_2.Instance.AdditionDefence + ")</color>";
        text_thump.text = "" + (int)PlayerData_2.Instance.Thump + "<color='green'>(+" + (int)PlayerData_2.Instance.AdditionThump + ")</color>";
        text_hp.text = "" + (int)PlayerData_2.Instance.Hp + "<color='green'>(+" + (int)PlayerData_2.Instance.AdditionHP + ")</color>";
        text_mp.text = "" + (int)PlayerData_2.Instance.Mp + "<color='green'>(+" + (int)PlayerData_2.Instance.AdditionMP + ")</color>";
        text_anger.text = "" + (int)PlayerData_2.Instance.Anger + "<color='green'>(+" + (int)PlayerData_2.Instance.AdditionAnger + ")</color>";

        for(int i = 0; i < grids.Length; ++i)
        {
            ItemData_2 temp = PlayerData_2.Instance.GetItem(grids[i].itemType);
            
            if (null != temp)
            {
                grids[i].UpdateItem(temp.Id, temp.SpriteName);
            }else
            {
                grids[i].UpdateItem(-1, "");
            }
        }

    }
}
