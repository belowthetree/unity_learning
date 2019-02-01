using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveBattle : MonoBehaviour {

    public GameObject player;
    public float x, y, z;
    private Transform tf;
    // Use this for initialization
    void Start()
    {
        tf = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(x + tf.position.x, y + tf.position.y, z + tf.position.z);
    }
}
