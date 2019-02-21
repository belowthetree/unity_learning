using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TopBar : MonoBehaviour {

    private Text coinnum;
    private Text diamondnum;
    private Button coinbtn;
    private Button diamondbtn;

    void Awake()
    {
        diamondnum = GameObject.Find("TopBar/img-diamond/Text").GetComponent<Text>();
        diamondbtn = GameObject.Find("TopBar/img-diamond/btn-plus").GetComponent<Button>();
        coinnum = GameObject.Find("TopBar/img-gold/Text").GetComponent<Text>();
        coinbtn = GameObject.Find("TopBar/img-gold/btn-plus").GetComponent<Button>();
        PlayerInFo.instance.OnPlayerInfoChange += this.OnPlayerInfoChange;
    }

    void OnDestroy()
    {
        PlayerInFo.instance.OnPlayerInfoChange -= this.OnPlayerInfoChange;
    }

    void OnPlayerInfoChange(InfoType type)
    {
        if (type == InfoType.All ||
            type == InfoType.Coin ||
            type == InfoType.Diamond ||
            type == InfoType.Energy ||
            type == InfoType.Exp ||
            type == InfoType.Experience ||
            type == InfoType.Head_portrait ||
            type == InfoType.Level ||
            type == InfoType.Name ||
            type == InfoType.Power)
            UpdateShow();
    }
    void UpdateShow()
    {
        PlayerInFo info = PlayerInFo.instance;
        this.coinnum.text = info.Coin.ToString();
        this.diamondnum.text = info.Diamond.ToString();
    }
}
