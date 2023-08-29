using System.Collections.Generic;
using UnityEngine;
using static ComponentPipeLine;

public class GridTest : MonoBehaviour
{
    public Vector3 savePos; //���콺 Ŭ�� ��ǥ ��ġ
    public float gridPivot;
    public Vector2Int[] axisLimit = new Vector2Int[2];//[0] = Min ,[1]=Max
    public HashSet<Vector2Int> gridColl = new HashSet<Vector2Int>();
    public GameObject installPreview;
    // Start is called before the first frame update
    void Start()
    {
        gridPivot = GameObject.Find("@Grid").transform.position.z;
    }
    // Update is called once per frame
    void Update()
    {
        savePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, gridPivot - Camera.main.transform.position.z));
        if (Input.GetMouseButtonDown(0))
        {
            if (savePos.x >= axisLimit[0].x && savePos.x <= axisLimit[1].x && savePos.y >= axisLimit[0].y && savePos.y <= axisLimit[1].y&&installPreview != null)
            {
                if (CollTest(GridMax(LargestMeshFilter(installPreview).mesh.bounds.min, LargestMeshFilter(installPreview).mesh.bounds.max, VectorFTI(new Vector2(savePos.x, savePos.y)), false)))
                {
                    GridMax(LargestMeshFilter(installPreview).mesh.bounds.min, LargestMeshFilter(installPreview).mesh.bounds.max, VectorFTI(new Vector2(savePos.x, savePos.y)), true);
                    installPreview.transform.position = VectorFTI(savePos);
                    installPreview = null;
                }
                else
                {
                    Destroy(installPreview);
                }
            }
            //���� ���̹Ƿ� UI�޴������� ���� ������ ����ʿ�
        }
        if (Input.GetKeyDown(KeyCode.A)&&installPreview == null)
        {
            installPreview = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
        if (Input.GetKeyDown(KeyCode.S) && installPreview == null)
        {
            installPreview = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        }
        if (Input.GetKeyDown(KeyCode.D) && installPreview == null)
        {
            installPreview = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }
        if (installPreview != null&&CollTest(GridMax(LargestMeshFilter(installPreview).mesh.bounds.min, LargestMeshFilter(installPreview).mesh.bounds.max, VectorFTI(new Vector2(savePos.x, savePos.y)), false)))
        {
            installPreview.transform.position = VectorFTI(savePos);
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
}
