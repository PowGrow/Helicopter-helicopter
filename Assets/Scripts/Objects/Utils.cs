using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class Utils
{
    //ћетод заполн€ющий информацию из одного объекта в другой, с учЄтом совпадени€ очередности объ€вленных полей и свойств нужен исключительно дл€ заполнени€ информации дл€ доступности в UnityEditor
    public static void SetObjectInfo(object to, object from)
    {
        var toInfoProperties = to.GetType().GetRuntimeProperties().ToList();
        var fromFields = from.GetType().GetRuntimeFields().ToList();
        for (int fiedId = 0; fiedId < fromFields.Count(); fiedId++)
        {
            var value = fromFields[fiedId].GetValue(from);
            toInfoProperties[fiedId].SetValue(to, value);
        }
    }

    public static int ObjectCount(string tag)
    {
        return Managers.Configuration.UnlockedObjects[tag].Count();
    }

    public static void TimeScale()
    {
        if (Time.timeScale != 1)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }

}
