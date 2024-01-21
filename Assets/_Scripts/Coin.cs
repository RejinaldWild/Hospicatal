using System;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private TextMeshProUGUI _score;
    private int _currentScore = 0;
    private string _maxScore = "\\9";
    private GameObject _scoreCounter;    

    void Start()
    {
        _scoreCounter = GameObject.Find("ScoreText");
        _score = _scoreCounter.GetComponent<TextMeshProUGUI>();
        _score.text = _currentScore.ToString() + _maxScore;        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("TakeHeart");
        }

        string[] scores = _score.text.Split('\\');
        int currentScore = Int32.Parse(scores[0]);
        currentScore++;
        _score.text = currentScore.ToString() + _maxScore;        
    }
}
