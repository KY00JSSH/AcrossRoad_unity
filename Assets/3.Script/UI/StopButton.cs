using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour
{
    private Button button;

    //게임시작시 일시정지 버튼 등장과
    //게임종료시(플레이어 죽음) 일시정지 버튼 사라짐을 위한 스크립트

    public Image logoimage;
    public float fadeDuration = 2.0f;
    private float elapsedTime = 0f;

    RectTransform rect;

    bool isGameOver = true;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        button = GetComponent<Button>();
        isGameOver = GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rect.localScale = Vector3.zero;
        button.onClick.AddListener(ToggleTime);
    }     

    // Update is called once per frame
    void Update()
    {
        GameStart_Button_appear();
        ToggleTime();
    }

    public void ToggleTime()
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

    public void GameStart_Button_appear()
    {        
        if (//Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)
            //|| Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)
            //|| Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)
            //|| Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)
         Input.GetKeyDown(KeyCode.Space)
         )
        {
            rect.localScale = Vector3.one;

            /*
            if (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;

                float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
                // Clamp01 -> 알파값(투명도)을 0와 1 사이의 범위로 제한하는 것, 의도치 않게 0과 1 사이를 벗어나지 못하도록.

                Color logoColor = logoimage.color;
                logoColor.a = alpha;
                logoimage.color = logoColor;
            }
            */
        }
    }

    public void Character_Die_Logo_Disappear() //게임오버되면 버튼 사라지게
    {
        if(isGameOver)
        {
            gameObject.SetActive(false);
        }
    }
}
