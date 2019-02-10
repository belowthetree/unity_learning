using UnityEngine;
using System.Collections;

public class GoodsItem : MonoBehaviour {

    private Goods goods;
    private int rank;
    private int count;
    private bool isdress;

    #region
    public bool Isdress
    {
        get
        {
            return isdress;
        }
        set
        {
            isdress = value;
        }
    }
    public int Rank
    {
        get
        {
            return rank;
        }
        set
        {
            rank = value;
        }
    }
    public int Count
    {
        get
        {
            return count;
        }
        set
        {
            count = value;
        }
    }
    public Goods Goods
    {
        get
        {
            return goods;
        }
        set
        {
            goods = value;
        }
    }
    #endregion
}
