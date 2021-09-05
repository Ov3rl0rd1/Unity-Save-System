using System.IO;
using UnityEngine;

namespace UnitySaveSystem
{
    public class SaveFile
    {
        public readonly string JsonFilePath;
        public readonly string SaveFolderPath;

        private SaveFileClassesManager saveClassesManager;

        public T LoadClass<T>()
        {
            return JsonUtility.FromJson<T>(File.ReadAllText(JsonFilePath));
        }

        public void SaveClass<T>(T classToSave)
        {
            saveClassesManager.AddClass(classToSave, SaveFolderPath);
        }

        public SaveFile(string pathToSave, string saveName)
        {
            SaveFolderPath = pathToSave + saveName;
            JsonFilePath = SaveFolderPath + saveName + ".json";
            if (Directory.Exists(JsonFilePath) == false)
            {
                Directory.CreateDirectory(SaveFolderPath);
                File.Create(pathToSave).Close();
                saveClassesManager = new SaveFileClassesManager(SaveFolderPath);
            }
            else
            {
                throw new System.Exception("Save file with the same name already exists");
            }
        }
    }
}
