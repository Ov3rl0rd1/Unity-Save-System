using UnitySaveSystem;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    private SaveFile _save;

    private void Awake()
    {
        _save = new SaveFile(@"C:\Save\Save1");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Load();
        }
    }

    [SerializeField] SaveTestData saveData;

    public void Save()
    {
        _save.SaveClass(saveData);
    }

    public void Load()
    {
        saveData = _save.LoadClass<SaveTestData>();
    }
}
