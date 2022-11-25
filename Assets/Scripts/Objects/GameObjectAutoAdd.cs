using UnityEngine;

public class GameObjectAutoAdd : MonoBehaviour
{

    private void Awake()
    {
        Managers.GameObjects.AllObjects.Add(gameObject);
    }

    private void OnDestroy()
    {
        Managers.GameObjects.AllObjects.Remove(gameObject);
    }
}
