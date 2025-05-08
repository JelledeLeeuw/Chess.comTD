using UnityEngine;

public class CheckerHealth : MonoBehaviour
{
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private int _hp;
    [SerializeField] private Mesh[] meshes;

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
            if(_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
