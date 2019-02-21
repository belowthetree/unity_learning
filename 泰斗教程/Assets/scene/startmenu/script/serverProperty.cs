using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class serverProperty : MonoBehaviour {

    public string _name;
    public string ip;
	public string name
    {
        set
        {
            transform.FindChild("Text").GetComponent<Text>().text = value;
            _name = value;
        }
        get
        {
            return _name;
        }
    }
    void Start()
    {
        if(gameObject.name != "btn-server2")
            gameObject.GetComponent<Button>().onClick.AddListener(OnClik);
    }
    public void OnClik()
    {
        GameObject.Find("btn-server2").SendMessage("OnSelectServer",this.gameObject);
    }
}
