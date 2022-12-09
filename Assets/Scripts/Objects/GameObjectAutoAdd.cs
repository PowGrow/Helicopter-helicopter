using UnityEngine;

//Class can be attached to any object, to aut adding it in to List, to get access to it from GameObject Manager
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
