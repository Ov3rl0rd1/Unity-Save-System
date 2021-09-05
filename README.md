# How to import
To use this save system you must to add UnitySaveSystem.dll to your unity project

# How to use
So that you can save the class you must mark it with an attribute [System.Serializable].

```C#

  using UnitySaveSystem;
  using UnityEngine;
  using System;

  public class SaveTest : MonoBehaviour
  {
    private SaveFile _save;

    public void Awake()
    {
        _save = new SaveFile(@"C:\Save\Save1"); // Here you can point the path to your save file.
    }
    
    [SerializeField] SaveTestData saveData;
    public void Save()
    {
        _save.SaveClass(saveData); // This command save your class to JSON file
    }

    public void Load()
    {
        saveData = _save.LoadClass<SaveTestData>(); // This command try to load your class
    }
  }

  [Serializable]
  public class SaveTestData
  {
      public int TestField1;
  }

```
Unsupported fields will be ignored, as will private fields, static fields, and fields with the NonSerialized attribute applied.
