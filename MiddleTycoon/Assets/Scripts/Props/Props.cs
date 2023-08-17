using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ComponentPipeLine;
[System.Serializable]
public class BuildStates
{
    public float buildingCost;
    public bool isInstallAble;
    public GameObject buildingPrefab;
    public GameObject buildingPreview;
    public Collider buildingCollider;
    public MeshFilter buildingMeshFilter;


    public void GetBuildingValue(GameObject GO)
    {
        buildingPrefab = GO;
        buildingMeshFilter = ComponentPipeLine.LargestMeshFilter(buildingPrefab);
        buildingCollider = ComponentPipeLine.GetCompo<BoxCollider>(buildingMeshFilter.gameObject);
    }
    public void BuildInstall()
    {
        buildingPrefab = null;
        buildingMeshFilter = null;
        buildingCollider = null;
        buildingPreview = null;
    }
}
