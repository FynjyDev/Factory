using System.Collections.Generic;
using UnityEngine;

public class ItemMoving : MonoBehaviour
{
    public SingletonController singletonController => SingletonController.singletonController;

    public ItemCollision itemCollision;

    [HideInInspector] public List<PathPoint> convoyerPathPoints;

    [SerializeField] private DestroyTimer destroyTimer;
    [SerializeField] private Rigidbody itemBody;

    [SerializeField] private bool isMovingEnd;

    private Transform itemTr;
    private float minDistanceToPoint;
    private int tempPointIndex;

    private float _MoveSpeed => singletonController.Config.MoveSpeed;

    private void FixedUpdate()
    {
        if (!itemTr) itemTr = transform;
        if (!isMovingEnd) Move();
    }

    private void Move()
    {
        if (tempPointIndex >= convoyerPathPoints.Count) OnPathEnd();
        else
        {
            itemTr.position = Vector3.MoveTowards(transform.position, convoyerPathPoints[tempPointIndex].transform.position, _MoveSpeed * Time.deltaTime);

            float _distanceToPoint = (itemTr.position - convoyerPathPoints[tempPointIndex].transform.position).sqrMagnitude;
            if (_distanceToPoint <= minDistanceToPoint) tempPointIndex++;
        }
    }

    private void OnPathEnd()
    {
        itemCollision.Conveyor.OnItemEndPath(this);

        isMovingEnd = true;
        itemBody.isKinematic = false;
        itemBody.useGravity = true;

        destroyTimer.isDestroyEnabled = true;
    }
}
