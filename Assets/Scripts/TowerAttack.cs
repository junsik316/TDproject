using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] LayerMask checkingLayer;
    public Collider2D[] NearEnemy;
    public float Range;
    private float AttackDelay;
    public float AttackTime;
    Animator animator;
    
    public GameObject Arrow;
    public float angle;
    private Quaternion rotation;
    public Collider2D Target;
   
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
                if (NearEnemy.Length == 1) Target = NearEnemy[0];
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
                
                Debug.Log("Attack");
                
                AttackDelay = 0f;
                angle = Mathf.Atan2(this.gameObject.transform.position.y - Target.gameObject.transform.position.y, this.gameObject.transform.position.x - Target.gameObject.transform.position.x) * Mathf.Rad2Deg;
                this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Quaternion rotaton = Quaternion.Euler(0,0,angle + 90);
                Instantiate(Arrow, transform.position,rotaton,transform);
                animator.SetTrigger("Shoot");
                
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
