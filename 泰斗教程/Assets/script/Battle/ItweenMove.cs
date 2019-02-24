using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItweenMove : MonoBehaviour {

    public bool move = false;
    public List<float> time = new List<float>();
    public List<float> End = new List<float>();
    private List<GameObject> obj = new List<GameObject>();
    private Vector3 vec3;
    static public ItweenMove instance;

    void Awake()
    {
        instance = this;
    }

	// Update is called once per frame
	void Update () {
        if (move)
        {
            for (int i = 0; i < obj.Count;i++)
            {
                obj[i].transform.Translate(Vector3.Lerp(Vector3.zero, vec3, time[i]));
                time[i] += Time.deltaTime;
                if (time[i] >= End[i])
                {
                    time.RemoveAt(i);
                    End.RemoveAt(i);
                    obj.RemoveAt(i);
                    i--;
                    if (obj.Count == 0)
                        move = false;
                }
            }
        }
	}

    public void Translate(GameObject obj, Vector3 vec3, float time)
    {
        this.obj.Add(obj);
        this.vec3 = vec3;
        End.Add(time);
        move = true;
        this.time.Add(0);
    }
}
