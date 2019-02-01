using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum InfoType
{
    No,
    Wings,
    Weapon,
    Clothes,
    Bracelet,
    Necklace,
    Shoes,
    Ring,
    Helm,
    Name,
    Head_portrait,
    Level,
    Exp,
    Power,
    Diamond,
    Coin,
    Energy,
    Experience,
    Hp,
    Damage,
    All
}
public enum PlayerType
{
    Warrior,
    FemaleAssassin
}

public class PlayerInFo : MonoBehaviour {

    public static PlayerInFo instance;
    #region property
    private PlayerType playerType;
    private string name;
    private Image head_portrait;
    private int level = 1;
    private int exp = 0;
    private int power = 1;
    private int diamond = 0;
    private int coin = 0;
    private int energy;
    private int experience;
    private int hp;
    private int helmID;
    private int damage;
    private int clothesID;
    private int shoesID;
    private int necklaceID;
    private int braceletID;
    private int ringID;
    private int wingsID;
    private int weaponID;

    public GoodsItem helm;
    public GoodsItem clothes;
    public GoodsItem shoes;
    public GoodsItem necklace;
    public GoodsItem bracelet;
    public GoodsItem ring;
    public GoodsItem wings;
    public GoodsItem weapon;
    #endregion

    public delegate void OnPlayerInfoChangeEvent(InfoType type);
    public event OnPlayerInfoChangeEvent OnPlayerInfoChange;

