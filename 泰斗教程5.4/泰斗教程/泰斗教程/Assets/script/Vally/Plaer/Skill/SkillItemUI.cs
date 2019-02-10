using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillItemUI : MonoBehaviour {

    public PosType PosType;
    public Skill skill;
    public Image img;
    public Image Img
    {
        get
        {
            if (img == null)
                img = this.GetComponent<Image>();
            return img;
        }
    }
    void Start()
    {
        UpdateShow();
    }
	void UpdateShow()
    {
        skill = SkillManager.instance.GetSkillByPosition(PosType);
        Img.GetComponent<Image>().sprite = Resources.Load("Texture/004-skill icon/" + skill.Icon, typeof(Sprite)) as Sprite;
    }

    public void OnClick(bool isPress)
    {
        if (isPress)
        {
            transform.parent.parent.SendMessage("OnSkillClick", skill);
        }
    }
}
