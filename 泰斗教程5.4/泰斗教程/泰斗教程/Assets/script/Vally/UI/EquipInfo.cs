using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class EquipInfo : MonoBehaviour {

    private GoodsItem it;
    private Image equipimg;
    private Text nametxt;
    private Text ranktxt;
    private Text damagetxt;
    private Text hptxt;
    private Text powertxt;
    private Text destxt;
    private Text qualitytxt;
    public GameObject inform;

    void Awake()
    {
        equipimg = transform.Find("img-equip").GetComponent<Image>();
        nametxt = transform.Find("txt-name").GetComponent<Text>();
        damagetxt = transform.Find("txt-damage/txt").GetComponent<Text>();
        powertxt = transform.Find("txt-power/txt").GetComponent<Text>();
        hptxt = transform.Find("txt-hp/txt").GetComponent<Text>();
        destxt = transform.Find("txt-inFo").GetComponent<Text>();
        ranktxt = transform.Find("txt-rank/txt").GetComponent<Text>();
        qualitytxt = transform.Find("txt-quality/txt").GetComponent<Text>();

    }

    public void Show(GoodsItem it, bool isLeft)
    {
        if (isLeft)
        {
            this.transform.localPosition = new Vector3(-Math.Abs(transform.localPosition.x), transform.localPosition.y, transform.localPosition.z);
            this.transform.Find("btn-use/Text").GetComponent<Text>().text = "装备";
        }
        else
        {
            this.transform.localPosition = new Vector3(Math.Abs(transform.localPosition.x), transform.localPosition.y, transform.localPosition.z);
            this.transform.Find("btn-use/Text").GetComponent<Text>().text = "卸下";
        }

        //Debug.Log(it.Goods.EquipType);
        equipimg.sprite = Resources.Load("Texture/002-mainmenu/equip/" + it.Goods.Icon, typeof(Sprite)) as Sprite;
        nametxt.text = it.Goods.Name;
        hptxt.text = it.Goods.HP.ToString();
        damagetxt.text = it.Goods.Damage.ToString();
        powertxt.text = it.Goods.Power.ToString();
        destxt.text = it.Goods.Des;
        qualitytxt.text = it.Goods.Quality.ToString();
        this.it = it;
        //if (this.it == null)
        //    Debug.Log(this.it.Goods.Icon);
    }

    public void OnClickClose()
    {
        this.gameObject.SetActive(false);
    }

    public void OnEquip()
    {
        if (transform.Find("btn-use/Text").GetComponent<Text>().text == "装备")
            PlayerInFo.instance.DressOn(it);
        else
            PlayerInFo.instance.DressOff(it);
        gameObject.SetActive(false);
    }
    public void OnUpgrade()
    {
        int cost = it.Goods.Price * (it.Rank + 1);
        if (cost <= PlayerInFo.instance.Coin)
        {
            PlayerInFo.instance.Coin -= cost;
            PlayerInFo.instance.change(InfoType.Coin);
        }
        else
            OnCoidInNeed();
    }
    public void OnEnterUpgrade()
    {
        transform.Find("btn-upRank/Text").GetComponent<Text>().text = (it.Goods.Price * (it.Rank + 1)).ToString();
    }
    public void OnExitUpgrade()
    {
        transform.Find("btn-upRank/Text").GetComponent<Text>().text = "升级";
    }
    public void OnCoidInNeed()
    {
        inform.SetActive(true);
        inform.GetComponent<Animation>().Play();
        Invoke("Close", 1.5f);
    }
    public void Close()
    {
        inform.SetActive(false);
    }
}
