using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DataManager
{
    [SerializeField] public BuildValue buildValueExel;
    public void LoadSetting()
    {
        var OpperHandle = Addressables.LoadAssetAsync<BuildValue>("DataBase");
        OpperHandle.Completed += (DT) =>
        {
            buildValueExel = DT.Result;
            Debug.Log("���");
            Addressables.Release(DT);
        };
        var GetInstallMatHandle = Addressables.LoadAssetAsync<Material>("InstallMat");
        GetInstallMatHandle.Completed += (MT) =>
        {
            Managers.BuildManager.buildState.installMat = MT.Result;
            Debug.Log("���");
            Addressables.Release(MT);
        };
    }

}
