using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
[System.Serializable]
public class BuildingManager
{
    public BuildStates buildState = new BuildStates();
    [SerializeField]public BuildValue buildValueExel;
    public void InstallBuilding()
    {

    }
    public void LoadSetting()
    {
        var OpperHandle = Addressables.LoadAssetAsync<BuildValue>("DataBase");
        OpperHandle.Completed += (DT) =>
        {
            buildValueExel = DT.Result;
        };
    }
}
