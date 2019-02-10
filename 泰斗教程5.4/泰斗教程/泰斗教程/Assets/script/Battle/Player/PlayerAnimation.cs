using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    public Animator anim;
    public void OnAttackButtonClick(bool isPress, PosType pos)
    {
        if(pos == PosType.Basic)
        {
            anim.SetTrigger("Attack");
        }
    }
}
