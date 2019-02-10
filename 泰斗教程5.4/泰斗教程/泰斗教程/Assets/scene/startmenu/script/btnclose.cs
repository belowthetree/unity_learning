using UnityEngine;
using System.Collections;

public class btnclose : MonoBehaviour {

	public GameObject login;
	public GameObject register;
	public GameObject selet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClik_Start_Cancel(){
		login.SetActive (false);
		selet.SetActive (true);
	}
	public void OnClik_Login_Cancel(){
		register.SetActive (false);
		login.SetActive (true);
		login.GetComponent<Animation> ().Play ();
	}
}
