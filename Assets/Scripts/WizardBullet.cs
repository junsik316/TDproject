using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBullet : MonoBehaviour
{
    WizradAttack wa;
    [SerializeField] private int Damage = 20;
    private Collider2D target;
    // Start is called before the first frame update
    private void Awake()
    {
        wa = GetComponentInParent<WizradAttack>();
    }

    private void Start()
    {
        target = wa.Target;
    }

    private void FixedUpdate()
    {
        if (target == null) { Destroy(gameObject); }
        if(target != null) { transform.position = Vector2.MoveTowards(transform.position, target.gameObject.transform.position, 0.9f * Time.deltaTime); }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == target)
        {
            Damagable damagable =  target.GetComponent<Damagable>();
            if (damagable != null)
            {
                { damagable.Curhealth -= Damage; }
                Destroy(gameObject);
            }
        }
        
    }

}
