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

    public GameObject[] characters; //ĳ���� ����â ������ ���� �迭 ����

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            canvasRectTransform = canvas.GetComponent<RectTransform>();
        }       

        CharaSelect_Chicken.onClick.AddListener(() => SelectCharacter(0)); //ĳ���� ����â�� ���� ����
        CharaSelect_Cat.onClick.AddListener(() => SelectCharacter(1));     //ĳ���� ����â�� ���� ����
        CharaSelect_Dog.onClick.AddListener(() => SelectCharacter(2));     //ĳ���� ����â�� ���� ����
        Back_Button.onClick.AddListener(Back); //���ư��� ��ư ����

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

    private void Button_Disapper() //ĳ���� ����â���� ĳ���� ���� �� �����̸�, ĳ���� ����â �������(�� �������� ����)
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)
            || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)
            || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            CharacterSelect_Button_Disappear();
        }
    }

    private void Back() //�ڷΰ��� ��ư�� ������ �� �ϴ� �޴� ��ư���� ���ư���
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
    //    // ĳ���� ���� ���� �߰�
    //}
    //private void SelectCat()
    //{
    //    // ĳ���� ���� ���� �߰�
    //}
    //private void SelectDog()
    //{
    //    // ĳ���� ���� ���� �߰�
    //}

}
