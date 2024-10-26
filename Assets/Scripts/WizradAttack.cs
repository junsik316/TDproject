using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizradAttack : MonoBehaviour
{
    [SerializeField] LayerMask checkingLayer;
    public Collider2D[] NearEnemy;
    public float Range;
    private float AttackDelay;
    public float AttackTime;
    public GameObject Bullet;
    public Collider2D Target;
   
    private void FixedUpdate()
    {
        if (NearEnemy != null && NearEnemy.Length >= 0)
        {
            if (NearEnemy.Length >= 1)
            {
                if (NearEnemy[0]==null) return;
                if(NearEnemy.Length == 1) Target = NearEnemy[0];
                
                float short_distance = Vector2.Distance(transform.position, NearEnemy[0].transform.position);
                foreach (Collider2D col in NearEnemy)
                {
                    if(col == null) continue;
                    float short_distance2 = Vector2.Distance(transform.position, col.transform.position);
                    if (short_distance > short_distance2)
                    {
                        short_distance = short_distance2;
                        if(col!=null) Target = col;
                    }
                }
            }
            if (AttackDelay > AttackTime && Target != null)
            {
                AttackDelay = 0f;
                Instantiate(Bullet, transform);
            }
            AttackDelay += Time.deltaTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        NearEnemy = Physics2D.OverlapCircleAll(transform.position, Range, checkingLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }


}

