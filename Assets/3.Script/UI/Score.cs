using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public PlayerMovement player;

    [Header("# InGame")]
    [SerializeField]
    private Text textScore;

    private void Update() {
        if (player != null)
            textScore.text = $"Score {player.score}";
    }

}
