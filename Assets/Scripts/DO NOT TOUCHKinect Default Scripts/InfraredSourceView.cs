using UnityEngine;

public class InfraredSourceView : MonoBehaviour
{
    private InfraredSourceManager _InfraredManager;
    public GameObject InfraredSourceManager;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(-1, 1));
    }

    private void Update()
    {
        if (InfraredSourceManager == null) return;

        _InfraredManager = InfraredSourceManager.GetComponent<InfraredSourceManager>();
        if (_InfraredManager == null) return;

        gameObject.GetComponent<Renderer>().material.mainTexture = _InfraredManager.GetInfraredTexture();
    }
}