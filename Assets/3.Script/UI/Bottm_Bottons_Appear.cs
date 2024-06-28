using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���α׷� ���۰� ���ÿ� �ΰ��� ��Ÿ����

public class Bottm_Bottons_Appear : MonoBehaviour
{    
    public RectTransform buttonRectTransform;
    public float slideDuration = 2.0f; //�̲����� �ö���µ� �ɸ��� �ð�
    public Vector2 buttonStartPosition; //��ư�� �ö���� �� ��ġ
    public Vector2 buttonEndPosition; //��ư�� �ö�� �� ��ġ

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
    }
}