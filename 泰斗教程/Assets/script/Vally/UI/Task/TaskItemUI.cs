using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TaskItemUI : MonoBehaviour {

    public GameObject tasktype;
    public GameObject icon;
    public GameObject name;
    public GameObject des;
    public GameObject txtcoin;
    public GameObject imgcoin;
    public GameObject txtdiamond;
    public GameObject imgdiamond;
    public GameObject btnreward;
    public GameObject btntaketask;
    private Task task;

    void Awake()
    {

    }
    public void SetTask(Task task)
    {
        this.task = task;
        switch (task.TaskType)
        {
            case TaskType.Main:
                tasktype.GetComponent<Image>().sprite = Resources.Load("Texture/003-taskother/pic_主线", typeof(Sprite)) as Sprite;
                break;
            case TaskType.Reward:
                tasktype.GetComponent<Image>().sprite = Resources.Load("Texture/003-taskother/pic_奖赏", typeof(Sprite)) as Sprite;
                break;
            case TaskType.Daily:
                tasktype.GetComponent<Image>().sprite = Resources.Load("Texture/003-taskother/pic_日常", typeof(Sprite)) as Sprite;
                break;
        }
        icon.GetComponent<Image>().sprite = Resources.Load("Texture/002-mainmenu/equip/" + task.Icon, typeof(Sprite)) as Sprite;
        name.GetComponent<Text>().text = task.Name;
        des.GetComponent<Text>().text = task.Des;
        if(task.Coin > 0 && task.Diamond > 0)
        {
            imgcoin.GetComponent<Image>().sprite = Resources.Load("Texture/002-mainmenu/金币", typeof(Sprite)) as Sprite;
            txtcoin.GetComponent<Text>().text = "X " + task.Coin;
            imgdiamond.GetComponent<Image>().sprite = Resources.Load("Texture/002-mainmenu/钻石", typeof(Sprite)) as Sprite;
            txtcoin.GetComponent<Text>().text = "X " + task.Diamond;
        }
        else if(task.Coin > 0)
        {
            imgcoin.GetComponent<Image>().sprite = Resources.Load("Texture/002-mainmenu/金币", typeof(Sprite)) as Sprite;
            txtcoin.GetComponent<Text>().text = "X " + task.Coin;
            imgdiamond.SetActive(false);
            txtdiamond.SetActive(false);
        }
        else if (task.Diamond > 0)
        {
            imgdiamond.GetComponent<Image>().sprite = Resources.Load("Texture/002-mainmenu/钻石", typeof(Sprite)) as Sprite;
            txtcoin.GetComponent<Text>().text = "X " + task.Diamond;
            imgcoin.SetActive(false);
            txtcoin.SetActive(false);
        }
        switch (task.TaskProgress)
        {
            case TaskProgress.NoStart:
                btnreward.SetActive(false);
                btntaketask.transform.Find("txt").GetComponent<Text>().text = "下一步";
                break;
            case TaskProgress.Accept:
                btnreward.SetActive(false);
                btntaketask.transform.Find("txt").GetComponent<Text>().text = "战斗";
                break;
            case TaskProgress.Complete:
                btntaketask.SetActive(false);
                break;
        }
    }
    public void OnBattle()
    {
        TaskManager.instance.OnTask(task);
        TaskManager.instance.OnClose();
    }
    public void OnReward()
    {

    }
}
