using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    public Animator anim;

    public void OnAttackButtonClick(PosType pos)
    {
        if (pos == PosType.Basic)
            anim.SetTrigger("Attack");
        else
        {
            anim.SetTrigger("Skill" + (int)pos);
        }
    }
}
