using UnityEngine;
using UnityEngine.SceneManagement;

public class Racket : MonoBehaviour
{
    // Movement Speed
    public float speed = 150f;

    private Rect _rightZone;
    private Rect _leftZone;

    private void Start()
    {
        //_rightZone = new Rect(0, 0, Screen.width / 3, Screen.height);
        //_leftZone = new Rect(Screen.width / 3 * 2, 0, Screen.width / 3, Screen.height);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex == 7)
        {
            Ball.racket = 3;
            Ball.total_score = 0;
            Ball.speed = 120f;
            SceneManager.LoadScene(0);
        }

        //bool touchLeft = IsTouchContains(_leftZone);
        //bool touchRight = IsTouchContains(_rightZone);

        //float horizontal = 0;

        //if(touchLeft || touchRight)
        //{
        //    if (touchLeft)
        //    {
        //        horizontal -= Time.deltaTime * 5;
        //    }
        //    else
        //    {
        //        horizontal += Time.deltaTime * 5;
        //    }
        //    GetComponent<Rigidbody2D>().velocity = Vector2.right * horizontal * speed;
        //}
    }

    void FixedUpdate()
    {
        // Get Horizontal Input
        float h = Input.GetAxisRaw("Horizontal"); ;
        
        // Set Velocity (movement direction * speed)
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
    }

    void OnGUI()
    {
        int x = 10;
        int y = 10;
        int h = 100;
        int w = 150;
        int step = 18;
        int step_start = 18;
        GUI.Box(new Rect(x, y, w, h), "ARKANOID");
        GUI.Box(new Rect(x, y + step, w, h), SceneManager.GetActiveScene().name);
        step += step_start;
        if(SceneManager.GetActiveScene().buildIndex == 7)
        {
            GUI.Box(new Rect(x, y + step, w, h), "Press Space button");
            step += step_start;
        }
        GUI.BeginGroup(new Rect(x, y, w, h), "");
        GUI.Label(new Rect(x, y + step, w - step_start * 2, 20), "Points: " + Ball.total_score);
        step += step_start;
        GUI.Label(new Rect(x, y + step, w - step_start * 2, 20), "Racket: " + Ball.racket);
        step += step_start;
        GUI.EndGroup();
    }

    private bool IsTouchContains(Rect area)
    {
        bool res = false;
        foreach (var item in Input.touches)
        {
            Vector2 tPos = item.position;
            tPos.y = Screen.height - tPos.y;
            if (area.Contains(tPos))
            {
                res = true;
            }
        }
        return res;
    }
}
