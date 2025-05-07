using System;
using UnityEngine;

public class CheckerMovement : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField] private float speed;
    private SelectedPath _selectedPath;
    private GameObject _tileToMoveTo;
    private int _index;
    private float _yAxis;

    private void Awake()
    {
        _selectedPath = SelectedPath.GetInstance();
    }

    private void Start()
    {
        _yAxis = transform.position.y;
    }

    private void Update()
    {
        GetData();
        CheckTileToMoveTo();
        Movement();
    }

    private void GetData()
    {
        _tileToMoveTo = _selectedPath.TilesOnPath(_index);
        if (_tileToMoveTo.CompareTag("EndTile")) 
        {
            Debug.Log("eind bereikt");
            Destroy(gameObject);
        }
    }

    private void CheckTileToMoveTo()
    {
        if (transform.position.x > _tileToMoveTo.transform.position.x -0.01f
        && transform.position.x < _tileToMoveTo.transform.position.x + 0.01f
        && transform.position.z > _tileToMoveTo.transform.position.z - 0.01f
        && transform.position.z < _tileToMoveTo.transform.position.z + 0.01f) 
        {
            _index++;
        }
    }

    private void Movement()
    {
        transform.position = Vector3.Lerp(transform.position, _tileToMoveTo.transform.position, speed);
        transform.position = new Vector3(transform.position.x, _yAxis, transform.position.z);
    }
}
