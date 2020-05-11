using UnityEngine;

namespace MonkeyGame.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int health;


        // Start is called before the first frame update
        void Start()
        {
            Cursor.visible = false;
            health = 3; //Test
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}