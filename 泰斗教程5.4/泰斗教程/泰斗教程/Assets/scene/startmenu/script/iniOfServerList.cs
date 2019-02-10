using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class iniOfServerList : MonoBehaviour {

    public GameObject greenserver;
    public GameObject redserver;
    private int servernum = 2;
    private int count=0;
    public GameObject content;
    public GameObject currentserver;
    public GameObject seletedserver;

    // Use this for initialization
    void Start () {
        ServerListInit();
	}
	
	// Update is called once per frame
	void Update () {

	}
    public void ServerListInit()
    {
        for(int i=0;i<servernum;i++)
        {
            GameObject obj = null;
            if (count < 50)
                obj = Instantiate(greenserver);
            else
                obj = Instantiate(redserver);
            obj.transform.parent = content.transform;
            obj.transform.localScale = new Vector3(0.6521738f, 1.071429f, 1);
            obj.GetComponent<serverProperty>().ip = "";
        }
    }
}
