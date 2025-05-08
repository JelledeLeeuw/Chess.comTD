using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    private float timeALive = 0;

    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.forward;

        timeALive += Time.deltaTime;
        if (timeALive > lifeTime)
        {
            timeALive = 0;
            gameObject.SetActive(false);
        }
    }
}