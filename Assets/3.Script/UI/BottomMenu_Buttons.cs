using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���α׷� ���۰� ���ÿ� �ΰ� ��Ÿ����

public class BottomMenu_Buttons : MonoBehaviour
{    
    public RectTransform buttonRectTransform;
    public float slideDuration = 1.0f; //�̲����� �ö���µ� �ɸ��� �ð�
    public Vector2 buttonStartPosition; //��ư�� �ö���� �� ��ġ
    public Vector2 buttonEndPosition; //��ư�� �ö�� �� ��ġ

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

        CharaSelect_Button.onClick.AddListener(CharacterSelect); // �ڽ� ������Ʈ�� ��ư 3���� ��ư�� ������ ���� ��� �Ҵ�
        HowToPlay_Button.onClick.AddListener(HowToPlay);         // �ڽ� ������Ʈ�� ��ư 3���� ��ư�� ������ ���� ��� �Ҵ�
        Ranking_Button.onClick.AddListener(Ranking);             // �ڽ� ������Ʈ�� ��ư 3���� ��ư�� ������ ���� ��� �Ҵ�

        characterSelectButtons = FindObjectOfType<CharacterSelect_buttons>();
        howToPlayButtons = FindObjectOfType<HowToPlay>();
    }

    // Start is called before the first frame update
    private void Start()
    {       
        canvasRectTransform.localScale = Vector3.one;
        
        float bottomButtonHeight = buttonRectTransform.rect.height;
        
        buttonStartPosition = new Vector2(0, bottomButtonHeight * -5); //Y��ǥ = Bottom_Buttons�� ���� * n ���� �ö��

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
