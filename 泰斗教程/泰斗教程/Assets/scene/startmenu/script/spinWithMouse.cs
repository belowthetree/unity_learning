using UnityEngine;
using System.Collections;

public class spinWithMouse : MonoBehaviour {

    // Use this for initialization
    public bool bol=false;
    public bool on = false;
    public bool select = false;
    public GameObject other;
    public float x;
    public float y;
    public float z;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(bol)
            this.transform.Rotate(0, -Input.GetAxis("Mouse X")*40f, 0, Space.World);
        if(this.name== "man_stand"&&(select||on))
            transform.localScale = new Vector3(x * 1.25f, y*1.25f, z*1.25f);
        else if(select||on)
            transform.localScale = new Vector3(x*1.25f, y*1.25f, z*1.25f);
        else if(this.name =="man_stand")
            transform.localScale = new Vector3(x, y, z);
        else
            transform.localScale = new Vector3(x, y, z);
    }
    public void OnMouseDown()
    {
        if (!select)
        {
            select = true;
            other.GetComponent<spinWithMouse>().select = false;
        }
    }
    public void OnMouseUp()
    {
        bol = false;
    }
    public void OnMouseOver()
    {
           on = true;
    }
    public void OnMouseExit()
    {
           on = false;
    }
    public void OnPointDown()
    {
        bol = true;
    }
}
