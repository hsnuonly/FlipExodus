using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	Rigidbody rb;
	public float jump = 10F;
    public float cap = 10.5F;
    public float speed = 10F;
    public Text scoreText;
    ArrayList sample;
    public GameObject Cube1, Cube2, Cube3, Cube4;
    public GameObject spotline;
    ArrayList bricks;
    public int direction = 0;
    public GameObject toStand;
    bool canJump = false;
    public string menuScene;
    public GameObject Body;
    int nextStandType,standType;
    int fireCount = 0;
    public GameObject gameOverFrame;
    public GameObject flame;
    
    int score;
	// Use this for initialization
	void Start () {
        gameOverFrame.SetActive(false);
        sample = new ArrayList();
        sample.Add(Cube1);
        sample.Add(Cube2);
        sample.Add(Cube3);
        sample.Add(Cube4);
        rb = GetComponent<Rigidbody>();
        score = -1;
        bricks = new ArrayList();
	}
	
	void FixedUpdate () {
        if (this.transform.position.y <= -5)
        {
            Debug.Log(123);
            gameOver();
        }
        if (canJump&&Input.GetMouseButton(0))
        {
            standType = -1;
            flame.SetActive(false);
            Vector3 speedVec = spotline.transform.rotation.eulerAngles/360*2*Mathf.PI;
            rb.velocity += new Vector3(-Mathf.Sin(speedVec.z)*speed,
                (Mathf.Cos(speedVec.x)+Mathf.Cos(speedVec.z))*jump,
                Mathf.Sin(speedVec.x)*speed);
            canJump = false;
            spotline.SetActive(false);
        }
        if (standType == 1)
        {
            flame.SetActive(true);
            fireCount++;
        }
        if (fireCount >= 180)
        {
            gameOver();
        }
	}
    

    private void OnCollisionEnter(Collision collision)
    {
        // not stand on brick
        Debug.Log(collision.gameObject);
        if (collision.gameObject.Equals(toStand))
        {
            fireCount = 0;
            spotline.SetActive(true);
            score++;
            scoreText.text = "Score: "+score;
            spotline.transform.rotation = Quaternion.Euler(0, 0, 0);
            canJump = true;
            standType = nextStandType;
            nextStandType = (int)Random.Range(0, 4);
            GameObject another = (GameObject)sample[nextStandType];
            if (Random.Range(0F,1F)<0.5)
            {
                toStand = Instantiate(another, collision.transform.position + new Vector3(0, Random.Range(0,1), Random.Range(-25, -15)), collision.transform.rotation);
                direction = 1;
                Body.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                toStand = Instantiate(another, collision.transform.position + new Vector3(Random.Range(15, 25), Random.Range(0, 1), 0), collision.transform.rotation);
                direction = 0;
                Body.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            bricks.Add(toStand);
        }
        else
        {
            gameOver();
        }
        
    }
    void gameOver()
    {
        gameOverFrame.SetActive(true);
        //Application.LoadLevel(menuScene);
    }
}
