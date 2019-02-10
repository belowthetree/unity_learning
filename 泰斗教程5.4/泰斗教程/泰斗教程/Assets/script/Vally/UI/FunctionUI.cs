using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FunctionUI : MonoBehaviour {

    public GameObject package;
    public GameObject task;
	public void OnClickBag()
    {
        package.GetComponent<Animation>().Play("PackageDown");
    }
    public void OnClickTask()
    {
        task.GetComponent<Animation>().Stop();
        task.GetComponent<Animation>().Play("TaskMove");
    }
}