    #region get set method
    public PlayerType PlayerType
    {
        get
        {
            return playerType;
        }
        set
        {
            playerType = value;
        }
    }
    public int WeaponID
    {
        get
        {
            return weaponID;
        }
        set
        {
            weaponID = value;
        }
    }
    public int BraceletID
    {
        get
        {
            return braceletID;
        }
        set
        {
            braceletID = value;
        }
    }
    public int NecklaceID
    {
        get
        {
            return necklaceID;
        }
        set
        {
            necklaceID = value;
        }
    }
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }
    public int RingID
    {
        get
        {
            return ringID;
        }
        set
        {
            ringID = value;
        }
    }
    public int WingsID
    {
        get
        {
            return wingsID;
        }
        set
        {
            wingsID = value;
        }
    }
    public int HelmID
    {
        get
        {
            return helmID;
        }
        set
        {
            helmID = value;
        }
    }
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    public int ClothesID
    {
        get
        {
            return clothesID;
        }
        set
        {
            clothesID = value;
        }
    }
    public int ShoesID
    {
        get
        {
            return shoesID;
        }
        set
        {
            shoesID = value;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    public Image Head_portrait
    {
        get
        {
            return head_portrait;
        }
        set
        {
            head_portrait = value;
        }
    }
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }
    public int Exp
    {
        get
        {
            return exp;
        }
        set
        {
            exp = value;
        }
    }
    public int Coin
    {
        get
        {
            return coin;
        }
        set
        {
            coin = value;
        }
    }
    public int Diamond
    {
        get
        {
            return diamond;
        }
        set
        {
            diamond = value;
        }
    }
    public int Energy
    {
        get
        {
            return energy;
        }
        set
        {
            energy = value;
        }
    }
    public int Experience
    {
        get
        {
            return experience;
        }
        set
        {
            experience = value;
        }
    }
    public int Power
    {
        get
        {
            return power;
        }
        set
        {
            power = value;
        }
    }
    #endregion

    public float energyTimer = 0;
    public float expTimer = 0;

    #region unity event
    void Start()
    {
        init();
    }
    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if(Energy<100)
        {
            energyTimer += Time.deltaTime;
            if(energyTimer > 60)
            {
                Energy += 1;
                energyTimer -= 60;
                OnPlayerInfoChange(InfoType.Energy);
            }
        }
        else
        {
            this.energyTimer = 0;
        }
        if(Experience <50)
        {
            expTimer += Time.deltaTime;
            if(expTimer >60)
            {
                Experience += 1;
                expTimer -= 60;
                OnPlayerInfoChange(InfoType.Experience);
            }
        }
        else
        {
            this.expTimer = 0;
        }
    }
    #endregion
    void init()
    {
        this.Coin = 9708;
        this.Diamond = 9802;
        this.Energy = 77;
        this.Exp = 23;
        this.Level = 2;
        //this.Head_portrait.sprite = Resources.Load("Texture/002-mainmenu/头像底板女性") as Sprite;
        this.Name = "米米米";
        this.Power = 1;
        this.Experience = 34;
        

        //InitHPDamagePower();

        OnPlayerInfoChange(InfoType.All);
    }
    public void change(InfoType type)
    {
        OnPlayerInfoChange(type);
    }



    void PutOffEquip(GoodsItem it)
    {
        this.HP -= it.Goods.HP;
        this.Damage -= it.Goods.Damage;
        this.Power -= it.Goods.Power;
    }

    public void DressOn(GoodsItem it)
    {
        this.HP += it.Goods.HP;
        this.Damage += it.Goods.Damage;
        this.Power += it.Goods.Power;
        for (int i= 0;i < GoodsManager.instance.goodsItemList.Count;i++)
        {
            if (GoodsManager.instance.goodsItemList[i].Goods.Icon == it.Goods.Icon)
            {
                GoodsManager.instance.goodsItemList.RemoveAt(i);
                break;
            }
        }
        GameObject img = GameObject.Find("obj-package/img-character/obj-equip/img-" + it.Goods.EquipType.ToString().ToLower());
        if (img.GetComponent<CharacterEquip>().on)
        {
            GoodsManager.instance.goodsItemList.Add(img.GetComponent<CharacterEquip>().It);
            PutOffEquip(img.GetComponent<CharacterEquip>().It);
        }
        img.GetComponent<CharacterEquip>().on = true;
        //img.GetComponent<Image>().sprite = Resources.Load("Texture/002-mainmenu/equip/" + it.Goods.Icon, typeof(Sprite)) as Sprite;
        switch (it.Goods.EquipType)
        {
            case EquipType.Wings:
                this.wings = it;
                OnPlayerInfoChange(InfoType.Wings);
                break;
            case EquipType.Weapon:
                this.weapon = it;
                OnPlayerInfoChange(InfoType.Weapon);
                break;
            case EquipType.Bracelet:
                this.bracelet = it;
                OnPlayerInfoChange(InfoType.Bracelet);
                break;
            case EquipType.Necklace:
                this.necklace = it;
                OnPlayerInfoChange(InfoType.Necklace);
                break;
            case EquipType.Ring:
                this.ring = it;
                OnPlayerInfoChange(InfoType.Ring);
                break;
            case EquipType.Clothes:
                this.clothes = it;
                OnPlayerInfoChange(InfoType.Clothes);
                break;
            case EquipType.Shoes:
                this.shoes = it;
                OnPlayerInfoChange(InfoType.Shoes);
                break;
            case EquipType.Helm:
                this.helm = it;
                OnPlayerInfoChange(InfoType.Helm);
                break;
        }
    }
    public void DressOff(GoodsItem it)
    {
        Image img = GameObject.Find("obj-package/img-character/obj-equip/img-" + it.Goods.EquipType.ToString().ToLower()).GetComponent<Image>();
        GoodsManager.instance.goodsItemList.Add(it);
        PutOffEquip(it);
        img.sprite = Resources.Load("Texture/002-mainmenu/bg_道具", typeof(Sprite)) as Sprite;
        img.GetComponent<CharacterEquip>().on = false;
        switch (it.Goods.EquipType)
        {
            case EquipType.Wings:
                this.wings = null;
                break;
            case EquipType.Weapon:
                this.weapon = null;
                break;
            case EquipType.Bracelet:
                this.bracelet = null;
                break;
            case EquipType.Necklace:
                this.necklace = null;
                break;
            case EquipType.Ring:
                this.ring = null;
                break;
            case EquipType.Clothes:
                this.clothes = null;
                break;
            case EquipType.Shoes:
                this.shoes = null;
                break;
            case EquipType.Helm:
                this.helm = null;
                break;
        }
        OnPlayerInfoChange(InfoType.No);
    }
}
