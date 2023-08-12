using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] _wayPoints;
    private int _pointIndex = 0;
    [SerializeField] private float _speed = 2f;


    void Update()
    {
        if (Vector2.Distance(_wayPoints[_pointIndex].transform.position, transform.position) < .1f)
        {
            _pointIndex++;
            if (_pointIndex >= _wayPoints.Length)
            {
                _pointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_pointIndex].transform.position, Time.deltaTime * _speed);


    }
}
