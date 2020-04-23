using UnityEngine;
using MonkeyGame.Scripts;

namespace MonkeyGame.Manager
{
    class ScoreManager : Singleton<ScoreManager>
    {
        [SerializeField] private int score;
        [SerializeField] private Collectible[] bananas;

        private void Awake()
        {
            if (ScoreManager.Instance)
                DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            bananas = FindObjectsOfType<Collectible>();
            foreach (var banana in bananas)
                banana.PickUp += AddScore;
        }

        private void Update()
        {
            //foreach (var b in bananas)
            //    if (!b.isActiveAndEnabled)
            //        Debug.Log("Obiekt " + b.gameObject.name + " jest nie aktywny.");
        }

        public void AddScore(TypeCollect banana)
        {
            score += (int)banana;
        }

        public int GetScore() => score;
    }
}
