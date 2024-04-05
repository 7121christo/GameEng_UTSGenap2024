using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BalllController : MonoBehaviour
{
    // Start is called before the first frame update
    public int force;
    int score1;
    int score2;
    Rigidbody2D rigid;
    Text scoreUIP1;
    Text scoreUIP2;
    GameObject panelSelesai;
    Text txPemenang;
    void Start(){
        score1=0;
        score2=0;
        rigid = GetComponent<Rigidbody2D> ();
        Vector2 arah = new Vector2 (0, 2).normalized;
        rigid.AddForce (arah * force);
        scoreUIP1 = GameObject.Find ("score1").GetComponent<Text> ();
        scoreUIP2 = GameObject.Find ("score2").GetComponent<Text> ();
        panelSelesai = GameObject.Find ("PanelSelesai");
        panelSelesai.SetActive (false);


    }
    // Update is called once per frame
    void Update(){
    }
    
    private void OnCollisionEnter2D(Collision2D coll)
        {
         if (coll.gameObject.name == "pointarea1")
         {
            score1 +=1;
            TampilkanScore();
            if (score1 == 5) {
            panelSelesai.SetActive (true);
            txPemenang = GameObject.Find ("Pemenang").GetComponent<Text> ();
            txPemenang.text = "Player Hijau Pemenang!";
            Destroy (gameObject);
            return;
            }
            ResetBall();
            Vector2 arah = new Vector2(0, 2).normalized;
            rigid.AddForce(arah * force);
         }
         if (coll.gameObject.name == "pointarea2")
         {
            score2 +=1;
            TampilkanScore();
            if (score2 == 5) {
            panelSelesai.SetActive (true);
            txPemenang = GameObject.Find ("Pemenang").GetComponent<Text> ();
            txPemenang.text = "Player Merah Pemenang!";
            Destroy (gameObject);
            return;
            }
            ResetBall();
            Vector2 arah = new Vector2(0, 2).normalized;
            rigid.AddForce(arah * force);
         }
         if (coll.gameObject.name == "paddle1" || coll.gameObject.name == "paddle2")
         {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 2);
         }
        }
        void ResetBall()
        {
            transform.localPosition = new Vector2(0, 0);
            rigid.velocity = new Vector2(0, 0);
        }
        void TampilkanScore()
        {
            Debug.Log ("Score 1: " + score1 + " Score 2: " + score2);
            scoreUIP1.text = score1 + "";
            scoreUIP2.text = score2 + "";
        }

}