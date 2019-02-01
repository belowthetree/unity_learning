using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class startMenuController : MonoBehaviour
{

    public GameObject register;
    public GameObject login;
    public GameObject welcome;
    private string usrname;
    private string password;
    public Text coverpass;
    public Text usrtxt;
    public Text passtxt;
    public GameObject serverlist;
    public GameObject enterserver;
    public GameObject currentserver;
    public Text usrname_welcome;
    public Text usrname_login;
    public Text usrname_register;
    public GameObject girl;
    public GameObject boy;
    public GameObject pregame;
    public GameObject select;
    public InputField input;
    public Text txt_name;
    public Text txt_level;
    public string [] charater = new string [10];
    public Dictionary<string, int> level = new Dictionary<string, int>();
    public string who;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (passtxt.text.ToString().Length > coverpass.text.ToString().Length)
        {
            coverpass.text = coverpass.text.ToString() + "*";
        }
    }
    public void OnClikLoginBtn()
    {
        register.SetActive(true);
        login.SetActive(false);
    }
    public void OnClikCancel()
    {
        login.SetActive(true);
        register.SetActive(false);
        login.GetComponent<Animation>().Play();
    }
    public void OnClikUsr()
    {
        login.SetActive(true);
        welcome.SetActive(false);
    }
    public void OnClikBtnServer()
    {
        welcome.SetActive(false);
        serverlist.SetActive(true);
    }
    public void OnEnsureServer()
    {
        serverlist.SetActive(false);
        welcome.SetActive(true);
        enterserver.transform.Find("Text").GetComponent<Text>().text = currentserver.transform.Find("Text").GetComponent<Text>().text;
    }
    public void OnLogin()
    {
        login.SetActive(false);
        welcome.SetActive(true);
        usrname_welcome.text = usrname_login.text;
    }
    public void OnLoginAndRegister()
    {
        register.SetActive(false);
        welcome.SetActive(true);
        usrname_welcome.text = usrname_register.text;
        password = passtxt.text.ToString();
    }
    public void OnChangeCharacter()
    {
        if (boy.GetComponent<spinWithMouse>().select)
            girl.SetActive(false);
        else
            boy.SetActive(false);
    }
    public void OnExitPreGame()
    {
        welcome.SetActive(true);
        pregame.SetActive(false);
        boy.SetActive(false);
    }
    public void OnEnterPreGame()
    {
        welcome.SetActive(false);
        pregame.SetActive(true);
    }
    public void OnExitSelect()
    {
        select.SetActive(false);
        pregame.SetActive(true);
        if (who == boy.name)
            girl.SetActive(false);
        else
            boy.SetActive(false);
    }
    public void OnEnterSelect()
    {
        if (girl.activeInHierarchy)
        {
            who = girl.name;
        }
        else
            who = boy.name;
        select.SetActive(true);
        pregame.SetActive(false);
        boy.SetActive(true);
        girl.SetActive(true);
    }
    public void OnEnsureName()
    {
        if (input.text.ToString().Length > 0)
        {
            select.SetActive(false);
            pregame.SetActive(true);
            txt_name.text = input.text;
            if (level.ContainsKey(input.text.ToString()))
                txt_level.text = level[input.text.ToString()].ToString();
            else
                txt_level.text = "Lv.1";
        }
        else
        {
            input.transform.FindChild("Placeholder").GetComponent<Text>().text = "请输入名字";
            input.transform.Find("Placeholder").GetComponent<Text>().color = Color.red;
        }
    }
}
