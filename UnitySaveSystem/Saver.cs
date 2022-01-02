using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace SaveSystem
{
    class Saver
    {
        private BinaryFormatter _formater => GetFormater();

        public string[] GetSavesFilesFromFolder(string path) => Directory.GetFiles(path);

        public void SaveData<T>(T classToSave, string filePath)
        {
            using (FileStream stream = File.Create(filePath))
            {
                _formater.Serialize(stream, classToSave);
            }
        }

        public T LoadData<T>(string filePath)
        {
            T returnData;
            using (FileStream file = File.Open(filePath, FileMode.Open))
            {
                object loadedData = _formater.Deserialize(file);
                returnData = (T)loadedData;
            }
            return returnData;
        }

        private BinaryFormatter GetFormater()
        {
            var formatter = new BinaryFormatter();
            var surrogateSelector = new SurrogateSelector();

            surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All),
                new Vector3Serializer());
            surrogateSelector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All),
                new Vector2Serializer());
            surrogateSelector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All),
                new QuaternionSerializer());

            formatter.SurrogateSelector = surrogateSelector;
            return formatter;
        }

        public void DeleteSave(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                throw new System.ArgumentException("File does not exist");
            }
        }
    }


}
