using UnityEngine;
using UnityEngine.UI;

public class PreviewButton : MonoBehaviour
{
    [SerializeField] private Image _previewButtonImage;
    [SerializeField] private GameObject _itemPreview;
    [SerializeField] private GameObject _lock;

    public Sprite ItemPreviewImageSprite
    {
        get { return _itemPreview.GetComponent<Image>().sprite; }
        set 
        {
            _itemPreview.GetComponent<Image>().sprite = value;
        }
    }
    public string ItemPreviewName
    {
        get { return this.transform.name; }
        set { this.transform.name = value; }
    }
    public bool IsLocked
    {
        get { return _lock.activeSelf; }
        set { _lock.SetActive(value); }
    }

    public void RemoveLock()
    {
        if(IsLocked)
            _lock.SetActive(false);
    }
}
