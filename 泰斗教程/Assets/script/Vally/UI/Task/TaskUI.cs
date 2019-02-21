using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUI : MonoBehaviour {
    
    public GameObject content;
    public GameObject taskitem;
    public ArrayList Item = new ArrayList();

	// Use this for initialization
	void Start () {
        InitTaskList();
	}
	
	public void InitTaskList()
    {
        ArrayList tasklist = TaskManager.instance.GetTaskList();

        ClearItem();
        foreach(Task task in tasklist)
        {
            GameObject obj = Instantiate(taskitem, taskitem.transform.position, taskitem.transform.rotation);
            Item.Add(obj);
            obj.GetComponent<TaskItemUI>().SetTask(task);
            obj.transform.parent = content.transform;
        }
    }
    void ClearItem()
    {
        foreach(GameObject i in Item)
        {
            Destroy(i);
        }
    }
}
