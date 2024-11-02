using JetBrains.Annotations;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    AudioSource AudioSource;
    public GameObject Endpoint;
    public GameObject MoneyUI;
    MoneyUI moneyUI;
    private static GameManager _instance;
    public static int liveEnemy;
    Damagable Damagable;
    public static int money
        
    {
        get { return _money; }
        set {

            
            
             _money = value; 
        }
    }
    private static int _money = 50000;
    public static float moneyEarn=1f;
    public  static bool isEnfoceUIOn = false;
    public static int ThisWave;
    public static int MaxWave;
    public static bool isGameOver = false;
    
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
        money = 500;
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
        
    }
    void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetResolution();
        Damagable = Endpoint.GetComponent<Damagable>();
        money = 50000;
        isEnfoceUIOn = false;
    }


    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void SetResolution()
    {
        int setWidth = 1920; // ����� ���� �ʺ�
        int setHeight = 1080; // ����� ���� ����

        int deviceWidth = Screen.width; // ��� �ʺ� ����
        int deviceHeight = Screen.height; // ��� ���� ����

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution �Լ� ����� ����ϱ�

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // ����� �ػ� �� �� ū ���
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // ���ο� �ʺ�
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // ���ο� Rect ����
        }
        else // ������ �ػ� �� �� ū ���
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // ���ο� ����
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // ���ο� Rect ����
        }
    }
    public static void GameOver(int Wave)
    {
        ThisWave = Wave;
        if (ThisWave > MaxWave) MaxWave = ThisWave;
        LoadingSceneManager.LoadScene("EndScene");
    }
}
