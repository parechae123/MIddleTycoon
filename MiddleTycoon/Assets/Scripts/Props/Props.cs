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
    private GameObject buildingPrefab;
    public GameObject BuildingPrefab { get { return buildingPrefab; } set { buildingPrefab = value; getBuildingValue(BuildingPrefab); } }
    public Collider buildingCollider;
    public MeshFilter buildingMeshFilter;

    public void getBuildingValue(GameObject GO)
    {
        buildingMeshFilter = ComponentPipeLine.LargestMeshFilter(buildingPrefab);
        buildingCollider = ComponentPipeLine.GetCompo<BoxCollider>(buildingMeshFilter.gameObject);
    }
}
