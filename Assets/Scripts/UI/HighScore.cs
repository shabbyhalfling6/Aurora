using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class ScoreData {
	public string name;
	public float score;
	
	public ScoreData (ScoreData data){
		name = data.name;
		score = data.score;
	}
	public ScoreData (){
		name = "";
		score = 0;
	}
}

public class HighScore : MonoBehaviour 
{
	ScoreData currentData;
	public List<ScoreData> scores;
	List<float> scoreValues;
	
	public Text score1Text;
	public Text score2Text;
	public Text score3Text;
	public Text score4Text;
	public Text score5Text;
	public Text score6Text;
	public Text score7Text;
	public Text score8Text;
	public Text score9Text;
	public Text score10Text;
	
	public Text finalScoreText;
	
	void Start () {
		scores = new List<ScoreData> ();
		/*	for (int index = 0; index < 11; ++index) {
			currentData = new ScoreData ();
			currentData.score = Random.Range(0,100);
			scores.Add(currentData);
		}

		//SetScores ();*/
		RetrieveScores ();
		OrganiseScores ();
        SetScores();
	}
	
	void OnDestroy () {
		SetScores ();
		Debug.Log ("Destroyed");
	}
	
	public void ShowScores () {
		score1Text.text = "1- "+scores[0].name + " : " + scores[0].score.ToString();
		score2Text.text = "2- "+scores[1].name + " : " + scores[1].score.ToString();
		score3Text.text = "3- "+scores[2].name + " : " + scores[2].score.ToString();
		score4Text.text = "4- "+scores[3].name + " : " + scores[3].score.ToString();
		score5Text.text = "5- "+scores[4].name + " : " + scores[4].score.ToString();
		score6Text.text = "6- "+scores[5].name + " : " + scores[5].score.ToString();
		score7Text.text = "7- "+scores[6].name + " : " + scores[6].score.ToString();
		score8Text.text = "8- "+scores[7].name + " : " + scores[7].score.ToString();
		score9Text.text = "9- "+scores[8].name + ": " + scores[8].score.ToString();
		score10Text.text = "10- "+scores[9].name + " : " + scores[9].score.ToString();
	}
	
	public void OrganiseScores () {
		List<ScoreData> newScores = new List<ScoreData> ();
		scoreValues = new List<float> ();
		for (int index = 0; index < scores.Count; ++index) {
			scoreValues.Add(scores[index].score);
			Debug.Log (scores[index].score);
		}
		scoreValues.Sort ();
		for (int index = scoreValues.Count - 1; index >= 0; --index) {
			for (int newIndex = 0; newIndex < scores.Count; ++newIndex) {
				float scoreValuesValue = scoreValues[index];
				float scoresValue = scores[newIndex].score;
				if(scoreValuesValue == scoresValue){
					newScores.Add(new ScoreData(scores[newIndex]));
					scores[newIndex].score = -1;
					break;
				}
			}
		}
		scores = newScores;
		ShowScores ();
	}
	
	void Update () {
		ShowCurScore ();
	}
	
	public void ShowCurScore () {
		finalScoreText.text = "Final Score: " + currentData.score.ToString();
	}
	
	public void StoreData(){
		scores.Add (new ScoreData(currentData));
		Debug.Log ("Stored Data");
		OrganiseScores ();
		currentData.score = 0;
	}
	
	public void StoreName () {
		Debug.Log ("Stored Name");
		currentData.name = GetComponent<InputField>().text;
		StoreData ();
	}
	
	public void StoreScore (float score){
		currentData.score += score;
		ShowCurScore ();
		Debug.Log ("Stored Score");
	}
	
	public void ResetDataList () {
		scores = new List<ScoreData> ();
		for (int index = 0; index < 10; ++index) {
			currentData = new ScoreData();
			scores.Add(currentData);
		}
	}
	
	public void RetrieveScores () {
		ResetDataList ();
		scores[0].name = PlayerPrefs.GetString("Score_1S");
		scores[1].name = PlayerPrefs.GetString("Score_2S");
		scores[2].name = PlayerPrefs.GetString("Score_3S");
		scores[3].name = PlayerPrefs.GetString("Score_4S");
		scores[4].name = PlayerPrefs.GetString("Score_5S");
		scores[5].name = PlayerPrefs.GetString("Score_6S");
		scores[6].name = PlayerPrefs.GetString("Score_7S");
		scores[7].name = PlayerPrefs.GetString("Score_8S");
		scores[8].name = PlayerPrefs.GetString("Score_9S");
		scores[9].name = PlayerPrefs.GetString("Score_10S");
		
		scores[0].score = PlayerPrefs.GetFloat("Score_1F");
		scores[1].score = PlayerPrefs.GetFloat("Score_2F");
		scores[2].score = PlayerPrefs.GetFloat("Score_3F");
		scores[3].score = PlayerPrefs.GetFloat("Score_4F");
		scores[4].score = PlayerPrefs.GetFloat("Score_5F");
		scores[5].score = PlayerPrefs.GetFloat("Score_6F");
		scores[6].score = PlayerPrefs.GetFloat("Score_7F");
		scores[7].score = PlayerPrefs.GetFloat("Score_8F");
		scores[8].score = PlayerPrefs.GetFloat("Score_9F");
		scores[9].score = PlayerPrefs.GetFloat("Score_10F");
		
		ShowScores ();
	}
	
	public void SetScores () {
		PlayerPrefs.SetString("Score_1S", scores[0].name);
		PlayerPrefs.SetString("Score_2S", scores[1].name);
		PlayerPrefs.SetString("Score_3S", scores[2].name);
		PlayerPrefs.SetString("Score_4S", scores[3].name);
		PlayerPrefs.SetString("Score_5S", scores[4].name);
		PlayerPrefs.SetString("Score_6S", scores[5].name);
		PlayerPrefs.SetString("Score_7S", scores[6].name);
		PlayerPrefs.SetString("Score_8S", scores[7].name);
		PlayerPrefs.SetString("Score_9S", scores[8].name);
		PlayerPrefs.SetString("Score_10S", scores[9].name);
		
		PlayerPrefs.SetFloat("Score_1F", scores[0].score);
		PlayerPrefs.SetFloat("Score_2F", scores[1].score);
		PlayerPrefs.SetFloat("Score_3F", scores[2].score);
		PlayerPrefs.SetFloat("Score_4F", scores[3].score);
		PlayerPrefs.SetFloat("Score_5F", scores[4].score);
		PlayerPrefs.SetFloat("Score_6F", scores[5].score);
		PlayerPrefs.SetFloat("Score_7F", scores[6].score);
		PlayerPrefs.SetFloat("Score_8F", scores[7].score);
		PlayerPrefs.SetFloat("Score_9F", scores[8].score);
		PlayerPrefs.SetFloat("Score_10F", scores[9].score);
	}
	
	public void OnClick_RestartLeaderBoard()
	{
		Debug.Log("Restart LeaderBoard");
		PlayerPrefs.DeleteAll ();
		currentData = new ScoreData ();
		ResetDataList ();
		ShowScores ();
	}
}