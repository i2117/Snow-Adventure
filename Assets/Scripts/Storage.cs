using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour {

    public static Storage instance;

    public GameObject[] bonusPrefabs;
    public GameObject enemyPrefab;

    public GameObject bonusParticle;
    public GameObject enemyParticle;

    private void Awake()
    {
        instance = this;
    }
}
