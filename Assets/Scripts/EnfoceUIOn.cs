using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnfoceUIOn : MonoBehaviour
{
    public GameObject TowerUI;
    public bool IsUIOpened;
    public int TowerEnfoced
    {
        get { return _TowerENfoced; }
        set {
            cost = TowerData.towers[TowerEnfoced].cost;
            _TowerENfoced = value;
            if (value % 5 == 0) Upgrade();
        }
    }
    public Sprite[] TowerSprite;
    private int _TowerENfoced = 1;
    public UnityEvent<Vector3> Onclick;
    public GameObject TowerPoint;
    TowerSell TowerSell;
    public bool Sold = false;
    SpriteRenderer TowerRenderer;
    private int TowerUpgradecnt;
    public GameObject Arrow;
    [SerializeField] TowerData TowerData;
    public int cost;
    TowerAttack TowerAttack;
    WizradAttack WizradAttack;


    private void Start()
    {
        TowerRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnMouseDown()
    {
        if (!GameManager.isEnfoceUIOn)
        {
            GameManager.isEnfoceUIOn = true;
            

            Instantiate(TowerUI,gameObject.transform);
          
            TowerSell = GetComponentInChildren<TowerSell>();
        }
        else return;
    }

    public void GetBuildPos(GameObject go)
    {
        TowerPoint = go;
    }
    private void FixedUpdate()
    {
        if (Sold)
        {
            GameManager.isEnfoceUIOn = false;
            Destroy(gameObject);
        }
    }
    private void Upgrade()
    {
       if(gameObject.tag == "마법사")
        {
            WizradAttack = GetComponent<WizradAttack>();
            WizradAttack.Range = TowerData.towers[TowerEnfoced].range;
        }
        
        if (gameObject.tag == "아쳐")
        {
            TowerAttack = GetComponentInChildren<TowerAttack>();
            TowerAttack.Range = TowerData.towers[TowerEnfoced].range;

        }
        TowerUpgradecnt++;
        TowerRenderer.sprite = TowerSprite[TowerUpgradecnt];
    }

}
