using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static ComponentPipeLine;
[System.Serializable]
public class BuildStates
{
    public float buildingCost;
    public GameObject buildingPrefab;
    public GameObject buildingPreview;
    public Collider buildingCollider;
    public MeshFilter buildingMeshFilter;
    public BuildFrame Frame;

    public List<MeshRenderer> allMeshRenderer = new List<MeshRenderer>();
    public List<Material> originalMaterials = new List<Material> ();
    public Material installMat;
    public void GetBuildingValue(GameObject GO)
    {
        buildingPrefab = GO;
        buildingMeshFilter = LargestMeshFilter(buildingPrefab);
        buildingCollider = GetCompo<BoxCollider>(buildingMeshFilter.gameObject);
        Frame = GetCompo<BuildFrame>(buildingMeshFilter.gameObject);
        allMeshRenderer = GetAllChildComponent<MeshRenderer>(GO);
        foreach (var item in allMeshRenderer)
        {
            originalMaterials.Add(item.sharedMaterial);
        }
    }
    public void ChangeInstallMaterial(bool isInstallAble)
    {
        if (allMeshRenderer[allMeshRenderer.Count - 1].material != installMat)
        {
            foreach (var item in allMeshRenderer)
            {
                item.material = installMat;
            }
        }
        if (isInstallAble )
        {
            installMat.color = Color.green;
        }
        else if(!isInstallAble)
        {
            installMat.color = Color.red;
            //UI메니저 만들어서 화면에 글자출력 필요 작업필요
        }
    }
    public void BuildInstall()
    {
        buildingPrefab = null;
        buildingMeshFilter = null;
        buildingCollider = null;
        buildingPreview = null;
        allMeshRenderer.Clear();
        originalMaterials.Clear();
    }
}
