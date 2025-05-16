using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    public static DataPersistenceManager Instance { get; private set; }

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    public CombatManager combatManager;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("found more than one data persistence manager");
        }
        Instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            NewGame();
        }

        foreach (IDataPersistence dataPersistence in dataPersistenceObjects)
        {
            dataPersistence.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        if(combatManager.inCombat == false)
        {
            foreach (IDataPersistence dataPersistence in dataPersistenceObjects)
            {
                dataPersistence.SaveData(ref gameData);
            }

            dataHandler.Save(gameData);
        }
    }

    private void OnApplicationQuit()
    {
        if (combatManager.inCombat == false)
        {
            SaveGame();
        }  
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType < IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
