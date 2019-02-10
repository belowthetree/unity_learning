using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


    public float speed = 20;
    public Animator ani;
	// Use this for initialization
	void Start () {
        ani = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(-h * speed, rigidbody.velocity.y, -v * speed);
        if (rigidbody.velocity.magnitude > 0.005f)
        {
            ani.SetBool("move", true);
        }
        else if(rigidbody.velocity.magnitude<=0.005f)
        {
            ani.SetBool("move", false);
        }
        if(Mathf.Abs(h)>0.05f||Mathf.Abs(v)>0.05f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(-h, 0, -v));
        }
	}
}
