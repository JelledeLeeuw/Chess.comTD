using System;
using UnityEngine;

public class CheckerMovement : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField] private float speed;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetZ;
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
        GetData();
        _yAxis = transform.position.y;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        GetData();
        CheckTileToMoveTo();
    }

    private void GetData()
    {
        _tileToMoveTo = _selectedPath.TilesOnPath(_index);
        if (_tileToMoveTo.CompareTag("EndTile")) 
        {
            Destroy(gameObject);
        }
    }

    private void CheckTileToMoveTo()
    {
        if (transform.position.x > _tileToMoveTo.transform.position.x - 0.01f + offsetX
        && transform.position.x < _tileToMoveTo.transform.position.x + 0.01f + offsetX
        && transform.position.z > _tileToMoveTo.transform.position.z - 0.01f + offsetZ
        && transform.position.z < _tileToMoveTo.transform.position.z + 0.01f + offsetZ)
        {
            _index++;
        }
    }

    private void Movement()
    {
        Vector3 _offset = new Vector3(offsetX, 0, offsetZ);
        transform.position = Vector3.Lerp(transform.position, _tileToMoveTo.transform.position + _offset, speed);
        transform.position = new Vector3(transform.position.x, _yAxis, transform.position.z);
    }
}
