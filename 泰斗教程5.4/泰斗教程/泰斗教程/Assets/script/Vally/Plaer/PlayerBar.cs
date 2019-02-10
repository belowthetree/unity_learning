using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerBar : MonoBehaviour {

    private Image head;
    private Image energy;
    private Text energytxt;
    private Text exptxt;
    private Image experience;
    private Button energyplus;
    private Button expplus;
    private Text level;
    private Text name;
    public GameObject status;

    void Awake()
    {
        energytxt = transform.Find("img-energyBar/Text").GetComponent<Text>();
        exptxt = transform.Find("img-experience/Text").GetComponent<Text>();
        head = transform.Find("img-head").GetComponent<Image>();
        energy = transform.Find("img-energyBar").GetComponent<Image>();
        experience = transform.Find("img-experience").GetComponent<Image>();
        energyplus = transform.Find("img-energyBar/btn-plus").GetComponent<Button>();
        expplus = transform.Find("img-experience").GetComponent<Button>();
        level = GameObject.Find("Canvas/img-personInFo/txt-level").GetComponent<Text>();
        name = GameObject.Find("img-personInFo/txt-name").GetComponent<Text>();
        PlayerInFo.instance.OnPlayerInfoChange += this.OnPlayerInfoChange;
    }

    void OnDestroy()
    {
        PlayerInFo.instance.OnPlayerInfoChange -= this.OnPlayerInfoChange;
    }

    void OnPlayerInfoChange(InfoType type)
    {
        if(type == InfoType.All||
            type == InfoType.Coin||
            type == InfoType.Diamond||
            type == InfoType.Energy||
            type == InfoType.Exp||
            type == InfoType.Experience||
            type == InfoType.Head_portrait||
            type == InfoType.Level||
            type == InfoType.Power||
            type == InfoType.Name)
        {
            UpdateShow();
        }
    }
    void UpdateShow()
    {
        PlayerInFo info = PlayerInFo.instance;
        this.head = info.Head_portrait;
        this.name.text = info.Name;
        this.level.text = info.Level.ToString();
        this.experience.fillAmount = info.Experience / 50f;
        this.energy.fillAmount = info.Energy / 100f;
        this.energytxt.text = info.Energy.ToString() + "/100";
        this.exptxt.text = info.Experience.ToString() + "/50";
    }
    public void OnClickHead()
    {
        status.SetActive(true);
    }
}
