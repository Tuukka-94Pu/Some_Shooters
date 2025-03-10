using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace HJ
{
    public class HJ_EnemyPatrol : MonoBehaviour
    {
        public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            agent.autoBraking = false;

            GoToNextPoint();
        }

        void GoToNextPoint()
        {
            if (points.Length == 0)
                return;

            agent.destination = points[destPoint].position;

            destPoint = (destPoint + 1) % points.Length;
        }

        private void Update()
        {
            if (agent.remainingDistance < 0.5f)
                GoToNextPoint();
        }
    }
}