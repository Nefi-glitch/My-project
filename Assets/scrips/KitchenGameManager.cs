using System;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{

    public static KitchenGameManager Instace {  get; private set; }





    public event EventHandler OnsTateGamweChanged;
    public event EventHandler OnGamePause;
    public event EventHandler OnGameUnPause;





    private enum State
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver,
    }








    private State state;
    private float countDownToStartTimer = 3f;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 30f;
    private bool isGamePaused = false;






    private void Awake()
    {
        Instace = this;

        state = State.WaitingToStart;
    }



    public void Start()
    {
        GameInput.Instance.OnPauseAtion += GameInput_OnPauseAtion;
        GameInput.Instance.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        if (state == State.WaitingToStart)
        {
            state = State.CountDownToStart;
            OnsTateGamweChanged ?.Invoke(this, EventArgs.Empty);
        }
    }

    private void GameInput_OnPauseAtion(object sender, EventArgs e)
    {
        TogglePauseGame();
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                break;





            case State.CountDownToStart:
                countDownToStartTimer += Time.deltaTime;
                if (countDownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                    gamePlayingTimer = gamePlayingTimerMax;
                    OnsTateGamweChanged?.Invoke(this, new EventArgs());
                }
                break;








            case State.GamePlaying:
                gamePlayingTimer+= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                    OnsTateGamweChanged?.Invoke(this, new EventArgs());
                }
                break;


                case State.GameOver:
                break;
        }
    }



    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public bool IsCountDownToStartActive()
    {
        return state == State.CountDownToStart;
    }

    public float GetCountDownToStartTimer()
    {
        return countDownToStartTimer;
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }

    public float GetGamePlayingTimerNormalized()
    {
        return 1 - ( gamePlayingTimer / gamePlayingTimerMax);
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f;
            OnGamePause?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnGameUnPause?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 1f;
        }
    }
}
