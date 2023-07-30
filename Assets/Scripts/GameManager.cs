using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;
    [SerializeField] TextMeshProUGUI m_ObjectOponent;
    [SerializeField] TextMeshProUGUI m_OponentWin;
    [SerializeField] TextMeshProUGUI m_PlayerWin;

    [SerializeField] GameObject OponentWin;
    [SerializeField] GameObject PlayerWin;
    [SerializeField] GameObject Tie;

    [SerializeField] GameObject Food;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Oponent;
    [SerializeField] GameObject StartGameButton;

    [SerializeField] PlayerMovement playerSegment;
    [SerializeField] Oponents OponentSegment;

    int scorePlayer, scoreOponent;


    public void UpdateScorePlayer(int points)
    {
        scorePlayer = scorePlayer + points;
        m_Object.text = "SCORE: "+ scorePlayer;
    }

    public void UpdateScoreOponent(int points)
    {
        scoreOponent = scoreOponent + points;
        m_ObjectOponent.text = "SCORE: " + scoreOponent;
    }

    public void GameOver()
    {
        if(scoreOponent > scorePlayer)
        {
            m_OponentWin.text = "YOU WIN! SCORE: " + scoreOponent;
            m_OponentWin.alignment = TextAlignmentOptions.Center;
            OponentWin.SetActive(true);

        } else if(scoreOponent < scorePlayer)
        {
            m_PlayerWin.text = "YOU WIN! SCORE: " + scorePlayer;
            m_PlayerWin.alignment = TextAlignmentOptions.Center;
            PlayerWin.SetActive(true);
        }
        else
        {
            Tie.SetActive(true);
        }
    }

    public void StartGame()
    {
        scorePlayer = 0;
        scoreOponent = 0;

        m_Object.text = "SCORE: " + scorePlayer;
        m_ObjectOponent.text = "SCORE: " + scoreOponent;

        Food.SetActive(true);
        Player.SetActive(true);
        Oponent.SetActive(true);
        StartGameButton.SetActive(false);
        OponentWin.SetActive(false);
        PlayerWin.SetActive(false);
        Tie.SetActive(false);

    }

    public void ResetGame()
    {
        for (int i = 1; i < playerSegment._segments.Count; i++)
        {
            Destroy(playerSegment._segments[i].gameObject);
        }

        playerSegment._segments.Clear();
        playerSegment._segments.Add(Player.transform);
        Player.transform.position = Vector3.zero;

        for (int i = 1; i < OponentSegment._segments.Count; i++)
        {
            Destroy(OponentSegment._segments[i].gameObject);
        }

        OponentSegment._segments.Clear();
        OponentSegment._segments.Add(Oponent.transform);
        Oponent.transform.position = Vector3.zero;

        Food.SetActive(false);
        Player.SetActive(false);
        Oponent.SetActive(false);
        StartGameButton.SetActive(true);
    }


}
