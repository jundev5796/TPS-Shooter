using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Slider HPBar;

    private float enemyMaxHP = 10;
    public float enemyCurrentHP = 0;

    void Start()

    {
        InitEnemyHP();
    }

    void Update()
    {
        HPBar.value = enemyCurrentHP / enemyMaxHP;
    }

    private void InitEnemyHP()
    {
        enemyCurrentHP = enemyMaxHP;
    }
}
