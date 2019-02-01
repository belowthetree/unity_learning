using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class forCurrentBtn : MonoBehaviour {

    public GameObject selectedserver;
    public GameObject currentserver;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnSelectServer(GameObject obj)
    {
        selectedserver = obj;
        if (selectedserver != currentserver)
        {
            currentserver.GetComponent<Button>().GetComponent<Image>().sprite = selectedserver.GetComponent<Button>().GetComponent<Image>().sprite;
            currentserver.GetComponent<Button>().GetComponent<Button>().spriteState = selectedserver.GetComponent<Button>().GetComponent<Button>().spriteState;
            currentserver.transform.Find("Text").GetComponent<Text>().text = selectedserver.transform.Find("Text").GetComponent<Text>().text;
            currentserver.GetComponent<serverProperty>().ip = selectedserver.GetComponent<serverProperty>().ip;
        }
    }
}
