using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public void CloseGame()
    {
        SceneManager.LoadScene("Choix_miniJeu");
    }

    public void CloseGame_eng()
    {
        SceneManager.LoadScene("Choix_miniJeu_eng");
    }

    public void CloseGame_esp()
    {
        SceneManager.LoadScene("Choix_miniJeu_esp");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Jeu");
    }

    public void PlayGame_eng()
    {
        SceneManager.LoadScene("Jeu_eng");
    }

    public void Choix_miniJeu()
    {
        SceneManager.LoadScene("Choix_miniJeu");
    }

    public void Choix_miniJeu_eng()
    {
        SceneManager.LoadScene("Choix_miniJeu_eng");
    }


    public void PlayGame_esp()
    {
        SceneManager.LoadScene("Jeu_esp");
    }

    public void Choix_miniJeu_esp()
    {
        SceneManager.LoadScene("Choix_miniJeu_esp");
    }


}
