using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour {

    private Text name;
    private Text level;
    private Text power;
    private Image exp;
    private Text exptxt;
    private Button changename;
    private Text diamondnum;
    private Text goldnum;
    private Button close;
    private Text energyrestore;
    private Text energyrestoreall;
    private Text exprestore;
    private Text exprestoreall;
    private Text experience;
    private Text energy;
    public GameObject changenamepnl;

    void Awake()
    {
        exptxt = GameObject.Find("txt-jy/Text").GetComponent<Text>();
        name = GameObject.Find("img-condition/txt-name").GetComponent<Text>();
        level = GameObject.Find("img-condition/txt-level").GetComponent<Text>();
        exp = GameObject.Find("img-condition/txt-jy/img-foreground").GetComponent<Image>();
        power = GameObject.Find("img-condition/power/Text").GetComponent<Text>();
        goldnum = GameObject.Find("img-condition/img-gold/num").GetComponent<Text>();
        diamondnum = GameObject.Find("img-condition/img-diamond/num").GetComponent<Text>();
        close = GameObject.Find("img-condition/btn-close").GetComponent<Button>();
        changename = GameObject.Find("img-condition/btn-changeName").GetComponent<Button>();
        exprestore = GameObject.Find("img-condition/txt-experience/txt-recoverTime/txt-num").GetComponent<Text>();
        exprestoreall = GameObject.Find("img-condition/txt-experience/txt-allRecoverTime/txt-num").GetComponent<Text>();
        energyrestore = GameObject.Find("img-condition/txt-energy/txt-recoverTime/txt-num").GetComponent<Text>();
        energyrestoreall = GameObject.Find("img-condition/txt-energy/txt-allRecoverTime/txt-num").GetComponent<Text>();
        energy = GameObject.Find("img-condition/txt-energy/txt-num").GetComponent<Text>();
        experience = GameObject.Find("img-condition/txt-experience/txt-num").GetComponent<Text>();
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
            type == InfoType.Power ||
            type == InfoType.Name)
        {
            UpdateShow();
        }
    }

    void UpdateShow()
    {
        PlayerInFo info = PlayerInFo.instance;
        this.name.text = info.Name;
        this.level.text = info.Level.ToString();
        this.energy.text = info.Energy + "/100";
        this.exp.fillAmount = info.Exp / ((float)(int.Parse(level.text) - 1) * (100f + (100f + 10f * (float.Parse(level.text) - 2f))) / 2f);
        this.exptxt.text = info.Exp + "/" + (int.Parse(level.text) - 1) * (100f + (100f + 10f * (float.Parse(level.text) - 2f))) / 2f;
        this.diamondnum.text = info.Diamond.ToString();
        this.goldnum.text = info.Coin.ToString();
        this.power.text = info.Power.ToString();
        this.experience.text = info.Experience + "/50";
    }
    void Start()
    {
        UpdateShow();
    }
    void Update()
    {
        PlayerInFo info = PlayerInFo.instance;
        this.energyrestore.text = "00:00:" + ((int)(60 - info.energyTimer)).ToString();
        this.exprestore.text = "00:00:" + ((int)(60 - info.expTimer)).ToString();
        int a = (int)(100 - info.Energy);
        this.energyrestoreall.text = a / 60 + ":" + a % 60 + ":00";
        a = (int)(100 - info.Experience);
        this.exprestoreall.text = a / 60 + ":" + a % 60 + ":00";
    }
    public void OnClickClose()
    {
        gameObject.SetActive(false);
    }
    public void OnClickChangeName()
    {
        changenamepnl.SetActive(true);
    }
    public void OnClickChangeNameClose()
    {
        changenamepnl.SetActive(false);
    }
    public void OnClikEnsure()
    {
        PlayerInFo.instance.Name = GameObject.Find("newName").GetComponent<Text>().text;
        PlayerInFo.instance.change(InfoType.Name);
        changenamepnl.SetActive(false);
    }
}
