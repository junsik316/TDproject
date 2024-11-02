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
        int setWidth = 1920; // 사용자 설정 너비
        int setHeight = 1080; // 사용자 설정 높이

        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
    }
    public static void GameOver(int Wave)
    {
        ThisWave = Wave;
        if (ThisWave > MaxWave) MaxWave = ThisWave;
        LoadingSceneManager.LoadScene("EndScene");
    }
}
