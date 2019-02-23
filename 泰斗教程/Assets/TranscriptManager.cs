using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranscriptManager : MonoBehaviour {

    public static TranscriptManager instance;

    public GameObject player;

    public List<GameObject> enemyList = new List<GameObject>();

    void Awake()
    {

    }
}
