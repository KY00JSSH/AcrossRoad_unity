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
    public float elapsedTime = 0f;
         
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProgramStart_logo_Appear();
        GameStart_logo_Disapper();
    }
       
    void ProgramStart_logo_Appear()
    {      
         if (elapsedTime < fadeDuration)
         {
              elapsedTime += Time.deltaTime;
              
              float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
              // Clamp01 -> ���İ�(����)�� 0�� 1 ������ ������ �����ϴ� ��, �ǵ�ġ �ʰ� 0�� 1 ���̸� ����� ���ϵ���.
              
              Color logoColor = logoimage.color;
              logoColor.a = alpha;
              logoimage.color = logoColor;
         }       
    }

    private void GameStart_logo_Disapper()
    {       
         if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)
         || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)
         || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)
         || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))       
         {
            gameObject.SetActive(false);

            // �÷��̾� ���Ҵ�
            Score score = FindObjectOfType<Score>();
            score.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

            PlayerCamera playerCamera = FindObjectOfType<PlayerCamera>();
            playerCamera.SetFollow();

            RocksSpawner rockSpawner = FindObjectOfType<RocksSpawner>();
            rockSpawner.setPlayerControl();
            rockSpawner.setPlayerObject();

            HorizObsSpawner horizSpawner = FindObjectOfType<HorizObsSpawner>();
            horizSpawner.setPlayerControl();
            horizSpawner.setPlayerObject();

            MapControl mapControl = FindObjectOfType<MapControl>();
            mapControl.setPlayerTransform();

            Restart_Button restartButton = FindObjectOfType<Restart_Button>();
            restartButton.setPlayerControl();
            //rect.localScale = Vector3.zero;     
         }
    }
}
