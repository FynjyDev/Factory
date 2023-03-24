using System.Collections.Generic;
using UnityEngine;

public class ItemMoving : MonoBehaviour
{
    public List<PathPoint> convoyerPathPoints;
    public bool isMovingEnd;

    private Transform _ItemTr;
    private float _MinDistanceToPoint;
    private int _TempPointIndex;

    private float _MoveSpeed => SingletonController.singletonController.config.moveSpeed;

    private void FixedUpdate()
    {
        if (!_ItemTr) _ItemTr = transform;
        if (!isMovingEnd) Move();
    }

    private void Move()
    {
        if (_TempPointIndex >= convoyerPathPoints.Count) isMovingEnd = true;
        else
        {
            _ItemTr.position = Vector3.MoveTowards(transform.position, convoyerPathPoints[_TempPointIndex].transform.position, _MoveSpeed * Time.deltaTime);

            float _distanceToPoint = (_ItemTr.position - convoyerPathPoints[_TempPointIndex].transform.position).sqrMagnitude;
            if (_distanceToPoint <= _MinDistanceToPoint) _TempPointIndex++;
        }
    }
}