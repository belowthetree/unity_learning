using UnityEngine;
using System.Collections;

public class TaskManager : MonoBehaviour {

    public TextAsset taskText;
    public GameObject taskUI;
    public GameObject task;
    private ArrayList taskList = new ArrayList();
    static public TaskManager instance;
    public Task currentTask;
    public PlayerAutoMove PlayerAutoMove;
    public GameObject transport;

    void Awake()
    {
        instance = this;
        InitTask();
    }
    /// <summary>
    /// 初始化任务信息
    /// </summary>
    public void InitTask()
    {
        string[] taskinfoArray = taskText.ToString().Split('\n');
        foreach(string str in taskinfoArray)
        {
            string[] proArray = str.Split('|');
            Task task = new Task();
            task.Id = int.Parse(proArray[0]);
            switch (proArray[1])
            {
                case "Main":
                    task.TaskType = TaskType.Main;
                    break;
                case "Reward":
                    task.TaskType = TaskType.Reward;
                    break;
                case "Daily":
                    task.TaskType = TaskType.Daily;
                    break;
            }
            task.Name = proArray[2];
            task.Icon = proArray[3];
            task.Des = proArray[4];
            task.Coin = int.Parse(proArray[5]);
            task.Diamond = int.Parse(proArray[6]);
            task.TalkNpc = proArray[7];
            task.IdNpc = int.Parse(proArray[8]);
            task.IdTranscript = int.Parse(proArray[9]);///副本ID
            taskList.Add(task);
        }
    }
    public ArrayList GetTaskList()
    {
        return taskList;
    }
    public void OnClose()
    {
        task.GetComponent<Animation>().Play("TaskOut");
    }
    public void OnTask(Task task)
    {
        currentTask = task;
        if(task.TaskProgress == TaskProgress.NoStart)
        {
            PlayerAutoMove.SetDestination(NPCManager.instance.GetNPCById(task.Id).transform.position);
        }
        else if (task.TaskProgress == TaskProgress.Accept)
        {
            PlayerAutoMove.SetDestination(transport.transform.position);
        }
    }
    public void OnArriveDesty()
    {
        if(currentTask.TaskProgress==TaskProgress.NoStart)
        {
            NPCDialog.instance.ShowDialog();
        }
    }
}
