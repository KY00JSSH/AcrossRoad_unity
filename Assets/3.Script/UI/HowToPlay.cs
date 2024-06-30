using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    public RectTransform imageRectTransform;

    private BottomMenu_Buttons bottomMenuButtons;
    public Button Back_Button;

    public PlayerMovement playerMovement; // HowToPlay�� ��Ÿ���� �� ĳ���Ͱ� �������̰� �ϱ� ����
           
    private void Awake()
    {
        Back_Button.onClick.AddListener(Back); //���ư��� ��ư ����

        bottomMenuButtons = FindObjectOfType<BottomMenu_Buttons>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Start()
    {
        HowToPlay_Disappear(); // �⺻������ �Ⱥ��̰�, UI ��ư Ŭ���ϸ� ��Ÿ������
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void HowToPlay_Appear()
    {
        imageRectTransform.localScale = Vector3.one;
        playerMovement.SetMovementEnabled(false); // HowToPlay�� ��Ÿ���� �� ĳ���Ͱ� �������̰� �ϱ� ����
    }

    public void HowToPlay_Disappear()
    {
        imageRectTransform.localScale = Vector3.zero;
        playerMovement.SetMovementEnabled(true); // HowToPlay�� ������� ĳ���Ͱ� �����̰� �ϱ� ����
    }

    private void Back() //�ڷΰ��� ��ư�� ������ �� �ϴ� �޴� ��ư���� ���ư���
    {
        HowToPlay_Disappear();
        bottomMenuButtons.Button_Appear();
    }
}
