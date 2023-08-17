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
            buildStates.GetBuildingValue(testPrefab);
            buildStates.buildingPreview = Instantiate(buildStates.buildingPrefab);
        }
        if (buildStates.buildingPrefab != null)
        {
            if(Physics.Raycast(mouseRay,out hit,Mathf.Infinity,8))
            {
                buildStates.buildingPreview.transform.position = new Vector3(hit.point.x, 0, 0);
                if (Input.GetMouseButtonDown(0))
                {
                    buildStates.BuildInstall();
                }
            }
        }
    }
}
