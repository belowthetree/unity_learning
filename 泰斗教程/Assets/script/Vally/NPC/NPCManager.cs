using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

    public GameObject[] npc;
    public Dictionary<int, GameObject> npc_id = new Dictionary<int, GameObject>();
    public static NPCManager instance;

	// Use this for initialization
	void Start () {
        instance = this;
		foreach(GameObject i in npc)
        {
            int id = int.Parse(i.name.Substring(0, 4));
            npc_id.Add(id, i);
        }
	}
    public GameObject GetNPCById(int id)
    {
        GameObject obj = null;
        npc_id.TryGetValue(id, out obj);

        return obj;
    }
}
