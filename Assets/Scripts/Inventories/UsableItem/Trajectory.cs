using System;
using System.Collections.Generic;
using UnityEngine;

namespace WhizzBang.Inventories.UsableItem
{
    [RequireComponent(typeof(LineRenderer))]
    public class Trajectory : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [Range(2, 30)]
        [SerializeField] private int lineSegmentsCount;
        
        private void Start()
        {
            lineRenderer.positionCount = lineSegmentsCount + 1;
        }

        public void Visualize(Vector3 velocity, Transform origin, Vector3 finalPosition, float flightTime)
        {
            for (int i = 0; i < lineSegmentsCount; i++)
            {
                var position = CalculatePositionInTime(velocity, origin,(i / (float)lineSegmentsCount) * flightTime);
                lineRenderer.SetPosition(i, position);
            }
     
            lineRenderer.SetPosition(lineSegmentsCount, finalPosition);
        }
        
        private Vector3 CalculatePositionInTime(Vector3 velocity, Transform origin, float timePoint)
        {
            var velocityXZ = velocity;
            velocityXZ.y = 0f;
     
            var result = origin.position + velocity * timePoint;
            var yPosition = (-0.5f * Mathf.Abs(Physics.gravity.y) * (timePoint * timePoint)) + (velocity.y * timePoint) + origin.position.y;
            result.y = yPosition;
     
            return result;
        }
    }
}
