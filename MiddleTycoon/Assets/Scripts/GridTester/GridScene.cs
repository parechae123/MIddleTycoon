using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class GridScene : MonoBehaviour
{
    public bool[,] Grid = new bool[30,10];
    [SerializeField]public GridProp GridTe;
    void Start()
    {
        Debug.Log(Grid.Length);
        Debug.Log(Grid.LongLength);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class GridProp
{
    public bool[,] Grid = new bool[30, 10];
}
