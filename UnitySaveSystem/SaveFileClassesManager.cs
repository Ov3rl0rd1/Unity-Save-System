using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UnitySaveSystem
{
    class SaveFileClassesManager
    {
        private List<string> _classesSavePath = new List<string>();
        private readonly string _saveFolderPath;

        public void AddClass<T>(T classToSave)
        {
            if (Directory.Exists(_saveFolderPath) == false)
                Directory.CreateDirectory(Path.Combine(_saveFolderPath, classToSave.ToString() + ".json"));

            var classPath = Path.Combine(_saveFolderPath, classToSave.ToString() + ".json");
            File.AppendAllText(classPath, JsonUtility.ToJson(classToSave));
            _classesSavePath.Add(classPath);
        }

        public T GetClass<T>()
            where T : new()
        {
            T Type = new T();
            string classType = Type.ToString();

            var classPath = Path.Combine(_saveFolderPath, classType.ToString() + ".json");
            return JsonUtility.FromJson<T>(File.ReadAllText(classPath));
        }

        public void RemoveClass<T>(T classToRemove)
        {
            if (Directory.Exists(_saveFolderPath) == false)
                throw new System.Exception("Save file with this name does not exist");


            if (_classesSavePath.Remove(Path.Combine(_saveFolderPath, classToRemove.ToString() + ".json")) == false)
                throw new System.Exception("Save file with this name does not exist");
        }

        public SaveFileClassesManager(string saveFolderPath)
        {
            _saveFolderPath = Path.Combine(saveFolderPath, "classes");
        }
    }
}