using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 프로그램 시작과 동시에 로고가 나타나게

public class Bottm_Bottons_Appear : MonoBehaviour
{    
    public RectTransform buttonRectTransform;
    public float slideDuration = 2.0f; //미끄러져 올라오는데 걸리는 시간
    public Vector2 buttonStartPosition; //버튼이 올라오기 전 위치
    public Vector2 buttonEndPosition; //버튼이 올라온 후 위치

    private float elapsedTime = 0f; 

    // Start is called before the first frame update
    private void Start()
    {
        float bottomButtonHeight = buttonRectTransform.rect.height;

        buttonStartPosition = new Vector2(0, bottomButtonHeight * -2);

        buttonRectTransform.anchoredPosition = buttonStartPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        buttonEndPosition = new Vector2(0, 0);

        if(elapsedTime < slideDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / slideDuration);
            buttonRectTransform.anchoredPosition = Vector2.Lerp(buttonStartPosition, buttonEndPosition, t);
        }

        GameStart_Button_Disapper();
    }

    private void GameStart_Button_Disapper()
    {
        if (//Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)
            //|| Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)
            //|| Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)
            //|| Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)
        Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);

            //rect.localScale = Vector3.zero;

            //Color logoColor = logoimage.color;
            //logoColor.a = 0;
            //logoimage.color = logoColor;             
        }
    }
}
