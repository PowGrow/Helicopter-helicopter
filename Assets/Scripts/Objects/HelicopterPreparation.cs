using UnityEngine;

public class HelicopterPreparation : MonoBehaviour
{
    void Start()
    {
        Managers.Configuration.SetHelicopterGameObject(this.gameObject);
        switch (Managers.Levels.SceneId())
        {
            case 2:
                this.transform.position = new Vector3(-1 * (Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) + this.transform.localScale.x,
                                            this.transform.position.y, this.transform.position.z); //Устанавливаем позицию сверху слева, в зависимости от размера экрана
                break;
            case 3:
                var heightBottom = -1 * Camera.main.orthographicSize + this.gameObject.transform.localScale.x;
                this.transform.position = new Vector3(0, heightBottom, 0);
                break;
        }

    }
}
