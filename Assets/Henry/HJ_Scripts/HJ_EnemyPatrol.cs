using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace HJ
{
    public class HJ_EnemyPatrol : MonoBehaviour
    {
        public Transform[] points;
        public float waitTime = 2f; // Time to wait at each point
        private int destPoint = 0;
        private NavMeshAgent agent;
        private bool isWaiting = false;

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

            // Allow movement again
            agent.isStopped = false;
            agent.updateRotation = true;
            agent.SetDestination(points[destPoint].position);

            destPoint = (destPoint + 1) % points.Length;
        }

        private void Update()
        {
            if (!isWaiting && !agent.pathPending && agent.remainingDistance < 0.5f)
            {
                StartCoroutine(WaitBeforeNextPoint());
            }
        }

        private IEnumerator WaitBeforeNextPoint()
        {
            isWaiting = true;

            // **Force stop by setting destination to current position**
            agent.SetDestination(agent.transform.position);
            agent.velocity = Vector3.zero;
            agent.updateRotation = false; // Prevent rotation while waiting

            yield return new WaitForSeconds(waitTime);

            // Reactivate movement
            agent.updateRotation = true;
            isWaiting = false;
            GoToNextPoint();
        }
    }
}
