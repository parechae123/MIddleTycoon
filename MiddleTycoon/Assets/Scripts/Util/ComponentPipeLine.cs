using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentPipeLine
{
    public static T GetCompo<T>(GameObject GO) where T : Component
    {
        
        T component = GO.GetComponent<T>();
        if (component == null)
        {
            if(GO.GetComponentInChildren<T>() != null)
            {
                component = GO.GetComponentInChildren<T>();
            }
            else
            {
                GO.AddComponent<T>();
            }
        }
        return component;
        
    }
    public static MeshFilter LargestMeshFilter(GameObject GO)
    {
        MeshFilter mesh = null;
        MeshFilter tempMesh = null;
        if (GO.GetComponent<MeshFilter>() != null) 
        {
            mesh = GO.GetComponent<MeshFilter>();
        }
        for (int i = 0; i < GO.transform.childCount; i++)
        {
            Debug.Log(i);
            tempMesh = GO.transform.GetChild(i).GetComponent<MeshFilter>();
            if(mesh == null)
            {
                mesh = GO.transform.GetChild(i).GetComponent<MeshFilter>();
            }
            if (tempMesh.sharedMesh.bounds.size.x > mesh.sharedMesh.bounds.size.x && tempMesh.sharedMesh.bounds.size.z > mesh.sharedMesh.bounds.size.z)
            {
                mesh = tempMesh;
            }
        }
        Debug.Log(mesh);
        return mesh;
    }
}
