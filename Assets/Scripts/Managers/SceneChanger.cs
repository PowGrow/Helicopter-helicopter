using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    private void Awake()
    {
        Messenger.AddListener(StartupEvent.MANAGERS_STARTED, ChangeScene);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(StartupEvent.MANAGERS_STARTED, ChangeScene);
    }

    private void ChangeScene()
    {
        Managers.Levels.GoToNext();
    }
}
