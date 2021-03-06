﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private Dictionary<string, PlayerEffect> effectDict = new Dictionary<string, PlayerEffect>();
    public PlayerEffect[] effectArray;
    public float distanceAttackForward = 2;
    public float distanceAttackAround = 2;
    public int[] damageArray = new int[] { 20, 30, 30, 30 };
    public enum AttackRange
    {
        Forward,
        Around
    }

    void Start()
    {
        PlayerEffect[] peArray = this.GetComponentsInChildren<PlayerEffect>();
        foreach(PlayerEffect pe in peArray)
        {
            effectDict.Add(pe.gameObject.name, pe);
        }
        foreach(PlayerEffect pe in effectArray)
        {
            effectDict.Add(pe.gameObject.name, pe);
        }
    }

    public void ShowEffectDevilHand()
    {
        string effectName = "DevilHandMobile";
        PlayerEffect pe;
        effectDict.TryGetValue(effectName, out pe);
        ArrayList array = GetEnemyInAttackRange(AttackRange.Forward);
        foreach(GameObject go in array)
        {
            RaycastHit hit;
            bool collider = Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, 10f, LayerMask.GetMask("Ground"));
            if (collider)
            {
                GameObject.Instantiate(pe, go.transform.position, Quaternion.identity);
            }
        }
    }

    //0 normal skill1 skill2 skill3
    //1 effect name
    //2 sound
    //3 move forward
    //4 jump height
    void Attack(string args)
    {
        string[] proArray = args.Split(',');
        //1 show effect
        string effectName = proArray[1];
        ShowPlayerEffect(effectName);
        //2 play sound
        string soundName = proArray[2];
        SoundManager.instance.Play(soundName);
        //3 Move forward
        float moveForward = float.Parse(proArray[3]);
        if (moveForward > 0.1f)
        {
            ItweenMove.instance.Translate(this.gameObject, Vector3.forward * moveForward, 0.3f);
        }
        string posType = proArray[0];
        if (posType == "normal")
        {
            ArrayList array = GetEnemyInAttackRange(AttackRange.Forward);
            foreach(GameObject go in array)
            {
                go.SendMessage("TakeDamage", damageArray[0] + "," + proArray[3] + "," + proArray[4]);
            }
        }
    }

    void ShowPlayerEffect(string effectName)
    {
        PlayerEffect pe;
        if (effectDict.TryGetValue(effectName, out pe))
        {
            pe.Show();
        }
    }

    //得到在攻击范围内的敌人
    ArrayList GetEnemyInAttackRange(AttackRange attackRange)
    {
        ArrayList arrayList = new ArrayList();
        if (attackRange==AttackRange.Forward)
        {
            foreach(GameObject go in TranscriptManager.instance.enemyList)
            {
                Vector3 pos = this.transform.position - go.transform.position;
                pos = transform.InverseTransformDirection(pos);
                if (pos.z < 0.3f)
                {
                    Debug.Log(pos);
                    if(pos.magnitude < distanceAttackForward)
                    {
                        arrayList.Add(go);
                    }
                }
            }
        }
        else
        {
            foreach (GameObject go in TranscriptManager.instance.enemyList)
            {
                float distance = Vector3.Distance(Vector3.zero, go.transform.position);
                if (distance < distanceAttackAround)
                {
                    arrayList.Add(go);
                }
                
            }
        }
        return arrayList;
    }
}
