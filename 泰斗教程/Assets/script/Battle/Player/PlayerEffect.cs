using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour {


    public Renderer[] renderers;
    public NcCurveAnimation[] ncCurveAnimations;

	// Use this for initialization
	void Start () {
        renderers = this.GetComponentsInChildren<Renderer>();
        ncCurveAnimations = this.GetComponentsInChildren<NcCurveAnimation>();
	}
	
    void Update()
    {
        
    }

	public void Show()
    {
        foreach(Renderer renderer in renderers)
        {
            renderer.enabled = true;
        }
        foreach(NcCurveAnimation anim in ncCurveAnimations)
        {
            anim.ResetAnimation();
        }
    }
}
