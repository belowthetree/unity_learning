using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillPanelUI : MonoBehaviour {

    public Text skillName;
    public Text skillDes;
    public Button Close;
    public Button Upgrade;
    public Text UpgradeTxt;
    public Skill skill;

    void Awake()
    {
        skillName.text = "";
        skillDes.text = "";
        DiasableUpgradeButton("请选择技能");
    }

    void DiasableUpgradeButton(string label="")
    {
        Upgrade.interactable = false;
        Upgrade.GetComponent<Image>().sprite = Upgrade.spriteState.disabledSprite;
        if (label != "")
        {
            UpgradeTxt.text = label;
        }
    }

    void EnableUpgradeButton(string label = "")
    {
        Upgrade.interactable = true;
        Upgrade.GetComponent<Image>().sprite = Upgrade.spriteState.highlightedSprite;
        if (label != "")
        {
            UpgradeTxt.text = label;
        }
    }

    public void OnSkillClick(Skill skill)
    {
        this.skill = skill;
        PlayerInFo info = PlayerInFo.instance;
        if (info.Coin >= 500 * (skill.Level + 1))
        {
            if (skill.Level <= info.Level)
                EnableUpgradeButton("升级技能");
            else
                DiasableUpgradeButton("最大等级");
        }
        else
            DiasableUpgradeButton("金币不足");
        skillName.text = skill.Name + "Lv." + skill.Level;
        skillDes.text = "当前技能的攻击力为" + (skill.Damage * skill.Level) + "下一级技能攻击力为" + skill.Damage * (skill.Level + 1) + "升级所需金币数量："
            + (500 * (skill.Level + 1));
    }
    void OnUpgrade()
    {
        PlayerInFo info = PlayerInFo.instance;
        if (skill.Level <= info.Level)
        {
            int coinNeed = 500 * (skill.Level + 1);
            if (coinNeed <= info.Coin)
            {
                skill.UpGrade();
                OnSkillClick(skill);
                info.Coin -= coinNeed;
                info.change(InfoType.Coin);
            }
        }
        else
            DiasableUpgradeButton("最大等级");
    }
    public void OnPanelShow()
    {
        this.GetComponent<Animation>().Play("SkillShow");
    }
    public void OnPanelHide()
    {
        this.GetComponent<Animation>().Play("SkillHide");
    }
}
