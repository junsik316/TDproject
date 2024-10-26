using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class WizardBullet : MonoBehaviour
{
    [SerializeField] TowerData TowerData;
    WizradAttack wa;
    [SerializeField] private int Damage = 20;
    private Collider2D target;
    EnfoceUIOn EnfoceUIOn;
    public float Speed = 0.9f;
    // Start is called before the first frame update
    private void Awake()
    {
        wa = GetComponentInParent<WizradAttack>();
    }

    private void Start()
    {
        EnfoceUIOn = GetComponentInParent<EnfoceUIOn>();
        target = wa.Target;
        Damage = TowerData.towers[EnfoceUIOn.TowerEnfoced - 1].damage;
        Speed = wa.Range;
    }

    private void FixedUpdate()
    {
        if (target == null) { Destroy(gameObject); }
        if(target != null) { transform.position = Vector2.MoveTowards(transform.position, target.gameObject.transform.position, Speed * Time.deltaTime); }
        
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
