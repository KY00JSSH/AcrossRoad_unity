using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour
{
    private Button button;

    //���ӽ��۽� �Ͻ����� ��ư �����
    //���������(�÷��̾� ����) �Ͻ����� ��ư ������� ���� ��ũ��Ʈ
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
