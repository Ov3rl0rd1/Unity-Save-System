using UnityEngine;
using System.IO;

namespace UnitySaveSystem
{
    public class UnitySaveSystem : MonoBehaviour
    {
        public void GetSavesFileFromFolder(string path)
        {
            var files = Directory.GetFiles(path, "*.json");
        }
    }
    

}
