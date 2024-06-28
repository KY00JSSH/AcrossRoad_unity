using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour
{
    private Button button;

    //���ӽ��۽� �Ͻ����� ��ư �����
    //���������(�÷��̾� ����) �Ͻ����� ��ư ������� ���� ��ũ��Ʈ

    public Image logoimage;
    public float fadeDuration = 2.0f;
    private float elapsedTime = 0f;

    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        button = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rect.localScale = Vector3.zero;
        button.onClick.AddListener(ToggleTime);
    }     

    // Update is called once per frame
    void Update()
    {
        GameStart_Button_appear();
    }

    private void ToggleTime()
    {
        GameManager.Instance.isTimePassing = !GameManager.Instance.isTimePassing;
    }

    public void GameStart_Button_appear()
    {        
        if (//Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)
            //|| Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)
            //|| Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)
            //|| Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)
         Input.GetKeyDown(KeyCode.Space)
         )
        {
            rect.localScale = Vector3.one;

            /*
            if (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;

                float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
                // Clamp01 -> ���İ�(����)�� 0�� 1 ������ ������ �����ϴ� ��, �ǵ�ġ �ʰ� 0�� 1 ���̸� ����� ���ϵ���.

                Color logoColor = logoimage.color;
                logoColor.a = alpha;
                logoimage.color = logoColor;
            }
            */
        }
    }

}
