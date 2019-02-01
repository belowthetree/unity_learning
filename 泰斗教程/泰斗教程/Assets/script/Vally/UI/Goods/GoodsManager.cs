using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoodsManager : MonoBehaviour {

    public static GoodsManager instance;
    public TextAsset listinfo;
    public Dictionary<int, Goods> goodsDict = new Dictionary<int, Goods>();
    public Dictionary<int, GoodsItem> goodsItemDict = new Dictionary<int, GoodsItem>();
    public List<GoodsItem> goodsItemList = new List<GoodsItem>();

    public delegate void OnGoodsChangeEvent();
    public event OnGoodsChangeEvent OnGoodsChange;

    void Awake()
    {
        instance = this;
        ReadGoodsInfo();
        //foreach(Goods i in goodsDict.Values)
        //{
        //    print(i.Icon + i.EquipType);
        //}
    }

    void Start()
    {
        GetGoodsInfo();
        //foreach(GoodsItem i in goodsItemList)
        //{
        //    Debug.Log(i.Goods.Icon + i.Goods.EquipType);
        //}
    }

    void ReadGoodsInfo()
    {
        string str = listinfo.ToString();
        string[] itemStrArray = str.Split('\n');
        foreach(string itemStr in itemStrArray)
        {
            string[] proArray = itemStr.Split('|');
            Goods goods = new Goods();
            goods.ID = int.Parse(proArray[0]);
            goods.Name = proArray[1];
            goods.Icon = proArray[2];
            switch (proArray[3])
            {
                case "Equip":
                    goods.GoodsType = GoodsType.Equip;
                    break;
                case "Drug":
                    goods.GoodsType = GoodsType.Drug;
                    break;
                case "Box":
                    goods.GoodsType = GoodsType.Box;
                    break;
            }
            if(goods.GoodsType == GoodsType.Equip)
            {
                switch (proArray[4])
                {
                    case "Helm":
                        goods.EquipType = EquipType.Helm;
                        break;
                    case "Cloth":
                        goods.EquipType = EquipType.Clothes;
                        break;
                    case "Weapon":
                        goods.EquipType = EquipType.Weapon;
                        break;
                    case "Wing":
                        goods.EquipType = EquipType.Wings;
                        break;
                    case "Shoes":
                        goods.EquipType = EquipType.Shoes;
                        break;
                    case "Necklace":
                        goods.EquipType = EquipType.Necklace;
                        break;
                    case "Bracelet":
                        goods.EquipType = EquipType.Bracelet;
                        break;
                    case "Ring":
                        goods.EquipType = EquipType.Ring;
                        break;
                }
            }
            goods.Price = int.Parse(proArray[5]);
            if(goods.GoodsType == GoodsType.Equip)
            {
                goods.StartLevel = int.Parse(proArray[6]);
                goods.Quality = int.Parse(proArray[7]);
                goods.Damage = int.Parse(proArray[8]);
                goods.HP = int.Parse(proArray[9]);
                goods.Power = int.Parse(proArray[10]);
            }
            if(goods.GoodsType == GoodsType.Drug)
            {
                goods.ApplyValue = int.Parse(proArray[12]);
            }
            goods.Des = proArray[13];
            if(!goodsDict.ContainsKey(goods.ID))
                goodsDict.Add(goods.ID, goods);
        }
    }
    void GetGoodsInfo()
    {
        //随机生成主角拥有的物品
        for (int i = 0; i < 20; i++)
        {
            int id = Random.Range(1001, 1020);
            Goods ii = null;
            goodsDict.TryGetValue(id, out ii);
            if (ii.GoodsType == GoodsType.Equip)
            {
                GoodsItem it = new GoodsItem();
                it.Goods = ii;
                it.Rank = Random.Range(1, 10);
                it.Count = 1;
                if(!goodsItemDict.ContainsKey(id))
                    goodsItemDict.Add(id, it);
                goodsItemList.Add(it);
            }
            else
            {
                GoodsItem it = null;
                bool isExit = goodsItemDict.TryGetValue(id, out it);
                if (isExit)
                {
                    it.Count++;
                }
                else
                {
                    it = new GoodsItem();
                    it.Goods = ii;
                    it.Count = 1;
                    if(!goodsItemDict.ContainsKey(id))
                        goodsItemDict.Add(id, it);
                }
                GoodsItem tt = new GoodsItem();
                tt.Count = it.Count;
                tt.Rank = it.Rank;
                tt.Goods = it.Goods;
                goodsItemList.Add(tt);
            }
        }
        OnGoodsChange();
    }
    public bool GoodsReduce(GoodsItem it,int cnt)
    {
        for(int i = 0; i < goodsItemList.Count; i++)
        {
            if (goodsItemList[i].Goods.Name == it.Goods.Name)
            {
                if (goodsItemList[i].Count > cnt)
                {
                    goodsItemList[i].Count -= cnt;
                    return false;
                }
                else
                {
                    goodsItemList[i].Count = 0;
                    return true;
                }
            }
        }
        return false;
    }
    public void Change()
    {
        OnGoodsChange();
    }
}
