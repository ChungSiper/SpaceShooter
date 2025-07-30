using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class NewAnemyWaves
{
    [Tooltip("Time for wave generation from the moment the game started")]
    public float timeToStart;
    [Tooltip("Enemy wave's prefab")]
    public GameObject wave;
}

public class NewLevelController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
