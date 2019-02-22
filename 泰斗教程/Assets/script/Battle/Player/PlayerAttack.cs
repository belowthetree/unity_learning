using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private Dictionary<string, PlayerEffect> effectDict = new Dictionary<string, PlayerEffect>();

    void Start()
    {

    }

	//0 normal skill1 skill2 skill3
    //1 effect name
    //2 sound
    //3 move forward
    //4 jump height
    void Attack(string args)
    {

    }
}
