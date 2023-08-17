using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers instance { get { Init(); return s_instance; } }
    private void Start()
    {
        BuildManager.LoadSetting();
    }
    public static void Init()
    {
        Debug.Log("¾ÆÀ×");
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
    GameManager _game = new GameManager();
    UIManager _ui = new UIManager();
    [SerializeField]BuildingManager _building = new BuildingManager();


    public static GameManager Game { get { return instance?._game; } }
    public static UIManager UI { get { return instance?._ui; } }
    public static BuildingManager BuildManager { get { return instance?._building;  } }

}
