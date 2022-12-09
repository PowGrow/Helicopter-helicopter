using System.Linq;
using System.Reflection;
using UnityEngine;

public static class Utils
{
    //Method filling information from one object in to other, taking into account match order of field and properties, need only for filling information in UnityEditor
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

    public static int PartByTypeCount(string tag)
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
