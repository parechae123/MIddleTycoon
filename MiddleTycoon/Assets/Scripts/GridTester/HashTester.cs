using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashTester : MonoBehaviour
{
    public HashSet<string> hashSet = new HashSet<string>();
    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            hashSet.Add(i.ToString());
        }
        //Hashset은 TrueFalse를 Key값으로 저장하는 형태 
    }
}
