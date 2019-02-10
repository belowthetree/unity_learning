using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class img_transport : MonoBehaviour {

    public int id;
    public int needLevel;
    public string sceneName="地下";
    public string des="嘿嘿嘿";

    public void OnClick()
    {
        MapUI.instance.OnTransportClick(this);
    }

}
