using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 프로그램 시작과 동시에 로고가 나타나게

public class BottomMenu_Buttons : MonoBehaviour
{    
    public RectTransform buttonRectTransform;
    public float slideDuration = 1.0f; //미끄러져 올라오는데 걸리는 시간
    public Vector2 buttonStartPosition; //버튼이 올라오기 전 위치
    public Vector2 buttonEndPosition; //버튼이 올라온 후 위치

    Canvas canvas; // = FindObjectOfType<Canvas>();   
    RectTransform canvasRectTransform;

    private float elapsedTime = 0f;

    public Button CharaSelect_Button, HowToPlay_Button, Ranking_Button;

    public CharacterSelect_buttons characterSelectButtons;
    public HowToPlay howToPlayButtons;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        if(canvas != null)
        {
            canvasRectTransform = canvas.GetComponent<RectTransform>();
        }

        CharaSelect_Button.onClick.AddListener(CharacterSelect); // 자식 오브젝트인 버튼 3개에 버튼을 눌렀을 때의 기능 할당
        HowToPlay_Button.onClick.AddListener(HowToPlay);         // 자식 오브젝트인 버튼 3개에 버튼을 눌렀을 때의 기능 할당
        Ranking_Button.onClick.AddListener(Ranking);             // 자식 오브젝트인 버튼 3개에 버튼을 눌렀을 때의 기능 할당

        characterSelectButtons = FindObjectOfType<CharacterSelect_buttons>();
        howToPlayButtons = FindObjectOfType<HowToPlay>();
    }

    // Start is called before the first frame update
    private void Start()
    {       
        canvasRectTransform.localScale = Vector3.one;
        
        float bottomButtonHeight = buttonRectTransform.rect.height;
        
        buttonStartPosition = new Vector2(0, bottomButtonHeight * -5); //Y좌표 = Bottom_Buttons의 높이 * n 에서 올라옴

        buttonRectTransform.anchoredPosition = buttonStartPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        buttonEndPosition = new Vector2(0, -295);

        if(elapsedTime < slideDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / slideDuration);
            buttonRectTransform.anchoredPosition = Vector2.Lerp(buttonStartPosition, buttonEndPosition, t);
        }

        MenuButton_Disapper();
    }

    public void Button_Disappear()
    {
        buttonRectTransform.localScale = Vector3.zero;
    }

    public void Button_Appear()
    {
        buttonRectTransform.localScale = Vector3.one;
    }

    private void MenuButton_Disapper()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)
            || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)
            || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))       
        {           
            Button_Disappear();
        }
    }   

    private void CharacterSelect()
    {
        Button_Disappear();
        characterSelectButtons.CharacterSelect_Button_Appear();
    }    
    private void HowToPlay()
    {
        Button_Disappear();
        howToPlayButtons.HowToPlay_Appear();
    }
    private void Ranking()
    {
        Button_Disappear();
    }
}
