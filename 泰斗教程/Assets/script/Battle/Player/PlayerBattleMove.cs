using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleMove : MonoBehaviour {

    public float speed = 5f;
    public Animator ani;
    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vec = this.GetComponent<Rigidbody>().velocity;

        if (!ani.GetCurrentAnimatorStateInfo(1).IsName("New State"))
            return;

        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            ani.SetBool("move", true);
            this.GetComponent<Rigidbody>().velocity = new Vector3(speed * h, vec.y, speed * v);
            transform.LookAt(new Vector3(h, 0, v) + transform.position);
        }
        else
        {
            ani.SetBool("move", false);
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, vec.y, 0);
        }
    }
}
