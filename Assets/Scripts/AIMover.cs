using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _motionAreaSize = 4;

    private Vector3 _target;

    private void Start()
    {
        NextTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
            NextTarget();
    }

    private void NextTarget()
    {
        _target = Random.insideUnitCircle * _motionAreaSize;
    }
}
