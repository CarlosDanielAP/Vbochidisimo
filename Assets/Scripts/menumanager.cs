using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;

public class menumanager : MonoBehaviour
{
    bool conexion;
public Text score;

private void Start() {
    
 //cada que inicie colocamos el score mas alto del jugador  
   score.text= "best score: "+PlayerPrefs.GetInt("best").ToString();
}

public void irjuego()
    {
        SceneManager.LoadScene("salto");

    }

 public void ShowLeaderboards()
    {
#if UNITY_ANDROID
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            Debug.Log("Cannot show leaderboard: not authenticated");
        }
#endif
    }


}
