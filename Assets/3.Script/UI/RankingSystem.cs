using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI; /**/
using UnityEngine.SocialPlatforms.Impl;

[Serializable]
public class Rank {
    public string name;
    public string time;
    public int score;
}

public class RankData {
    public List<Rank> rankData;
}

public class RankingSystem : MonoBehaviour {
    string path;
    public RankData jsonRankData;
    private GameObject player;

    public GameObject rankingItemPrefab; /**/
    public Transform rankingsContainer; /**/

    public RectTransform rankingsystemRectTransform;
    private BottomMenu_Buttons bottomMenuButtons;
    public Button Back_Button;
    public PlayerMovement playerMovement; // RankingSystem�� ��Ÿ���� �� ĳ���Ͱ� �������̰� �ϱ� ����

    public PlayerControll playerControll;


    private void Awake() {
        setPlayer();
        path = Path.Combine(Application.persistentDataPath, "ranking.json");
        jsonRankData = new RankData();

        bottomMenuButtons = FindObjectOfType<BottomMenu_Buttons>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        Back_Button.onClick.AddListener(Back); //���ư��� ��ư ����

        playerControll = FindObjectOfType<PlayerControll>();
    }

    public void setPlayer() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start() /**/
    {
        LoadRanking();
        DisplayRanking();

        
        RankingSystem_Disappear();
    }

    private void Update() 
    {
        rankingsystemRectTransform.anchoredPosition = Vector2.zero; // ������Ʈ�� �ȿ����̰�   
        if(Input.GetKeyDown(KeyCode.F))
        {
            ClearRanking();
        }
    }

    public void ClearRanking() {
        if(File.Exists(path)) {
            File.Delete(path);
        }
    }

    public void SaveRanking () {
        //List<Rank> rankData = LoadRanking();
        List<Rank> rankData = LoadRanking() ?? new List<Rank>(); /**/

        Rank rank = new Rank();
        rank.name = player.name;        
        rank.time = DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss"));
        rank.score = player.GetComponent<PlayerMovement>().score;       
        rankData.Add(rank);

        jsonRankData.rankData = rankData;
        string jsonString = JsonUtility.ToJson(jsonRankData);
        File.WriteAllText(path, jsonString);
    }

    public List<Rank> LoadRanking() {
        //RankData jsonRankData = new RankData(); /**/
        if (File.Exists(path)) {
            string jsonString = File.ReadAllText(path);
            jsonRankData = JsonUtility.FromJson<RankData>(jsonString);
            return jsonRankData.rankData;
        }
        //return null;
        return new List<Rank>(); /**/
        //return jsonRankData.rankData; 
    }

    private void DisplayRanking() /**/
    {
        foreach(Transform child in rankingsContainer)
        {
            Destroy(child.gameObject);
        }

        List<Rank> rankData = LoadRanking();
        foreach(Rank rank in rankData)
        {
            GameObject newRankingItem = Instantiate(rankingItemPrefab, rankingsContainer);
            Text[] texts = newRankingItem.GetComponentsInChildren<Text>();
            texts[0].text = rank.name;
            texts[1].text = rank.score.ToString();
            texts[2].text = rank.time;
        }
    }

    public void RankingSystem_Appear()
    {        
        
        rankingsystemRectTransform.localScale = Vector3.one;
        playerMovement.SetMovementEnabled(false); // RankingSystem�� ��Ÿ���� �� ĳ���Ͱ� �������̰� �ϱ� ����
    }
    public void RankingSystem_Disappear()
    {
        rankingsystemRectTransform.localScale = Vector3.zero;
        playerMovement.SetMovementEnabled(true); // RankingSystem�� ������� ĳ���Ͱ� �����̰� �ϱ� ����
    }
    private void Back() //�ڷΰ��� ��ư�� ������ �� �ϴ� �޴� ��ư���� ���ư���
    {
        RankingSystem_Disappear();
        bottomMenuButtons.Button_Appear();
    }
}
