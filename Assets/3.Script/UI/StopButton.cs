using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour
{
    private Button button;

    //게임시작시 일시정지 버튼 등장과
    //게임종료시(플레이어 죽음) 일시정지 버튼 사라짐을 위한 스크립트
    /*
    public RectTransform buttonRectTransform;
    public float slideDuration = 2.0f;
    public Vector2 buttonStartPosition;
    public Vector2 buttonEndPosition;

    private float elapsedTime = 0f;
    */

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ToggleTime);
    }

    private void ToggleTime()
    {
        GameManager.Instance.isTimePassing = !GameManager.Instance.isTimePassing;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {

    }
}
