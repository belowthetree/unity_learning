using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static int GetExp(int level)
    {
        return (int)((level - 1) * (100f + (100f + 10f * (level - 2f))) / 2);
    }
}
