using UnityEngine;
using UnityEngine.UI;

namespace Assignment_Scripts
{
    public class ImageViewer : MonoBehaviour
    {
        [SerializeField] private RawImage image;

        [SerializeField] private MultiSourceManager sourceManager;


        private void Update()
        {
            // image of the camera to see yourself
            image.texture = sourceManager.GetColorTexture();
            
        }
    }
}