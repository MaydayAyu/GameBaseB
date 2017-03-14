using MickeyUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUtils : MonoBehaviour
{
    private static UpdateUtils instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject, 0.1f);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        MEvent.Dispatch();
        AsynCall.CallFunc();
    }
}