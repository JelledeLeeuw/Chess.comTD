using System.Collections;
using UnityEngine;

public class Rook : MonoBehaviour
{
    private GameObject _tileToAttack;
    private Vector3 _startPos;
    private bool _attack;
    [SerializeField] private Collider[] _colliders;

    private void Start()
    {
        _startPos = transform.position;
        StartCoroutine(StartAttack());
    }

    private void FixedUpdate()
    {
        Attack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tile"))
        {
            _tileToAttack = other.gameObject;
            for (int i = 0; i < _colliders.Length; i++)
            {
                Destroy(_colliders[i]);
            }
        }
    }

    private void Attack()
    {
        if (_attack == true)
        {
            transform.position = Vector3.Lerp(transform.position, _tileToAttack.transform.position, 0.1f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _startPos, 0.1f);
        }
    }



    private IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(1.5f);
        _attack = true;
        yield return new WaitForSeconds(1f);
        _attack = false;
        StartCoroutine(StartAttack());
    }
}
