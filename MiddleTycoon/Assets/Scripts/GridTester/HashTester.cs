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
        //Hashset�� TrueFalse�� Key������ �����ϴ� ���� 
    }
}
