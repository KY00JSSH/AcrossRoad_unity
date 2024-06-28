using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ���α׷� ���۰� ���ÿ� �ΰ� ��Ÿ����
// ������ ���۵Ǹ� �ΰ� ������ '����~' ���ư��鼭 �������

public class MainLogo_Appearance : MonoBehaviour
{
    public Image logoimage;
    public float fadeDuration = 2.0f;

    private float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            // Clamp01 -> ���İ��� 0�� 1 ������ ������ �����ϴ� ��, �ǵ�ġ �ʰ� 0�� 1 ���̸� ����� ���ϵ���.

            Color logoColor = logoimage.color;
            logoColor.a = alpha;
            logoimage.color = logoColor;
        }
    }

    void GameStart_logo_Disapper()
    {

    }

}
