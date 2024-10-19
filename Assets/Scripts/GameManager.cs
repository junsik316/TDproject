using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject Endpoint;
    public GameObject MoneyUI;
    MoneyUI moneyUI;
    private static GameManager _instance;
    public static int liveEnemy;
    public static int money=500;
    public static float moneyEarn=1f;
    public static GameManager Instance
    {
        get
        {
           
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        moneyUI = MoneyUI.GetComponent<MoneyUI>();
    }
    private void FixedUpdate()
    {
        moneyUI.money = money;
        if (!Endpoint)
        {
            Debug.Log("GameOVer");
            
        }
    }
}
