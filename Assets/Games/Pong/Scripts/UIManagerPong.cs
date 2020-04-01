using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pong
{
    public class UIManagerPong : MonoBehaviour
    {
        public GameObject StartPanel , ScorePanel;
        public Text contador;
        public Text Score1, Score2;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            contador.text = GameManagerPong.Instance.Tempo.ToString("F0");
            Score1.text = GameManagerPong.Instance.ScoreP1.ToString();
            Score2.text = GameManagerPong.Instance.ScoreP2.ToString();

            if (GameManagerPong.Instance.Tempo <= 0)
            {
                StartPanel.SetActive(false);
                ScorePanel.SetActive(true);
            }
        }
    }
}

