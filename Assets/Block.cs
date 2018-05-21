using UnityEngine;

public class Block : MonoBehaviour {

    public readonly static float X = 16f;
    public readonly static float Y = 8f;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        // Destroy the whole Block
        Destroy(gameObject);
        Ball.total_score++;
        PlayerPrefs.SetInt("blocks_count", (PlayerPrefs.GetInt("blocks_count") - 1));
        if(Ball.total_score % 100 == 0)
        {
            Ball.racket += 1;
        }
    }
}
