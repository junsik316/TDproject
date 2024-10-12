using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Arrow : MonoBehaviour
{
    
    Rigidbody2D rb;
    TowerAttack ta;
    Quaternion Angle;
    public int AttackDamage;
    Collider2D target;
    [SerializeField] private float Speed = 0.03f;
    private void Awake()
    {
        ta = GetComponentInParent<TowerAttack>();
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    private void Start()
    {
        target = ta.Target;
    }

    private void FixedUpdate()
    {
        if (target == null) { Destroy(gameObject); }
        if (target != null) transform.position = Vector2.MoveTowards(transform.position, target.gameObject.transform.position, Speed * Time.deltaTime);


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (target == collision)
        {
            Damagable damagable = target.GetComponent<Damagable>();
            damagable.Curhealth -= AttackDamage;
            Destroy(gameObject);
        }
    }
}
