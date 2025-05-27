using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Slider HPBar;

    private float enemyMaxHP = 10;
    public float enemyCurrentHP = 0;

    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        InitEnemyHP();
    }

    void Update()
    {
        HPBar.value = enemyCurrentHP / enemyMaxHP;

        if (enemyCurrentHP <= 0)
        {
            StartCoroutine(EnemyDie());
            return;
        }
    }

    private void InitEnemyHP()
    {
        enemyCurrentHP = enemyMaxHP;
    }

    IEnumerator EnemyDie()
    {
        agent.speed = 0;
        anim.SetTrigger("Dead");

        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
