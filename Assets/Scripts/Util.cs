using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {

	public static T RandomFromArray<T>(T[] arr)
    {
        return arr[Random.Range(0, arr.Length)];
    }

    public static bool randomProc(float perc)
    {
        return UnityEngine.Random.Range(0F, 1F) < perc / 100;
    }
}
