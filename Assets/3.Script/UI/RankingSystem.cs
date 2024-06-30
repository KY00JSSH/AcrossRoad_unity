using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
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

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        path = Path.Combine(Application.persistentDataPath, "ranking.json");
        jsonRankData = new RankData();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.O)) {
            SaveRanking();
        }
        else if(Input.GetKeyDown(KeyCode.L)) {
            LoadRanking();
        }
    }

    public void SaveRanking () {
        List<Rank> rankData = new List<Rank> ();

        Rank rank = new Rank();
        rank.name = player.name;
        rank.time = DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss"));
        rank.score = player.GetComponent<PlayerMovement>().score;
        rankData.Add(rank);

        jsonRankData.rankData = rankData;
        string jsonString = JsonUtility.ToJson(jsonRankData);
        File.WriteAllText(path, jsonString);
    }

    public void LoadRanking() {
        RankData jsonRankData = new RankData();
        if (File.Exists(path)) {
            string jsonString = File.ReadAllText(path);
            jsonRankData = JsonUtility.FromJson<RankData>(jsonString);

        }
    }
}