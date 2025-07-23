using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class FPSGameManager : Singleton<FPSGameManager>
{
    public enum GameState {Ready,Run,GaveOver }
    public GameState gState;

    public GameObject gameLabel;
    private TextMeshProUGUI gameText;

    private FPSPlayerMove player;

    void Start()
    {
        gState = GameState.Ready;
        gameText = gameLabel.GetComponent<TextMeshProUGUI>();

        gameText.text = "Ready....";
        gameText.color = new Color32(255, 185, 0, 255);

        player = GameObject.Find("Player").GetComponent<FPSPlayerMove>();

        StartCoroutine(ReadyToStart());
    }

    private void Update()
    {
        if(player.hp <= 0)
        {
            player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);

            gameLabel.SetActive(true);
            gameText.text = "Game Over";
            gameText.color = new Color32(255, 0, 0, 255);

            gState = GameState.GaveOver;
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);
        gameText.text = "Go!";

        yield return new WaitForSeconds(0.5f);
        gameLabel.SetActive(false);
        gState = GameState.Run;

    }
}
