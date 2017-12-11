using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour {
    private Animator _animator;
    private EnemyEventBus _eventBus;
    private NavMeshAgent _meshMeshAgent;
    private CapsuleCollider _collider;
    
    // Use this for initialization
    void Start () {

        _animator = GetComponent<Animator>();
        _meshMeshAgent = GetComponent<NavMeshAgent>();
        _collider = GetComponent<CapsuleCollider>();        
        _eventBus = GetComponent<EnemyEventBus>();

        _eventBus.HasDied += eventBus_HasDied;
        _eventBus.HasReachedTarget += eventBus_HasReachedTarget;
        _eventBus.AwayFromTarget += eventBus_AwayFromTarget;

        StartCoroutine(StartWalkingRandomPosition());

        Walk();
    }

    private IEnumerator StartWalkingRandomPosition()
    {
        _animator.speed = Random.Range(0, 2000);
        yield return new WaitForSeconds(0.1f);
        _animator.speed = _meshMeshAgent.speed;
    }

    private void eventBus_AwayFromTarget()
    {
        Walk();
    }

    private void eventBus_HasReachedTarget()
    {
        Attack();
    }

    private void eventBus_HasDied()
    {
        Die();
    }

    private void Die()
    {
        _animator.SetBool("Walk", false);
        _animator.SetBool("Attack", false);

        var random = Random.Range(0, 100);

        if (random <= 33.3)
            _animator.SetBool("DieLeft", true);
        else if (random <= 66.6)
            _animator.SetBool("DieRight", true);
        else
            _animator.SetBool("DieBack", true);
        
    }

    void Walk()
    {
        _animator.SetBool("Walk", true);
        _animator.SetBool("Attack", false);
    }

    void Attack()
    {
        _animator.SetBool("Walk", false);
        _animator.SetBool("Attack", true);
    }

    public void StrikeOne()
    {
        _eventBus.InvokeStrike();
    }

    public void StrikeTwo()
    {
        _eventBus.InvokeStrike();
    }

    public void StrikeThree()
    {
        _eventBus.InvokeStrike();
    }
}
