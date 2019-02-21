using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAutoMove : MonoBehaviour {

    public NavMeshAgent nav;
    public float minDes = 0.3f;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (nav.enabled && nav.remainingDistance < minDes &&nav.remainingDistance!=0)
        {
            nav.isStopped = true;
            nav.enabled = false;
            TaskManager.instance.OnArriveDesty();
        }
        
    }
    public void SetDestination(Vector3 vec)
    {
        nav.enabled = true;
        nav.SetDestination(vec);
    }
}
