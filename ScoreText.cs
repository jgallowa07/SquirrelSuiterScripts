using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreText : MonoBehaviour {
    private int SquirrelSpeed;
    public Text score;
    public Text Acorns;
    public Text HighScore;
	public Text Boosts;
    public int LevelNum;
    public int ScoreNum;
    public int AcornNum, BoostNum;
    public float PrevHigh;
    public float startTime;
    public bool playerDead;

    private AcornScript AS;
    private string HighscoreOnLevel;
    
    void Start () {
        ScoreNum = 0;
        AcornNum = 0;
		BoostNum = 0;
        playerDead = false;
        Acorns.text = "Acorns: " + AcornNum.ToString();
        if (LevelNum == 1) {
            HighscoreOnLevel = "HighScore1";
        }
        else if(LevelNum == 2){
            HighscoreOnLevel = "HighScore2";
        }
        else if (LevelNum == 3) {
            HighscoreOnLevel = "HighScore3";
        }
        else if (LevelNum == 4) {
            HighscoreOnLevel = "HighScore4";
        }
        else if (LevelNum == 5) {
            HighscoreOnLevel = "HighScore5";
        }
        PrevHigh = PlayerPrefs.GetFloat(HighscoreOnLevel, 0);
        HighScore.text = "High Score: " + PrevHigh.ToString();  
    }

    void Update() {   
        if (Time.timeScale == 0 || playerDead) {
            return;
        }

        

        Acorns.text = "Acorns: " + AcornNum.ToString();
        score.text = "Score: " + ScoreNum.ToString();
		Boosts.text = "Boosts: " + BoostNum.ToString ();
        ScoreNum++;
        if (ScoreNum > PrevHigh) {
            PlayerPrefs.SetFloat(HighscoreOnLevel, ScoreNum);
        }
    }
    public void IncAcorns() {
        AcornNum++;
		ScoreNum += 1000;
    }

	public void IncBoosts(){
		BoostNum++;
	}

	public void DecBoosts(){
		BoostNum--;
	}

}
