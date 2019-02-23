using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private Dictionary<string, PlayerEffect> effectDict = new Dictionary<string, PlayerEffect>();
    public float distanceAttackForward = 2;
    public float distanceAttackAround = 2;
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
            gameObject.GetComponent<Transform>().Translate(Vector3.forward * moveForward);
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
        if (attackRange==AttackRange.Around)
        {
            foreach(GameObject go in TranscriptManager.instance.enemyList)
            {
                Vector3 pos = transform.InverseTransformPoint(go.transform.position);
                if (pos.z > -0.5f)
                {
                    float distance = Vector3.Distance(Vector3.zero, pos);
                    if(distance < distanceAttackForward)
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
