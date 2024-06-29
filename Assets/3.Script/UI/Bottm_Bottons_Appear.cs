using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���α׷� ���۰� ���ÿ� �ΰ� ��Ÿ����

public class Bottm_Bottons_Appear : MonoBehaviour
{    
    public RectTransform buttonRectTransform;
    public float slideDuration = 2.0f; //�̲����� �ö���µ� �ɸ��� �ð�
    public Vector2 buttonStartPosition; //��ư�� �ö���� �� ��ġ
    public Vector2 buttonEndPosition; //��ư�� �ö�� �� ��ġ

    Canvas canvas; // = FindObjectOfType<Canvas>();   
    RectTransform canvasRectTransform;

    private float elapsedTime = 0f;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        if(canvas != null)
        {
            canvasRectTransform = canvas.GetComponent<RectTransform>();
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        //RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
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

        GameStart_Button_Disapper();
    }

    private void GameStart_Button_Disapper()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)
            || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)
            || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);

            //rect.localScale = Vector3.zero;

            //Color logoColor = logoimage.color;
            //logoColor.a = 0;
            //logoimage.color = logoColor;             
        }
    }
}
