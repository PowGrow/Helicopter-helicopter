using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemPreviewAutoSizer : MonoBehaviour
{
    private Image _imageRenderer;
    private void Start()
    {
        _imageRenderer = GetComponent<Image>();
        var spriteSize = new Vector2(_imageRenderer.mainTexture.width, _imageRenderer.mainTexture.height);

        float spriteAspectRation;
        if(spriteSize.x > spriteSize.y)
        {
            spriteAspectRation = spriteSize.y / spriteSize.x;
            _imageRenderer.rectTransform.sizeDelta = new Vector2(_imageRenderer.rectTransform.sizeDelta.x, spriteAspectRation * _imageRenderer.rectTransform.sizeDelta.y);
        }
        else
        {
            spriteAspectRation = spriteSize.x / spriteSize.y;
            _imageRenderer.rectTransform.sizeDelta = new Vector2(spriteAspectRation * _imageRenderer.rectTransform.sizeDelta.x, _imageRenderer.rectTransform.sizeDelta.y);
        }
    }
}
