using UnityEngine;

public class Pendulum : MonoBehaviour
{

    public float speed = 15f;
    public float limit = 75f;
    public bool randomStart = false;
    private float random = 0f;

    private void Awake()
    {
        if (randomStart)
        {
            random = Random.Range(0f, 1f);
        }
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed + random) * limit;
        transform.localRotation = Quaternion.Euler(0, 0, angle);    
    }

}
