using UnityEngine;

//Список ивентов вызывающихся при последовательной загрузки приложения
public class StartupEvent : MonoBehaviour
{
    public const string MANAGERS_STARTED = "MANAGERS_STARTED";
    public const string DESCRIPTION_LOADED = "DESCRIPTION_LOADED";
    public const string MANAGERS_PROGRESS = "MANAGERS_PROGRESS";
}
