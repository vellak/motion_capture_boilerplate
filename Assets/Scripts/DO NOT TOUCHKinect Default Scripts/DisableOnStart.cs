using UnityEngine;

public class DisableOnStart : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        gameObject.SetActive(false);
    }
}