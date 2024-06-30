using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour
{
    //게임시작시 일시정지 버튼 등장과
    //게임종료시(플레이어 죽음) 일시정지 버튼 사라짐을 위한 스크립트

    private Button button;

    public Image logoimage;
    public float fadeDuration = 2.0f;
    private float elapsedTime = 0f;

    RectTransform rect;

    bool isGameOver = true;

    public GameObject mainLogo;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        button = GetComponent<Button>();
        mainLogo = FindObjectOfType<MainLogo_Appearance>().gameObject;
    }

    // Start is called before the first frame update
    private void Start()
    {
        rect.localScale = Vector3.zero;
        button.onClick.AddListener(ToggleTime);        
    }

    // Update is called once per frame
    private void Update()
    {
        GameStart_Button_appear();        
    }

    private void ToggleTime()
    {
        if(GameManager.Instance != null)
        { 
            GameManager.Instance.isTimePassing = !GameManager.Instance.isTimePassing;
        }
        else
        {
            Debug.LogError("GameManager 인스턴스가 없습니다.");
        }
    }

    public void GameStart_Button_appear() {
        if (!mainLogo.activeSelf) {
            isGameOver = false;
            rect.localScale = Vector3.one;
        }
    }

    public void Character_Die_Button_Disappear() //게임오버되면 버튼 사라지게
    {
        isGameOver = true;
        Time.timeScale = 0;
        rect.localScale = Vector3.zero;        
    }
}
