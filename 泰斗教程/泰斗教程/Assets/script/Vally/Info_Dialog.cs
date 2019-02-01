using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info_Dialog : MonoBehaviour {

    public Text des;
    public Text energy_des;
    public Button enter;
    public Text energy_num;
    public Text welcome;
    public static Info_Dialog instance;

    // Use this for initialization
    void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {

    }
    public void ShowWarn()
    {
        des.text = "当前等级无法进入地下城";

        energy_des.gameObject.SetActive(false);
        enter.gameObject.SetActive(false);
        welcome.gameObject.SetActive(false);
        this.GetComponent<Animation>().Play("MapInfoShow");
    }

    public void ShowDialog(img_transport img_Transport)
    {
        energy_des.gameObject.SetActive(true);
        enter.gameObject.SetActive(true);
        welcome.gameObject.SetActive(true);

        des.text = img_Transport.des;
        energy_num.text = "3";
        this.GetComponent<Animation>().Play("MapInfoShow");
    }
    
    public void OnEnter()
    {
        this.GetComponent<Animation>().Play("MapInfoShow");
    }
    public void OnClose()
    {
        this.GetComponent<Animation>().Play("MapInfoHide");
    }
}
