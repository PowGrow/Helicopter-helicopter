using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private Managers _managers;

    private void Awake()
    {
        _managers = Managers.Instances;
    }

    private void OnEnable()
    {
        _managers.ManagersWasStarted += ChangeScene;
    }

    private void OnDisable()
    {
        _managers.ManagersWasStarted -= ChangeScene;
    }

    private void ChangeScene()
    {
        Managers.Levels.GoToNext();
    }
}
