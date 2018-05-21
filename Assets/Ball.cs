using System.Threading;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {
    // Movement Speed
    public static float speed = 120.0f;
    public AudioClip audioClip;
    public static int total_score;
    public static int current_scene_score;
    public static int racket = 3;
    public static int currentSceneNum;

    public object Advertisement { get; private set; }

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClip;
        audio.Play();
        // Hit the Racket?
        if (col.gameObject.name == "racket")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "background")
        {
            Ball.racket--;

            if (Ball.racket == 0)
            {
                //Ball.racket = 3;
                //Ball.total_score = 0;
                //Ball.speed = 120f;
                SceneManager.LoadScene(7);
            }
        }

        if (PlayerPrefs.GetInt("blocks_count") == 0)
        {
            ShowRewardedAd();

            //int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            //if (sceneIndex + 1 != 7)
            //{
            //    Ball.speed = Ball.speed + Ball.speed * 0.2f;
            //    SceneManager.LoadScene(sceneIndex + 1);
            //}
            //else
            //{
            //    SceneManager.LoadScene(0);
            //}
        }

    }

    public void ShowRewardedAd()
    {
        if (UnityEngine.Advertisements.Advertisement.IsReady())
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            UnityEngine.Advertisements.Advertisement.Show(options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex + 1 != 7)
        {
            Ball.speed = Ball.speed + Ball.speed * 0.2f;
            SceneManager.LoadScene(sceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

        //switch (result)
        //{
        //    case ShowResult.Finished:
        //        Debug.Log("The ad was successfully shown.");
        //        //
        //        // YOUR CODE TO REWARD THE GAMER
        //        // Give coins etc.
        //        break;
        //    case ShowResult.Skipped:
        //        Debug.Log("The ad was skipped before reaching the end.");
        //        break;
        //    case ShowResult.Failed:
        //        Debug.LogError("The ad failed to be shown.");
        //        break;
        //}
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }


   

    
}
