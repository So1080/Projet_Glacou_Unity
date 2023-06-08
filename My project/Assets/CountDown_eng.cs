using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDown_eng : MonoBehaviour
{
    [SerializeField] Image TimeImage;
    [SerializeField] Text TimeText;

    [SerializeField] float duration, currentTime;

    void Start()
    {
        currentTime = duration;
        TimeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0)
        {
            TimeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            TimeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        GameOver();
    }

    void GameOver()
    {
        TimeText.text = "";
        SceneManager.LoadScene("GameOver_eng");
    }

}
