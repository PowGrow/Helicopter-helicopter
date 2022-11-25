using UnityEngine;
using UnityEngine.SceneManagement;

public class HelicopterPreparation : MonoBehaviour
{
    void Start()
    {
        Managers.Configuration.SetHelicopterGameObject(this.gameObject);
        switch (Managers.Levels.SceneId())
        {
            case 2:
                this.transform.position = new Vector3(-1 * (Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) + this.transform.localScale.x,
                                            this.transform.position.y, this.transform.position.z); //������������� ������� ������ �����, � ����������� �� ������� ������
                break;
            case 3:
                //var widthCenter = (Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) / 2;
                //var heightBottom = -1 * Camera.main.orthographicSize + this.gameObject.transform.localScale.x * 2;
                //this.transform.position = new Vector3(widthCenter, heightBottom, 0);
                break;
        }

    }
}
