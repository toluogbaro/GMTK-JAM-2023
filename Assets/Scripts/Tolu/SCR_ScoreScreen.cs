using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum ScoreType
{
    CIVILIANSKILLED,
    OBJECTSDESTORYED,
    DISTANCECOVERED,

}
public class SCR_ScoreScreen : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;

    public Vector3 startPos;

    public GameObject scoreBox;

    public GameObject[] scoreHolders;

    public TextMeshProUGUI totalScoreText;


    [Header("Score Variables")]

    public static int civiliansKilled = 6;

    public static int objectsDestroyed = 1;

    public static int distanceCovered = 9;

    public static int totalScore;

    public void Update()
    {
        totalScore = civiliansKilled + objectsDestroyed + distanceCovered;

        if(Input.GetKeyDown(KeyCode.Space)) StartCoroutine(CountScores());
    }


    public IEnumerator CountScores()
    {
        //scoreBox.SetActive(true);

        //gameObject.LeanMoveLocal(Vector3.zero, 1f).setEaseInOutCubic().setIgnoreTimeScale(true);

        //yield return new WaitForSecondsRealtime(2f);

        //gameObject.LeanScale(new Vector3(1, 1, 1), 1f).setEaseInOutCubic().setIgnoreTimeScale(true);

        yield return new WaitForSecondsRealtime(2f);

        for (int i = 0; i < scoreHolders.Length; i++)
        {
            SCR_Score newScore = scoreHolders[i].GetComponent<SCR_Score>();

            newScore.score.gameObject.SetActive(true);

            StartCoroutine(ScrambleScore(5f, newScore.ReturnScore(), newScore.score));

            yield return new WaitForSecondsRealtime(2f);
        }

        totalScoreText.gameObject.SetActive(true);

        StartCoroutine(ScrambleScore(5f, totalScore, totalScoreText));
    }

    public IEnumerator ScrambleScore(float delay, int score, TextMeshProUGUI textToScramble)
    {
        var scrambleFloat = 0f;


        for (float i = 0; i < delay; i += Time.unscaledDeltaTime)
        {
            scrambleFloat = Random.Range(0, 1000);
            textToScramble.text = scrambleFloat.ToString();
            yield return null;
        }

        for (float timer = 0; timer < 2f; timer += Time.unscaledDeltaTime)
        {
            float progress = timer / 2f;

            scrambleFloat = Mathf.Lerp(scrambleFloat, score, progress);

            textToScramble.text = Mathf.Round(scrambleFloat).ToString();

            yield return null;

        }
    }

}
