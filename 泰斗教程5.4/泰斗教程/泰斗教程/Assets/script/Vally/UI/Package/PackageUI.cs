using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class PackageUI : MonoBehaviour {

    public List<GoodsItemUI> itemUIList = new List<GoodsItemUI>();
    public GameObject package;
    public Text num;
    public Text price;

    void Awake()
    {
        GoodsManager.instance.OnGoodsChange += this.OnGoodsChange;
        PlayerInFo.instance.OnPlayerInfoChange += this.OnPlayerInfoChange;
    }

    void OnDestroy()
    {
        GoodsManager.instance.OnGoodsChange -= this.OnGoodsChange;
    }

    void OnGoodsChange()
    {
        UpdateShow();
    }
    void OnPlayerInfoChange(InfoType type)
    {
        if(type == InfoType.Helm||
            type == InfoType.Clothes||
            type == InfoType.Weapon||
            type == InfoType.Shoes||
            type == InfoType.Ring||
            type == InfoType.Necklace||
            type == InfoType.Bracelet||
            type == InfoType.Wings||
            type == InfoType.No)
            UpdateShow();
    }

    void UpdateShow()
    {
        for (int i = 0; i < GoodsManager.instance.goodsItemList.Count; i++)
            if (GoodsManager.instance.goodsItemList[i].Count == 0)
                GoodsManager.instance.goodsItemList.RemoveAt(i);
        for (int i = 0; i < GoodsManager.instance.goodsItemList.Count; i++)
        {
            GoodsItem it = GoodsManager.instance.goodsItemList[i];
            itemUIList[i].SetGoodsItem(it);
        }
        for(int i = GoodsManager.instance.goodsItemList.Count; i < itemUIList.Count; i++)
        {
            itemUIList[i].Clear();
        }
        num.text = GoodsManager.instance.goodsItemList.Count + "/35";
    }
    public void OnClickClose()
    {
        package.GetComponent<Animation>().Stop();
        package.GetComponent<Animation>().Play("PackageUp");
    }
    public void OnClickSell()
    {
        if (price.text == "")
            return;
        PlayerInFo.instance.Coin = ((int)PlayerInFo.instance.Coin + int.Parse(price.text));
        if (this.transform.Find("img-package/img-objectInfo").GetComponent<objInfo>().item.Count==0)
            price.text = "";
        PlayerInFo.instance.change(InfoType.Coin);
    }
    public void ShowPrice(GoodsItem it)
    {
        price.text = it.Goods.Price.ToString();
    }
    public void ClearPrice()
    {
        price.text = "";
    }
}
