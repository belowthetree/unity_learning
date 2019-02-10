using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCDialog : MonoBehaviour {

    public Text txt;
    public static NPCDialog instance;
    public TaskUI TaskUI;

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ShowDialog()
    {
        this.GetComponent<Animation>().Play("DialogShow");
    }
    public void HideDialog()
    {
        //this.GetComponent<Animator>().speed = -1;
        this.GetComponent<Animation>().Play("DialogHide");
    }
    public void AcceptTask()
    {
        TaskManager.instance.currentTask.TaskProgress = TaskProgress.Accept;
        HideDialog();
        TaskManager.instance.OnTask(TaskManager.instance.currentTask);
        TaskUI.InitTaskList();
    }
}
