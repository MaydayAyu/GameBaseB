using MickeyUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTool : MonoBehaviour
{
    public GameObject loader;

    public Text info;
    public Text process;
    public Slider slider;

    private Updater ud;

    private string dataPath = "";
    public static string verFile = "ver.txt";
    private string verPath;

    private string oldVerInfo = "";
    public string updateUrl = "http://192.168.2.178/";

    private string stateInfo;
    private float stateProcess;

    private void Awake()
    {
        dataPath = Application.persistentDataPath;
        verPath = Path.Combine(dataPath, verFile);
        if (File.Exists(verPath))
        {
            oldVerInfo = File.ReadAllText(verPath);
        }
        switch (Application.platform)
        {
            case RuntimePlatform.IPhonePlayer:
                updateUrl += "iOS/";
                break;

            case RuntimePlatform.Android:
                updateUrl += "Android/";
                break;

            default:
                updateUrl += "Default/";
                break;
        }
        MEvent.Bind("UpdateFinish", OnUpdateFinish);
        ud = new Updater(updateUrl, Application.persistentDataPath + "/AssetBundles/");
    }

    private void Start()
    {
        ud.OnException = (Exception e) =>
        {
            stateInfo = "Net Error";
        };
        ud.OnStateChanged = (UpdateState us) =>
        {
            stateInfo = us.ToString();
            if (us == UpdateState.NoUpdate || us == UpdateState.Updated)
            {
                MEvent.Send("UpdateFinish");
            }
        };
        ud.TryUpdate();
    }

    private void Update()
    {
        stateProcess = ud.progress;
        process.text = stateProcess + "%";
        info.text = stateInfo;
        slider.value = stateProcess;
    }

    private void OnUpdateFinish()
    {
        Instantiate(loader);
    }
}