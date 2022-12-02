using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Button retryButton;
    public PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        retryButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0)
        {
            retryButton.gameObject.SetActive(true);
        }
    }
    
    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }
}
