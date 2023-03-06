using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool GameStart,GameLose,FinishPhase;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
        //Screen.SetResolution(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2, true);
    }
    void Start()
    {
    }
    public void GameLoseOP()
    {
        GameLose = true;
        UIManager.Instance.LosePanelActive();
    }
}
