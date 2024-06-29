using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect_buttons : MonoBehaviour
{
    public RectTransform buttonRectTransform;
    
    Canvas canvas; 
    RectTransform canvasRectTransform;
    
    public Button CharaSelect_Chicken, CharaSelect_Cat, CharaSelect_Dog, Back_Button;

    private BottomMenu_Buttons bottomMenuButtons;

    public GameObject[] characters; //캐릭터 선택창 제작을 위한 배열 생성

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            canvasRectTransform = canvas.GetComponent<RectTransform>();
        }       

        CharaSelect_Chicken.onClick.AddListener(() => SelectCharacter(0)); //캐릭터 선택창을 위한 로직
        CharaSelect_Cat.onClick.AddListener(() => SelectCharacter(1));     //캐릭터 선택창을 위한 로직
        CharaSelect_Dog.onClick.AddListener(() => SelectCharacter(2));     //캐릭터 선택창을 위한 로직
        Back_Button.onClick.AddListener(Back); //돌아가기 버튼 로직

        bottomMenuButtons = FindObjectOfType<BottomMenu_Buttons>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CharacterSelect_Button_Disappear();
    }

    private void Update()
    {
        Button_Disapper();
    }

    public void CharacterSelect_Button_Appear()
    {
        buttonRectTransform.localScale = Vector3.one;
    }

    public void CharacterSelect_Button_Disappear()
    {
        buttonRectTransform.localScale = Vector3.zero;
    }

    private void Button_Disapper() //캐릭터 선택창에서 캐릭터 선택 후 움직이면, 캐릭터 선택창 사라지게(겜 시작으로 간주)
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)
            || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)
            || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            CharacterSelect_Button_Disappear();
        }
    }

    private void Back() //뒤로가기 버튼을 눌렀을 때 하단 메뉴 버튼으로 돌아가게
    {
        CharacterSelect_Button_Disappear();
        bottomMenuButtons.Button_Appear();
    }

    private void SelectCharacter(int index)
    {
        for(int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }

        characters[index].SetActive(true);
    }

    //private void SelectChicken()
    //{
    //    // 캐릭터 선택 로직 추가
    //}
    //private void SelectCat()
    //{
    //    // 캐릭터 선택 로직 추가
    //}
    //private void SelectDog()
    //{
    //    // 캐릭터 선택 로직 추가
    //}

}
