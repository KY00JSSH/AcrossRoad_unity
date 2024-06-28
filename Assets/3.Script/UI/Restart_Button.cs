using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Button : MonoBehaviour
{
    RectTransform rect;

    GameManager gm;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        FindObjectOfType<GameManager>().TryGetComponent(out gm);
    }

    // Start is called before the first frame update
    void Start()
    {
        rect.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isGameover)
        {
            Character_Die_Button_Appear();
            Debug.Log("WOW");
        }
    }

    public void Character_Die_Button_Appear() //게임오버되면 버튼 나타나게
    {
            rect.localScale = Vector3.one;        
    }

    public void BackTo_MainScene()
    {
        SceneManager.LoadScene(""); //"" <- 안에 메인 게임씬 이름 넣기
    }
}
