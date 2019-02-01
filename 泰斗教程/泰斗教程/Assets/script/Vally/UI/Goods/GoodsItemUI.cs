using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoodsItemUI : MonoBehaviour {

    private Text num;
    private Image img;
    public GameObject obj1;
    public GameObject obj2;
    private GoodsItem it;
    
    private Text Num
    {
        get
        {
            if (num == null)
                num = this.transform.FindChild("txt-num").GetComponent<Text>();
            return num;
        }
        set
        {
            num = value;
        }
    }
    private Image Img
    {
        get
        {
            if (img == null)
                img = this.GetComponent<Image>();
            return img;
        }
        set
        {
            img = value;
        }
    }

    void Awake()
    {

    }

    public void SetGoodsItem(GoodsItem it)
    {
        this.it = it;
        Img.sprite = Resources.Load("Texture/002-mainmenu/equip/" + it.Goods.Icon, typeof(Sprite)) as Sprite;
        Num.text = it.Count.ToString();
    }

    public void Clear()
    {
        Num.text = "";
        Img.sprite = Resources.Load("Texture/002-mainmenu/bg_道具", typeof(Sprite)) as Sprite;
    }
    public void OnClickItem()
    {
        //Debug.Log(it.Goods.EquipType);
        if (it.Goods.GoodsType == GoodsType.Equip)
        {
            obj1.SetActive(true);
            obj1.GetComponent<EquipInfo>().Show(it, true);
        }
        else if(it.Goods.GoodsType == GoodsType.Drug)
        {
            obj2.SetActive(true);
            obj2.GetComponent<objInfo>().Show(it);
        }
        transform.parent.parent.parent.parent.GetComponent<PackageUI>().ShowPrice(this.it);
    }
}
