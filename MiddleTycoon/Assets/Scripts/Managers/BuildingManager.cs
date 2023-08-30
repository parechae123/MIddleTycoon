using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
[System.Serializable]
public class BuildingManager
{
    public BuildStates buildState = new BuildStates();
    public void LoadingBuilding(string OBJKey ,Action callBack)
    {
        var OpperHandle = Addressables.LoadAssetAsync<GameObject>(OBJKey);
        OpperHandle.Completed += (DT) =>
        {
            buildState.GetBuildingValue(DT.Result);
            buildState.buildingPreview = DT.Result;
            callBack?.Invoke();
        };
    }
}
