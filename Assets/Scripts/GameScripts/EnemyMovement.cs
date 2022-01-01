using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    //whether the enemy waits on each node
    [SerializeField]
    bool _patrolWaiting;

    //The total time wait for each node
    [SerializeField]
    float _totalWaitTime = 3f;

    // The probability of switching direaction.
    [SerializeField]
    float _swithcProbability = 0.2f;

    [SerializeField]
    List<Waypoint> _patrolPoints;

    // Private varaible for base behaviour
    NavMeshAgent _navMeshAgent;
    int _currentPatrolIndex;
    bool _travelling;
    bool _waiting;
    bool _patrolForward;
    float _waitTimer;
    GameObject player;
    public float aggroRadius;
    Light AggroRange;
    public float agentSpeed;

    public Animator enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = agentSpeed;
        player = GameObject.FindGameObjectWithTag("Player");
        AggroRange = GameObject.Find("AggroRangeLight").GetComponent<Light>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            if (_patrolPoints != null && _patrolPoints.Count >= 2)
            {
                _currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("Insufficient patrol points for basic patrolling behaviour.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float distanceToTarget = vectorToTarget.magnitude;

        if (distanceToTarget <= aggroRadius)
        {
            _navMeshAgent.SetDestination(player.transform.position);
            AggroRange.color = Color.red;
        }
        else
        {

            // Check if we're close to the destination
            if (_travelling && _navMeshAgent.remainingDistance <= 1.0f)
            {
                _travelling = false;

                // If going to wait, then wait.
                if (_patrolWaiting)
                {
                    _waiting = true;
                    _waitTimer = 0f;
                }
                else
                {
                    ChangePatrolPoint();
                    SetDestination();
                }
            }

            // Instead if we are waiting.
            if (_waiting)
            {
                enemyMovement.SetBool("isWalking", false);
                _waitTimer += Time.deltaTime;
                if (_waitTimer >= _totalWaitTime)
                {
                    _waiting = false;
                    enemyMovement.SetBool("isWalking", true);
                    ChangePatrolPoint();
                    SetDestination();
                }
            }
        }
    }

    public virtual void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRadius);
    }

    private void SetDestination()
    {
        if (_patrolPoints != null)
        {
            Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
            _navMeshAgent.SetDestination(targetVector);
            _travelling = true;
            AggroRange.color = Color.green;
        }
    }

    private void ChangePatrolPoint()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= _swithcProbability)
        {
            _patrolForward = !_patrolForward;
        }

        if (_patrolForward)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
        }
        else
        {
            if (--_currentPatrolIndex < 0)
            {
                _currentPatrolIndex = _patrolPoints.Count - 1;
            }
        }
    }
}
