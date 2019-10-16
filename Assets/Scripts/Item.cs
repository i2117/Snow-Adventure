using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public bool isEnemy;

    private IEnumerator Start()
    {
        if (isEnemy)
            yield break;

        while (true)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 100);
            yield return null;
        }
    }

}
