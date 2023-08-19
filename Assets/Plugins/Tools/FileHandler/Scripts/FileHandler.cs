using System.IO;

using UnityEngine;

using Newtonsoft.Json;

public class FileHandler : MonoBehaviour
{
    private const string fileSuffix = ".dat";

    public static bool TryLoadFile(string fileName, out string rawData)
    {
        string path = GetPath(fileName);
        bool exists = File.Exists(path);
        rawData = string.Empty;
        if (exists)
        {
            rawData = File.ReadAllText(path);
        }

        return exists;
    }

    public static bool TryLoadFile<T>(string fileName, out T data) where T : class
    {
        bool exists = TryLoadFile(fileName, out string rawData);
        data = null;
        if (exists)
        {
            data = JsonConvert.DeserializeObject<T>(rawData);
        }

        return exists;
    }

    public static void SaveFile(string fileName, string rawData)
    {
        string path = GetPath(fileName);
        File.WriteAllText(path, rawData);
    }

    public static void SaveFile<T>(string fileName, T data) where T : class
    {
        string rawData = JsonConvert.SerializeObject(data, Formatting.Indented);
        SaveFile(fileName, rawData);
    }

    private static string GetPath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName + fileSuffix;
    }
}
