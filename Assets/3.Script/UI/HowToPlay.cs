using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    public RectTransform imageRectTransform;

    private BottomMenu_Buttons bottomMenuButtons;
    public Button Back_Button;

    public PlayerMovement playerMovement; // HowToPlay가 나타났을 때 캐릭터가 못움직이게 하기 위함

    // Start is called before the first frame update
    private void Start()
    {
        HowToPlay_Disappear();
    }

    private void Awake()
    {
        Back_Button.onClick.AddListener(Back); //돌아가기 버튼 로직
        bottomMenuButtons = FindObjectOfType<BottomMenu_Buttons>();

        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void HowToPlay_Appear()
    {
        imageRectTransform.localScale = Vector3.one;
        playerMovement.StopAllCoroutines(); // HowToPlay가 나타났을 때 캐릭터가 못움직이게 하기 위함
    }

    public void HowToPlay_Disappear()
    {
        imageRectTransform.localScale = Vector3.zero;
    }

    private void Back() //뒤로가기 버튼을 눌렀을 때 하단 메뉴 버튼으로 돌아가게
    {
        HowToPlay_Disappear();
        bottomMenuButtons.Button_Appear();
    }
}
