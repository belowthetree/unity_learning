using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneProgressBar : MonoBehaviour {


    public static LoadSceneProgressBar instance;
    public Image progress;
    public AsyncOperation ao = null;

	// Use this for initialization
	void Awake () {
        instance = this;

        SceneManager.LoadSceneAsync(2);
    }

    void Update()
    {
        if(ao!=null)
        {
            progress.fillAmount = ao.progress;
        }
    }
	
    public void Show(AsyncOperation ao)
    {
        gameObject.SetActive(true);
        this.ao = ao;
    }
}
