using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvionControl : MonoBehaviour
{
    public Rigidbody airplaneBody;
    public UnityEngine.UI.Text ObstacolVariable;
    public UnityEngine.UI.Text ScoreVariable;
    public UnityEngine.UI.Text StartCountdown;
    int count;

    IEnumerator Countdown(int seconds)
    {
        count = seconds;

        while (count > 0)
        {
            ObstacolVariable.text = count.ToString();
            // display something...
            yield return new WaitForSeconds(1);
            count--;
        }
            ObstacolVariable.text = "Start";
            yield return new WaitForSeconds(1);
            ObstacolVariable.text = "";
            count--;

        // count down is finished...
        //Update();
    }



    IEnumerator Countdown_Restart(int seconds)
    {
        count = seconds;

        while (count > 0)
        {
            yield return new WaitForSeconds(1);
            count--;
        }

        // reload the scene
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

        // Start is called before the first frame update
        void Start()
    {
        
        Debug.Log("My plane" + gameObject.name);
        ObstacolVariable.text = "";
        StartCountdown.text = "";
        StartCoroutine(Countdown(3));
    }

    // Update is called once per frame
   void Update()
    {
        if (count == -1)
        {
            new WaitForSeconds(1);
            //ObstacolVariable.text = "3";
            transform.position -= transform.right * Time.deltaTime * 200.0f;
            //        transform.position = transform.up * Time.deltaTime * 0.0f;
            //transform.Rotate(Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"), 0.0f);
            transform.Rotate(Input.GetAxis("Horizontal") * 15.0f, -Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            // transform.Rotate(Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"), Input.GetAxis());
        }
    }
    int n = 0;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Obstacle")
        {
            other.gameObject.SetActive(false);
            ObstacolVariable.text = "GAME OVER";
            StartCoroutine(Countdown_Restart(3));

        }

        
        if (other.gameObject.tag == "Gate")
        {
            other.gameObject.SetActive(false);
            n+=100;
            ScoreVariable.text = n.ToString();
        }



        if (other.gameObject.tag == "Finish")
        {
            other.gameObject.SetActive(false);
            ObstacolVariable.text = "Finish!!!";
            StartCoroutine(Countdown_Restart(3));
        }
    }
}