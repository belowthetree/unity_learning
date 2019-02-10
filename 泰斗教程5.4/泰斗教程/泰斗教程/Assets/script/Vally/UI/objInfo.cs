using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class objInfo : MonoBehaviour {

    public Text name;
    public Text des;
    public Image img;
    public GoodsItem item;
    public GameObject inform;

    public void Show(GoodsItem it)
    {
        item = it;
        name.text = it.Goods.Name;
        des.text = it.Goods.Des;
        img.sprite = Resources.Load("Texture/002-mainmenu/equip/" + it.Goods.Icon, typeof(Sprite)) as Sprite;
    }

    public void OnClickUse()
    {
        if(item.Count <=0)
        {
            inform.SetActive(true);
            return;
        }
        switch (item.Goods.InfoType.ToString())
        {
            case "Energy":
                PlayerInFo.instance.Energy += item.Goods.ApplyValue;
                break;
            case "HP":
                PlayerInFo.instance.HP += item.Goods.ApplyValue;
                break;
        }
        GoodsManager.instance.GoodsReduce(item, 1);
        GoodsManager.instance.Change();
        PlayerInFo.instance.change(InfoType.Hp);
    }

    public void OnClickUseMany()
    {
        if(item.Count <=0)
        {
            inform.SetActive(true);
            return;
        }
        int a = int.Parse(transform.Find("InputField/Text").GetComponent<Text>().text);
        if (GoodsManager.instance.GoodsReduce(item, a))
        {
            for(int i = 0; i < a; i++)
            {
                switch(item.Goods.InfoType.ToString())
                {
                    case "Energy":
                        PlayerInFo.instance.Energy += item.Goods.ApplyValue;
                        break;
                    case "HP":
                        PlayerInFo.instance.HP += item.Goods.ApplyValue;
                        break;
                }
            }
        }
        else
        {
            for (int i = 0; i < item.Count; i++)
            {
                switch (item.Goods.InfoType.ToString())
                {
                    case "Energy":
                        PlayerInFo.instance.Energy += item.Goods.ApplyValue;
                        break;
                    case "HP":
                        PlayerInFo.instance.HP += item.Goods.ApplyValue;
                        break;
                }
            }
        }
        GoodsManager.instance.Change();
        PlayerInFo.instance.change(InfoType.Hp);
    }
    public void OnClickClose()
    {
        transform.parent.GetComponent<PackageUI>().ClearPrice();
        gameObject.SetActive(false);
    }
}
