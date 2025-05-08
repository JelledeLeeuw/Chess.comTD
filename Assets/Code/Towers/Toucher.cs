using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Toucher : MonoBehaviour
{
    [System.Serializable]
    public class Tower
    {
        public string Name;
        public GameObject gameObject;
        public Mesh PrelookMesh;
        public int Price;
    }

    [SerializeField] private List<Tower> possibleTowers = new List<Tower>();
    [SerializeField] private GameObject indicator;
    [SerializeField] private InputAction mousePos;
    [SerializeField] private InputAction mouseClick;
    [SerializeField] private Vector3 offSet;
    private DataManager _dataManager;
    private GameObject _indicatorInstance;
    private int _money;
    private Vector3 _mousePos;
    private float _mouseClick;

    private Tower _currentTower;
    private bool _isPlacing;

    private void OnEnable()
    {
        mouseClick.Enable();
        mousePos.Enable();
    }

    private void OnDisable()
    {
        mouseClick.Disable();
        mousePos.Disable();
    }

    private void Start()
    {
        _indicatorInstance = Instantiate(indicator);
        _indicatorInstance.SetActive(false);
        _dataManager = DataManager.GetInstance();
    }

    private void Update()
    {
        GetData();
        GetInput();
        Placing();
    }

    private void GetInput()
    {
        Vector2 _mousePosLoc = mousePos.ReadValue<Vector2>();
        _mousePos = new Vector3(_mousePosLoc.x, _mousePosLoc.y, 0);
        _mouseClick = mouseClick.ReadValue<float>();
    }

    private void GetData()
    {
        _money = _dataManager.Money;
    }

    private void Placing()
    {
        if (_isPlacing)
        {
            _indicatorInstance.SetActive(false);

            Ray ray = Camera.main.ScreenPointToRay(_mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.CompareTag("PlaceableTile"))
                {
                    _indicatorInstance.SetActive(true);
                    _indicatorInstance.transform.position = hit.transform.position + new Vector3(-0.5f, 0f, 0.5f);

                    if (_mouseClick != 0)
                    {
                        _dataManager.Money -= _currentTower.Price;

                        GameObject tower = Instantiate(_currentTower.gameObject, hit.transform.position + offSet, Quaternion.identity);
                        //tower.transform.parent = hit.transform;

                        //hit.collider.enabled = false;
                        hit.transform.tag = "Untagged";
                        _currentTower = null;
                        _isPlacing = false;
                        _indicatorInstance.SetActive(false);
                    }
                }
            }
        }
    }

    public void HoldTower(int obj)
    {
        _currentTower = possibleTowers[obj];

        if (_currentTower != null)
        {
            if (_currentTower.Price <= _money)
            {
                _indicatorInstance.GetComponent<MeshFilter>().mesh = _currentTower.PrelookMesh;
                _isPlacing = true;
            }
        }
    }
}