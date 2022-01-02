using System.IO;
using UnityEngine;
using System;

namespace SaveSystem
{
    public class UnitySaver
    {
        private string _saveFolder = Path.Combine(Application.persistentDataPath, "Saves");
        private Saver _saver = new Saver();

        public UnitySaver()
        {
            if (Directory.Exists(_saveFolder) == false)
                Directory.CreateDirectory(_saveFolder);
        }

        public void Save<T>(T classToSave, string saveName)
        {
            if (Directory.Exists(_saveFolder) == false) Directory.CreateDirectory(_saveFolder);

            var saveData = new SaveData<T>() { Name = saveName, SaveDate = DateTime.UtcNow, Data = classToSave };
            _saver.SaveData(saveData, Path.Combine(_saveFolder, saveName));
        }

        public T Load<T>(string saveName)
        {
            var loadedData = _saver.LoadData<SaveData<T>>(Path.Combine(_saveFolder, saveName));

            return loadedData.Data;
        }

        public SaveData<T>[] GetSaves<T>()
        {
            string[] savesNames = _saver.GetSavesFilesFromFolder(_saveFolder);

            var Saves = new SaveData<T>[savesNames.Length];

            for (int i = 0; i < savesNames.Length; i++)
            {
                Saves[i] = _saver.LoadData<SaveData<T>>(savesNames[i]);
            }

            return Saves;
        }
    }

    [Serializable]
    public class SaveData<T>
    {
        public string Name;
        public DateTime SaveDate;
        public T Data;
    }
    

}
