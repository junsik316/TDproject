using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class TowerAttack : MonoBehaviour
{
    public UnityEvent<Collider2D> OnShoot;
    [SerializeField] LayerMask checkingLayer;
    public Collider2D[] NearEnemy;
    public float Range;
    private float AttackDelay;
    public float AttackTime;
    Animator animator;
    public int AttackDamage;
    public GameObject Arrow;
    [SerializeField]public Collider2D Target;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void FixedUpdate()
    {
        if (NearEnemy != null && NearEnemy.Length >= 0 )
        {
            if (NearEnemy.Length >= 1)
            {
                float short_distance = Vector2.Distance(transform.position, NearEnemy[0].transform.position);
                foreach (Collider2D col in NearEnemy)
                {
                    float short_distance2 = Vector2.Distance(transform.position, col.transform.position);
                    if (short_distance > short_distance2)
                    {
                        short_distance = short_distance2;
                        Target = col;
                    }
                }

            }
            if (AttackDelay > AttackTime && Target != null)
            {
                Damagable target = Target.GetComponent<Damagable>();
                Debug.Log("Attack");
                target.Curhealth -= AttackDamage;
                AttackDelay = 0f;
                animator.SetTrigger("Shoot");
                Instantiate(Arrow);
                OnShoot?.Invoke(Target);
                
            }
            AttackDelay += Time.deltaTime;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        NearEnemy = Physics2D.OverlapCircleAll(transform.position,Range, checkingLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,Range);
    }

    
}
