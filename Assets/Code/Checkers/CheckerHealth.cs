using System.Collections;
using UnityEngine;

public class CheckerHealth : MonoBehaviour
{
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private int _hp;
    [SerializeField] private Mesh[] meshes;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Material _standardMat;
    [SerializeField] private Material _greenMat;
    private DataManager _dataManager;

    private void Start()
    {
        _dataManager = DataManager.GetInstance();
    }

    private void Update()
    {
        CalcHp();
    }

    private void CalcHp()
    {
        _meshFilter.mesh = meshes[_hp - 1];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Attacker"))
        {
            _hp--;
            _dataManager.Money += 5;
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Sphere"))
        {
            StartCoroutine(SlowDown());
        }
    }

    private IEnumerator SlowDown()
    {
        _renderer.material = _greenMat;
        yield return new WaitForSeconds(1);
        _renderer.material = _standardMat;
    }
}
