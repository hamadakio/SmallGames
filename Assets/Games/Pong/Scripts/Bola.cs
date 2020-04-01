using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Pong
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bola : MonoBehaviour
    {
        public float XDirection, YDirection;
        private Vector3 StartPosition;
        private new Rigidbody rigidbody;
        private TrailRenderer trailRenderer;

        [Range(1,5)]
        public float _Speed;

        private void Awake()
        {
            _Speed = 5f;
            rigidbody = GetComponent<Rigidbody>();
            trailRenderer = GetComponent<TrailRenderer>();
            StartPosition = transform.position;
        }

        private void Update()
        {
            MoveBall(GameManagerPong.Instance.state);
        }

        public void MoveBall(States states)
        {
            switch (states)
            {
                case States.Menu:
                    ResetBall();
                    break;
                case States.GamePlay:
                    RigidbodyVelocity(new Vector3(XDirection, YDirection, 0));
                    trailRenderer.time = 0.2f;
                    break;
                case States.GameOver:
                    ResetBall();
                    GameManagerPong.Instance.Contador();
                    break;
                case States.Pause:
                    ZeroSpeed();
                    break;
                case States.Reset:
                    ResetBall();
                    break;
                case States.Start:


                    RandomDirection();

                    break;
                default:
                    break;
            }
        }

        private void ResetBall()
        {
            ZeroSpeed();
            transform.position = StartPosition;
        }

        private void ZeroSpeed()
        {
            RigidbodyVelocity(Vector3.zero);
        }

        private void RigidbodyVelocity(Vector3 vector3)
        {
            rigidbody.velocity = vector3;
        }

        private void RandomDirection()
        {
            XDirection = Random.Range(-Speed(), Speed()) == 0 ? Speed() : -Speed();
            YDirection = Random.Range(-Speed(), Speed()) == 0 ? Speed() : -Speed();
        }

        private void Direction(Sides sides)
        {
            switch (sides)
            {
                case Sides.Up:
                    YDirection = Speed();
                    break;
                case Sides.Down:
                    YDirection = -Speed();
                    break;
                case Sides.Left:
                    XDirection = -Speed();
                    break;
                case Sides.Right:
                    XDirection = Speed();
                    break;
                default:
                    break;
            }
        }

        private float Speed()
        {
            return _Speed;
        }

        public void GameOverPong(int player)
        {
            if (player == 1)
            {
                GameManagerPong.Instance.ScoreP1++;
            }
            else if (player == 2)
            {
                GameManagerPong.Instance.ScoreP2++;
            }

            trailRenderer.time = 0f;
            GameManagerPong.Instance.state = States.GameOver;
            Reverse();
        }

        public void Reverse()
        {
            YDirection *= -1;
            XDirection *= -1;
        }

        private void OnCollisionEnter(Collision collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Player1":
                    Direction(Sides.Right);
                    break;
                case "Player2":
                    Direction(Sides.Left);
                    break;
                case "BordaUp":
                    Direction(Sides.Down);
                    break;
                case "BordaDown":
                    Direction(Sides.Up);
                    break;
                case "BordaRight":
                    GameOverPong(1);
                    break;
                case "BordaLeft":
                    GameOverPong(2);
                    break;

                default:
                    break;
            }



        }

    }
}

