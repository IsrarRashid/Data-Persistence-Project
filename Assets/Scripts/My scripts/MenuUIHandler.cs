using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI inputFieldText;
    public int bestScore;
    public GameObject warningMessage;
    public TextMeshProUGUI scoreBoard;
    private void Start()
    {
        Debug.Log("start" + PlayerRecord.Instance.finalScore.ToString());
        bestScore = PlayerRecord.Instance.finalScore;
        PlayerRecord.Instance.LoadRecord();
        scoreBoard.text = string.Format("Best Score : {0} : {1}", PlayerRecord.Instance.finalName, PlayerRecord.Instance.finalScore);

    }

    public void StartNew()
    {

        if (inputFieldText.text.Length > 1)
        {
            Debug.Log(inputFieldText.text);
            PlayerRecord.Instance.temporaryName = inputFieldText.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            StartCoroutine(DisplayMessage());
        }
    }

    IEnumerator DisplayMessage()
    {
        warningMessage.SetActive(true);
        yield return new WaitForSeconds(1f);
        warningMessage.SetActive(false);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
