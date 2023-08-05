# How to import
To use this save system you must to add UnitySaveSystem.dll to your unity project

# How to use
So that you can save the class you must mark it with an attribute [System.Serializable].

```C#

  using SaveSystem;
  using UnityEngine;
  using System;

  public class SaveTest : MonoBehaviour
  {
    private UnitySaver _saver;

    public void Awake()
    {
        _saver = new UnitySaver(); // Here you can point the path to your save file.
    }
    
    [SerializeField] SaveTestData saveData;
    public void Save()
    {
        _saver.Save(saveData, "saveName.dat"); // This command save your class to binary file
    }

    public void Load()
    {
        saveData = _saver.Load<SaveTestData>("saveName.dat"); // This command try to load your class
    }
  }

  [Serializable]
  public class SaveTestData
  {
      public int TestField1;
  }

```
Unsupported fields will be ignored, as will private fields, static fields, and fields with the NonSerialized attribute applied.
