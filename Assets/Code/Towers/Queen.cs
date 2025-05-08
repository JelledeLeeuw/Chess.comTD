using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Queen : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [Header("bullets")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootTime;
    [SerializeField] private int amountOfBullets;
    private readonly List<GameObject> bulletInstances = new();

    private void Start()
    {
        for (int i = 0; i < amountOfBullets; i++)
        {
            bulletInstances.Add(Instantiate(bullet));
            bulletInstances[i].SetActive(false);
        }

        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        float timePassed = 0;

        while (true)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

            timePassed += Time.deltaTime;

            if (timePassed > shootTime)
            {
                timePassed = 0;

                for (int i = 0; i < amountOfBullets; i++)
                {
                    GameObject currentBullet = bulletInstances[i];

                    if (!currentBullet.activeSelf)
                    {
                        currentBullet.SetActive(true);
                        currentBullet.transform.SetPositionAndRotation(transform.position + new Vector3(0,-0.35f,0), transform.rotation);
                        break;
                    }
                }
            }

            yield return null;
        }
    }
}
