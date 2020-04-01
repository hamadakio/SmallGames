using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Pong
{
    public enum States
    {
        Menu,
        Start,
        GamePlay,
        GameOver,
        Pause,
        Reset
    }

    public enum Sides
    {
        Up,
        Down,
        Left,
        Right
    }



    public class GameManagerPong : MonoBehaviour
    {
        public static GameManagerPong Instance { get; private set; }
        public States state;
        public int ScoreP1, ScoreP2;
        public float Tempo;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            state = States.Menu;
            Tempo = 3;
            Application.targetFrameRate = 60;
        }


        private void Update()
        {
            GameLoop(state);
        }

        public void GameLoop(States states)
        {
            switch (states)
            {
                case States.GamePlay:

                    break;
                case States.GameOver:

                    break;
                case States.Pause:

                    break;
                case States.Reset:

                    break;
                case States.Menu:

                    break;
                case States.Start:
                    Contador();
                    break;
                default:
                    break;
            }
        }

        public void Contador()
        {           
            if (Tempo >= 0)
            {
                Tempo -= Time.deltaTime * 1;
            }
            else if (Tempo <= 0 && state == States.Start)
            {
                Tempo = 3;
            }
            else if (Tempo <= 0 && state == States.GameOver)
            {
                Tempo = 1f;
            }


            if (state == States.GameOver)
            {
                state = Tempo > 0 ? States.GameOver : States.GamePlay;
            }
            else if (state == States.Start)
            {
                state = Tempo > 0 ? States.Start : States.GamePlay;
            }
                     
        }

        public void SetState(int _state)
        {
            state = (States)_state;
        }

    }

}

