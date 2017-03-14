using UnityEngine;
using System.Collections;
using Tangzx.ABSystem;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    #region Private Members

    private static AssetBundleManager manager = null;
    private Transform m_Transform;

    #endregion Private Members

    // Use this for initialization
    private void Awake()
    {
        manager = gameObject.AddComponent<AssetBundleManager>();
    }

    private void Start()
    {
        this.m_Transform = this.transform;
        Invoke("Init", 1);
    }

    private void Init()
    {
        manager.Init(() =>
        {
            manager.Load("Assets.Scenes.Main.unity", (a) =>
            {
                if (a == null)
                {
                    return;
                }
                SceneManager.LoadScene("Main");
            });
        });
    }

    // Update is called once per frame
    private void Update()
    {
    }

    #region Public Methods

    public void LoadScene(string name)
    {
        var bundleName = HashUtil.Get(("Assets.Scenes." + name + ".unity").ToLower()) + ".ab";
        string assetPath = string.Format("{0}/{1}", manager.pathResolver.BundleCacheDir, bundleName);
        AssetBundle assetBundle = AssetBundle.LoadFromFile(assetPath);
        SceneManager.LoadScene(name);
    }

    #endregion Public Methods
}