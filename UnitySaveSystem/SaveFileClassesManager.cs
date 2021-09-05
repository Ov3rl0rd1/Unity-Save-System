using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UnitySaveSystem
{
    class SaveFileClassesManager
    {
        private List<string> _classesSavePath = new List<string>();
        private string _saveFolderPath;

        public void AddClass<T>(T classToSave)
        {
            
            if (Directory.Exists(_saveFolderPath) == false) 
                Directory.CreateDirectory(_saveFolderPath);

            var classPath = Path.Combine(_saveFolderPath, classToSave.ToString() + ".json");
            File.AppendAllText(classPath, JsonUtility.ToJson(classToSave));
            _classesSavePath.Add(classPath);
        }

        public void RemoveClass<T>(T classToRemove)
        { 
            
        }

        public SaveFileClassesManager(string saveFolderPath)
        {
            _saveFolderPath = Path.Combine(saveFolderPath, "classes");
        }
    }
}
