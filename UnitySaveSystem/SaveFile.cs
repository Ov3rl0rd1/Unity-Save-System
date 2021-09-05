using System.IO;
using UnityEngine;

namespace UnitySaveSystem
{
    public class SaveFile
    {
        public readonly string JsonFilePath;

        public T LoadClass<T>()
        {
            return JsonUtility.FromJson<T>(File.ReadAllText(JsonFilePath));
        }

        public void SaveClass<T>(T classToSave)
        {
            try
            {
                JsonUtility.FromJsonOverwrite(JsonFilePath, classToSave);
            }
            catch
            {
                File.AppendAllText(JsonFilePath, JsonUtility.ToJson(classToSave));
            }
        }

        public SaveFile(string fullSaveName)
        {
            JsonFilePath = fullSaveName + ".json";
            File.Create(fullSaveName + ".json").Close();
        }
    }
}
