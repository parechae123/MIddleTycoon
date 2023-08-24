using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridTest : MonoBehaviour
{
    public Vector3 savePos;
    public float gridPivot;
    public Vector2Int[] axisLimit = new Vector2Int[2];//[0] = Min ,[1]=Max
    public bool[,] gridCollCheck = new bool[10,10];
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
            if (savePos.x >= axisLimit[0].x && savePos.x <= axisLimit[1].x && savePos.y >= axisLimit[0].y && savePos.y <= axisLimit[1].y)
            {
                if (true/* 여기다가 충돌체 있는지 감지하기*/)
                {
                    GameObject aa = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    aa.transform.position = VectorFTI(savePos);
                    Debug.Log(VectorFTI(savePos)); 
                }
            }
            //범위 밖이므로 UI메니저에서 추후 에러문 출력필요
        }
        if (Input.GetMouseButtonDown(1))
        {
            axisLimit[0] -= Vector2Int.one;
        }
    }

    public Vector3Int VectorFTI(Vector3 orig)
    {
        return new Vector3Int(Mathf.RoundToInt(Mathf.Clamp(orig.x, axisLimit[0].x, axisLimit[1].x)), Mathf.RoundToInt(Mathf.Clamp(orig.y, axisLimit[0].y, axisLimit[1].y)), Mathf.RoundToInt(orig.z));
    }
}
