using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;
    public static DataManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = FindFirstObjectByType<DataManager>();
        }
        return _instance;
    }

    private int _money;
    public int Money
    {
        get 
        { 
            return _money; 
        }
        set
        {
            _money = value;
        }
    }
}
