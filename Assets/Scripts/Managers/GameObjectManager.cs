using UnityEngine;
using System.Collections.Generic;
public class GameObjectManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private List<GameObject> _allObjects = new List<GameObject>();

    private List<IProjectile> _projectiles = new List<IProjectile>();

    public List<GameObject> AllObjects
    {
        get { return _allObjects; }
        set { _allObjects = value; }
    }

    public List<IProjectile> Projectiles
    {
        get { return _projectiles; }
        set { _projectiles = value; }
    }

    public void Startup()
    {
        Debug.Log("GameObjectManager starting...");

        status = ManagerStatus.Started;
    }

    public GameObject GetObject(string tag)
    {
        foreach (GameObject obj in AllObjects)
        {
            if(obj.tag == tag)
                return obj;
        }
        return null;
    }
}
