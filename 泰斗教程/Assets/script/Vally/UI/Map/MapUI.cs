using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapUI : MonoBehaviour {

    public static MapUI instance;
    

    void Awake()
    {
        instance = this;
    }


    public void Show()
    {
        this.GetComponent<Animation>().Play("MapShow");
    }
    public void Hide()
    {
        this.GetComponent<Animation>().Play("MapHide");
    }

    public void OnTransportClick(img_transport img_Transport)
    {
        Debug.Log("a");
        PlayerInFo info = PlayerInFo.instance;

        if (info.Level >= img_Transport.needLevel)
        {
            Info_Dialog.instance.ShowDialog(img_Transport);
        }
        else
            Info_Dialog.instance.ShowWarn();
    }
}
