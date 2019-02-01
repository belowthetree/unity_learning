using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterEquip : MonoBehaviour {

    private Image img;
    public bool on=false;
    private GoodsItem it;
    public GameObject obj;
    public Image Img
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
    public GoodsItem It
    {
        get
        {
            return it;
        }
        set
        {
            it = value;
        }
    }
    
    public void SetGoodsItem(GoodsItem ii)
    {
        this.It = ii;
        on = true;
        Img.sprite = Resources.Load("Texture/002-mainmenu/equip/" + It.Goods.Icon, typeof(Sprite)) as Sprite;
    }

    public void OnClick()
    {
        if (this.GetComponent<CharacterEquip>().on != false)
        {
            obj.SetActive(true);
            obj.GetComponent<EquipInfo>().Show(it, false);
        }
    }

    public void OnClickClose()
    {
        gameObject.SetActive(false);
    }

}
