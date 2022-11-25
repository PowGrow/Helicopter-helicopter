using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour,IGameManager
{
    public ManagerStatus status { get; private set; }


    public void Startup()
    {
        Debug.Log("Mission manager starting...");
        status = ManagerStatus.Started;
    }


    public void ChangeLevel(string levelName)
    {
        Managers.GameObjects.AllObjects.Clear();
        SceneManager.LoadScene(levelName);
    }

    public bool IsActive(string sceneName)
    {
        if (SceneManager.GetActiveScene().name == sceneName)
            return true;
        else
            return false;
    }

    public void GoToNext()
    {
        int _currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++_currentBuildIndex);
    }

    public void GoTo(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public int SceneId()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void UpdateData(object sceneName)
    {
        ChangeLevel((string)sceneName);
    }
}

