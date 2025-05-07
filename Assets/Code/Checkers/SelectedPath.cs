using UnityEngine;

public class SelectedPath : MonoBehaviour
{
    private static SelectedPath _instance;
    public static SelectedPath GetInstance()
    {
        if (_instance == null)
        {
            _instance = FindFirstObjectByType<SelectedPath>();
        }
        return _instance;
    }

    [Header("Path Settings")]
    [SerializeField] private GameObject[] _tilesOnPath;
    public GameObject TilesOnPath(int _index)
    {
        return _tilesOnPath[_index];
    }
}
