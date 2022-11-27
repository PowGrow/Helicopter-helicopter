using UnityEngine;

public class HelicopterPreparation : MonoBehaviour
{
    private GameObject SetHelicopterGameObject()
    {
        return this.gameObject;
    }

    void Start()
    {
        switch (Managers.Levels.SceneId())
        {
            case 2:
                this.transform.position = new Vector3(-1 * (Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) + this.transform.localScale.x,
                                            this.transform.position.y, this.transform.position.z); //Устанавливаем позицию сверху слева, в зависимости от размера экрана
                break;
            case 3:
                Managers.Configuration.LoadHelicopterData();
                var heightBottom = -1 * Camera.main.orthographicSize + this.gameObject.transform.localScale.x;
                this.transform.position = new Vector3(0, heightBottom, 0);
                break;
        }

    }

    private void OnEnable()
    {
        Managers.Configuration.OnSettingHelicopterGameObject += SetHelicopterGameObject;
    }

    private void OnDisable()
    {
        Managers.Configuration.OnSettingHelicopterGameObject -= SetHelicopterGameObject;
    }
}
