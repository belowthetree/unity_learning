using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject damageEffectPrefab;
    public int hp = 200;


    //0 伤害
    //1 后退
    //2 浮空
    void TakeDamage(string args)
    {
        if (hp <= 0)
            return;
        string[] proArray = args.Split(',');
        //减去伤害值
        int damage = int.Parse(proArray[0]);
        hp -= damage;
        //受伤动画
        gameObject.GetComponent<Animation>().Play("takedamage");
        //后退和浮空
        float backDistance = float.Parse(proArray[1]);
        float jumpHeight = float.Parse(proArray[2]);
        gameObject.transform.Translate(this.gameObject.transform.TransformDirection(TranscriptManager.instance.player.transform.forward * backDistance) + Vector3.up * jumpHeight);
        //出血特效
        Destroy(GameObject.Instantiate(damageEffectPrefab, transform.position + new Vector3(0, 1f, 0), transform.rotation), 2f);
        if (hp <= 0)
            Dead();
    }

    void Dead()
    {

    }
}
