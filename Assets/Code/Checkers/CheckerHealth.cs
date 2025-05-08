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
}
