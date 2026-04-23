using System.Collections;
using UnityEngine;

public class MoviengCude : MonoBehaviour
{
    [SerializeField] GameObject PointA;
    [SerializeField] GameObject PointB;
    [SerializeField] float speed = 10f;
    [SerializeField] float delay = 1f;
    [SerializeField] GameObject MovingCube;

    private Vector3 tragetPosition;
    void Start()
    {
        MovingCube.transform.position = PointA.transform.position;
        tragetPosition = PointB.transform.position;
        StartCoroutine(MovePlatform());

    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            while (Vector3.Distance(MovingCube.transform.position, tragetPosition) > 0.1f)
            {
                MovingCube.transform.position = Vector3.MoveTowards(MovingCube.transform.position, tragetPosition, speed * Time.deltaTime);
                yield return null;
            }
            tragetPosition = tragetPosition == PointA.transform.position
                ? PointB.transform.position : PointA.transform.position;
            yield return new WaitForSeconds(delay);
        }
    }


}

