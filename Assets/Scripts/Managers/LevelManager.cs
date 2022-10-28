using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour,IGameManager
{
    public ManagerStatus status { get; private set; }


    public void Startup()
    {
        Debug.Log("Mission manager starting...");

        PlayerPrefs.SetString("swapDirection", "start");

        status = ManagerStatus.Started;
    }


    public void ChangeLevel(string levelName)
    {
        Managers.GameObjects.ClearList();
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

    public object GetData()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void UpdateData(object sceneName)
    {
        ChangeLevel((string)sceneName);
    }
}

