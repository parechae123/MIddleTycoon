using System.Collections.Generic;
using UnityEngine;
using static ComponentPipeLine;

public class GridTest : MonoBehaviour
{
    public BuildStates buildStates;
    public delegate void LoadingWaiter(string key);
    public LoadingWaiter loadingWaiter;
    public Vector3 savePos; //마우스 클릭 좌표 위치
    public float gridPivot;
    public Vector2Int[] axisLimit = new Vector2Int[2];//[0] = Min ,[1]=Max
    public HashSet<Vector2Int> gridColl = new HashSet<Vector2Int>();
    // Start is called before the first frame update
    void Start()
    {
        gridPivot = GameObject.Find("@Grid").transform.position.z;
        buildStates = Managers.BuildManager.buildState;
    }
    // Update is called once per frame
    void Update()
    {
        savePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, gridPivot - Camera.main.transform.position.z));
        if (Input.GetMouseButtonDown(0))
        {
            if (savePos.x >= axisLimit[0].x && savePos.x <= axisLimit[1].x && savePos.y >= axisLimit[0].y && savePos.y <= axisLimit[1].y&& buildStates.buildingPreview != null)
            {
                if (CollTest(GridMax(buildStates.buildingMeshFilter.sharedMesh.bounds.min, buildStates.buildingMeshFilter.sharedMesh.bounds.max, VectorFTI(new Vector2(savePos.x, savePos.y)), false)))
                {
                    GridMax(buildStates.buildingMeshFilter.sharedMesh.bounds.min, buildStates.buildingMeshFilter.sharedMesh.bounds.max, VectorFTI(new Vector2(savePos.x, savePos.y)), true);
                    buildStates.buildingPreview.transform.position = VectorFTI(savePos);
                    buildStates.BuildReset();
                }
                else
                {
                    Destroy(buildStates.buildingPreview);
                    buildStates.BuildReset();
                }
            }
            //범위 밖이므로 UI메니저에서 추후 에러문 출력필요
        }
        if (Input.GetKeyDown(KeyCode.A)&& buildStates.buildingPreview == null)
        {
            Managers.BuildManager.LoadingBuilding("SmithHouse", () =>
            {
                //로딩빌딩이 끝났을때니까 여기다가 리셋하고 인스턴시에이터
                LoadingInstantiater();
            });
/*            loadingWaiter += Managers.BuildManager.LoadingBuilding;
            loadingWaiter += LoadingInstantiater;
            loadingWaiter += LoadingResetter;
            loadingWaiter("SmithHouse");*/
        }
        if (Input.GetKeyDown(KeyCode.S) && buildStates.buildingPreview == null)
        {
            buildStates.buildingPreview = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        }
        if (Input.GetKeyDown(KeyCode.D) && buildStates.buildingPreview == null)
        {
            buildStates.buildingPreview = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }
        if (buildStates.buildingPreview != null && CollTest(GridMax(buildStates.buildingMeshFilter.sharedMesh.bounds.min, buildStates.buildingMeshFilter.sharedMesh.bounds.max, VectorFTI(new Vector2(savePos.x, savePos.y)), false)))
        {
            //닿는게 없을 시
            buildStates.buildingPreview.transform.position = VectorFTI(savePos);
        }
        else if (buildStates.buildingPreview != null && !CollTest(GridMax(buildStates.buildingMeshFilter.sharedMesh.bounds.min, buildStates.buildingMeshFilter.sharedMesh.bounds.max, VectorFTI(new Vector2(savePos.x, savePos.y)), false)))
        {
            Debug.Log("안되네");
        }
    }

    public Vector3Int VectorFTI(Vector3 orig)
    {
        return new Vector3Int(Mathf.RoundToInt(Mathf.Clamp(orig.x, axisLimit[0].x, axisLimit[1].x)), Mathf.RoundToInt(Mathf.Clamp(orig.y, axisLimit[0].y, axisLimit[1].y)), Mathf.RoundToInt(orig.z));
    }
    public Vector2Int VectorFTI(Vector2 orig)
    {
        return new Vector2Int(Mathf.RoundToInt(Mathf.Clamp(orig.x, axisLimit[0].x, axisLimit[1].x)), Mathf.RoundToInt(Mathf.Clamp(orig.y, axisLimit[0].y, axisLimit[1].y)));
    }
    public List<Vector2Int> GridMax(Vector3 min, Vector3 max, Vector2Int centerPos, bool addCollider)
    {
        List<Vector2Int> list = new List<Vector2Int>();
        list.Add(new Vector2Int(Mathf.FloorToInt(min.x), Mathf.FloorToInt(min.y)) + centerPos);
        list.Add(new Vector2Int(Mathf.CeilToInt(max.x), Mathf.CeilToInt(max.y)) + centerPos);
        for (int i = list[0].x; i <= list[1].x; i++)
        {
            for (int e = list[0].y; e <= list[1].y; e++)
            {
                if (new Vector2Int(i, e) != list[0] && new Vector2Int(i, e) != list[1])
                {
                    if (addCollider)
                    {
                        gridColl.Add(new Vector2Int(i, e));
                    }
                    else
                    {
                        list.Add(new Vector2Int(i, e));
                    }
                }
            }
        }
        if (addCollider)
        {
            gridColl.Add(new Vector2Int(Mathf.FloorToInt(min.x), Mathf.FloorToInt(min.y)) + centerPos);
            gridColl.Add(new Vector2Int(Mathf.CeilToInt(max.x), Mathf.CeilToInt(max.y)) + centerPos);
        }
        return list;
    }
    public bool CollTest(List<Vector2Int> posList)
    {
        for (int i = 0; i <= posList.Count - 1; i++)
        {
            if (gridColl.Contains(posList[i]))
            {
                return false;
            }
        }
        return true;
    }
    void LoadingInstantiater()
    {
        buildStates.buildingPreview = Instantiate(buildStates.buildingPrefab);
    }
}
