using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ComponentPipeLine;

public class TestController : MonoBehaviour
{
    public GameObject testPrefab;
    public BuildStates buildStates;
    public RaycastHit hit;
    public Ray mouseRay;
    public RaycastHit buildingHit;
    public delegate void LoadingWaiter(string key);
    public LoadingWaiter loadingWaiter;
    private void Start()
    {
        buildStates = Managers.BuildManager.buildState;
    }
    // Update is called once per frame
    void Update()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.A))
        {
/*            loadingWaiter = Managers.BuildManager.LoadingBuilding;*/
            loadingWaiter += LoadingResetter;
            loadingWaiter("SmithHouse");
        }
        if (buildStates.buildingPrefab != null)
        {
            if(Physics.Raycast(mouseRay,out hit,Mathf.Infinity,8))
            {
                buildStates.buildingPreview.transform.position = new Vector3(hit.point.x, 0, 0);
                if (Input.GetMouseButtonDown(0))
                {
                    buildStates.BuildReset();
                }
            }
        }
    }
    void LoadingResetter(string nothing)
    {
        loadingWaiter = null;
    }
}
