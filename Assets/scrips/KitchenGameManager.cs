using System;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{

    public static KitchenGameManager Instace {  get; private set; }





    public event EventHandler OnsTateGamweChanged;



 private enum State
    {
        WaitingToStart,
        CountDownToStart,
        GmaPlaying,
        GameOver,
    }








    private State state;
    private float waitingToStartTimer = 1f;
    private float CountDownToStartTimer = 3f;
    private float GamePlayingTimer = 10f;







    private void Awake()
    {
        Instace = this;

        state = State.WaitingToStart;
    }








    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer += Time.deltaTime;
                if (waitingToStartTimer < 0f)
                {
                    state = State.CountDownToStart;
                    OnsTateGamweChanged?.Invoke(this, new EventArgs());
                }
                break;





            case State.CountDownToStart:
                waitingToStartTimer += Time.deltaTime;
                if (CountDownToStartTimer < 0f)
                {
                    state = State.GmaPlaying;
                    OnsTateGamweChanged?.Invoke(this, new EventArgs());
                }
                break;








            case State.GmaPlaying:
                waitingToStartTimer += Time.deltaTime;
                if (GamePlayingTimer < 0f)
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
        return state == State.GmaPlaying;
    }

    public bool IsCountDownToStartActive()
    {
        return state == State.CountDownToStart;
    }

    public float GetCountDownToStartTimer()
    {
        return CountDownToStartTimer;
    }
}
