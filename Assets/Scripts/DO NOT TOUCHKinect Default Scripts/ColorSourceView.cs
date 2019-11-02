using UnityEngine;

public class ColorSourceView : MonoBehaviour
{
    private ColorSourceManager _ColorManager;
    public GameObject ColorSourceManager;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(-1, 1));
    }

    private void Update()
    {
        if (ColorSourceManager == null) return;

        _ColorManager = ColorSourceManager.GetComponent<ColorSourceManager>();
        if (_ColorManager == null) return;

        gameObject.GetComponent<Renderer>().material.mainTexture = _ColorManager.GetColorTexture();
    }
}