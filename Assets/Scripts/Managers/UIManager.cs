using TMPro;
using UnityEngine;

namespace MonkeyGame.Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject Health;
        [SerializeField] GameObject Score;

        [SerializeField] TextMeshProUGUI _health;
        [SerializeField] TextMeshProUGUI _score;

        [SerializeField] ScoreManager ScoreManager;

        // Start is called before the first frame update
        void Start()
        {
            ScoreManager = ScoreManager.Instance;
            _health = Health.GetComponent<TextMeshProUGUI>();
            _score  = Score.GetComponent<TextMeshProUGUI>();

            ScoreManager.AddedScore += UpdateScore;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void UpdateHealth()
        {
        }

        void UpdateScore()
        {
            _score.text = ScoreManager.Instance.GetScore().ToString();
        }
    }
}