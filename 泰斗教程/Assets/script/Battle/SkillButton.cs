using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {

    public PosType pos = PosType.Basic;
	public PlayerAnimation playerAnimation;
    public float coldTime = 4f;
    public float coldTimer = 0;
    public Image mask;
    public bool isPress = false;
    
    void Update()
    {
        if (mask == null)
            return;
        if(coldTimer>0)
        {
            coldTimer -= Time.deltaTime;
            mask.fillAmount = coldTimer/coldTime;
        }
        else
        {
            isPress = false;
            mask.fillAmount = 0;
            this.GetComponent<Button>().interactable = true;
        }
    }

    public void OnPress()
    {
        if (isPress == false&&mask!=null)
        {
            isPress = true;
            playerAnimation.OnAttackButtonClick(isPress, pos);
            coldTimer = coldTime;
            this.GetComponent<Button>().interactable = false;
        }
    }
}
