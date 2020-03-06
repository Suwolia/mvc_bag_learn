using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnDestroy()
    {
        PlayerData_2.Instance.SaveData();
        BagItemData_2.Instance.SaveData();
    }
}
