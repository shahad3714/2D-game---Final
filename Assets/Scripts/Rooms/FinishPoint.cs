using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [Header("Winner")]
    [SerializeField] private GameObject winnerScreen;
   // [SerializeField] private GameObject finishPoint;
    

    private void Awake()
    {
        winnerScreen.SetActive(false);
    }

    public void PauseGame(bool status)
    {
        winnerScreen.SetActive(status);

        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

   private void OnTriggerEnter2D( Collider2D collision){
        if (collision.CompareTag("Player")){
             if (winnerScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
          //  winnerScreen.SetActive(true);
        }
    }
}



