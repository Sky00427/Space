using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    [SerializeField, Min(0.01f)]
    private float lifetime = 0.2f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}