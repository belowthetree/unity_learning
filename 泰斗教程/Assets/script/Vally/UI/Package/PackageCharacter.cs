using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PackageCharacter : MonoBehaviour {

    public Text hp;
    public Text exp;
    public Text damage;
    public Image expequip;
    public Text power;

    public CharacterEquip helm;
    public CharacterEquip clothes;
    public CharacterEquip weapon;
    public CharacterEquip shoes;
    public CharacterEquip necklace;
    public CharacterEquip bracelet;
    public CharacterEquip ring;
    public CharacterEquip wings;

    void Awake()
    {
        //clothes = GameObject.Find("img-character/obj-equip/img-clothes").GetComponent<CharacterEquip>();
        //helm = GameObject.Find("obj-package/img-character/obj-equip/img-helm").GetComponent<CharacterEquip>();
        //weapon = GameObject.Find("img-character/obj-equip/img-weapon").GetComponent<CharacterEquip>();
        //shoes = GameObject.Find("img-character/obj-equip/img-shoes").GetComponent<CharacterEquip>();
        //necklace = GameObject.Find("img-character/obj-equip/img-neckLace").GetComponent<CharacterEquip>();
        //bracelet = GameObject.Find("img-character/obj-equip/img-braceLet").GetComponent<CharacterEquip>();
        //ring = GameObject.Find("img-character/obj-equip/img-ring").GetComponent<CharacterEquip>();
        //wings = GameObject.Find("img-character/obj-equip/img-wings").GetComponent<CharacterEquip>();
        //expequip = GameObject.Find("img-character/txt-exp/img-foreground").GetComponent<Image>();
        //hp = GameObject.Find("img-character/txt-hp").GetComponent<Text>();
        //exp = GameObject.Find("img-character/txt-exp").GetComponent<Text>();
        //damage = GameObject.Find("img-character/txt-damage").GetComponent<Text>();

        PlayerInFo.instance.OnPlayerInfoChange += this.OnPlayerInfoChange;
    }

    void OnDestroy()
    {
        PlayerInFo.instance.OnPlayerInfoChange -= this.OnPlayerInfoChange;
    }

    void OnPlayerInfoChange(InfoType type)
    {
        PlayerInFo info = PlayerInFo.instance;
        if (type == InfoType.Helm)
            helm.SetGoodsItem(info.helm);
        if(type == InfoType.Clothes)
            clothes.SetGoodsItem(info.clothes);
        if (type == InfoType.Weapon)
            weapon.SetGoodsItem(info.weapon);
        if (type == InfoType.Wings)
            wings.SetGoodsItem(info.wings);
        if (type == InfoType.Shoes)
            shoes.SetGoodsItem(info.shoes);
        if (type == InfoType.Ring)
            ring.SetGoodsItem(info.ring);
        if (type == InfoType.Bracelet)
            bracelet.SetGoodsItem(info.bracelet);
        if (type == InfoType.Necklace)
            necklace.SetGoodsItem(info.necklace);

        power.text = info.Power.ToString();
        this.hp.text = info.HP.ToString();
        damage.text = info.Damage.ToString();
        expequip.fillAmount = (float)info.Exp / (float)GameController.GetExp(info.Level + 1);
        exp.text = info.Exp + "/" + GameController.GetExp(info.Level + 1);
        
    }

}
