using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    enum dir
    {
        up,
        down,
    }


    public class PlataformaInput : MonoBehaviour
    {
        public GameObject Player1, Player2;
        private Vector3 SP1, SP2;
        [Range(1, 10)]
        public float Speed = 3f;

        private void Awake()
        {
            SP1 = Player1.transform.position;
            SP2 = Player2.transform.position;
        }

        void Update()
        {
            MovePlatform(GameManagerPong.Instance.state);
        }

        private void MovePlatform(States states)
        {
            switch (states)
            {
                case States.Menu:
                    ResetPos();
                    break;
                case States.Start:
                    ResetPos();
                    break;
                case States.GamePlay:
                    Move();
                    break;
                case States.GameOver:
                    ResetPos();
                    break;
                case States.Pause:
                    break;
                case States.Reset:
                    ResetPos();
                    break;
                default:
                    break;
            }
        }

        private void Move()
        {
            switch (Input.inputString)
            {
                case "w":
                    Player1.transform.position = new Vector3(
                        Player1.transform.position.x,
                        Mathf.Clamp(Player1.transform.position.y + Direction(dir.up),
                            -4.5f, 4.5f),
                        Player1.transform.position.z
                        ); 
                    break;
                case "s":
                    Player1.transform.position = new Vector3(
                        Player1.transform.position.x,
                        Mathf.Clamp(Player1.transform.position.y + Direction(dir.down),
                            -4.5f, 4.5f),
                        Player1.transform.position.z
                        );
                    break;
                case "8":
                    Player2.transform.position = new Vector3(
                        Player2.transform.position.x,
                        Mathf.Clamp(Player2.transform.position.y + Direction(dir.up),
                            -4.5f, 4.5f),
                        Player2.transform.position.z
                        );
                    break;
                case "2":
                    Player2.transform.position = new Vector3(
                        Player2.transform.position.x,
                        Mathf.Clamp(Player2.transform.position.y + Direction(dir.up),
                            -4.5f, 4.5f),
                        Player2.transform.position.z
                        );
                    break;
                default:
                    break;
            }

        }

        private void ResetPos()
        {
            Player1.transform.position = SP1;
            Player2.transform.position = SP2;
        }

        private float Direction(dir dir)
        {
            float aux = 0;

            switch (dir)
            {
                case dir.up:
                    aux = Speed * Time.deltaTime;
                    break;
                case dir.down:
                    aux = -(Speed * Time.deltaTime);
                    break;
                default:
                    break;
            }

            return aux;
        }

    }

}
