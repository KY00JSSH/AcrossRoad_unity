using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour
{
    private Button button;

    //게임시작시 일시정지 버튼 등장과
    //게임종료시(플레이어 죽음) 일시정지 버튼 사라짐을 위한 스크립트

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
                // Clamp01 -> 알파값(투명도)을 0와 1 사이의 범위로 제한하는 것, 의도치 않게 0과 1 사이를 벗어나지 못하도록.

                Color logoColor = logoimage.color;
                logoColor.a = alpha;
                logoimage.color = logoColor;
            }
            */
        }
    }

}
