using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildFrame : MonoBehaviour
{
    public BuildType BT;
    public void BuildFunctionSetting()
    {
        switch (BT)
        {
            case BuildType.SmithHome:

                break;
            case BuildType.Farm:
                break;
            case BuildType.House:
                break;
            case BuildType.Barracks:
                break;
        }
    }
}
