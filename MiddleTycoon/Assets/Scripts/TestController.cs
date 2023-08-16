using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public GameObject testPrefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Managers.BuildingManager.buildState.BuildingPrefab = testPrefab;
            Instantiate(Managers.BuildingManager.buildState.BuildingPrefab);
        }
    }
}
