using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
    //ボールが見える可能性のあるｚ軸の最大値
    float visiblePosZ = -6.5f;

    //スコアの初期化
    int score = 0;
    //得点表・・・小星、大星、小雲、大雲
    int[] scoreTable = { 5, 10, 20, 50 };

    //ゲームオーバーを表示するテキスト
    GameObject gameoverText;

    //スコアを表示するテキスト(component)
    Text scoreTx;


    void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        //シーン中のScoreTextオブジェクトを取得
        GameObject scoreText = GameObject.Find("ScoreText");

        //ScoreTextのTextコンポーネントを取得
        scoreTx = scoreText.GetComponent<Text>();
    }
	
	void Update () {
		//ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        //スコアの表示
        scoreTx.text = "Score : " + score;
    }

    public void OnCollisionEnter(Collision other)
    {
        //衝突したオブジェクトをタグで識別し、得点を加算
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += scoreTable[0];
        } else if (other.gameObject.tag == "LargeStarTag")
        {
            score += scoreTable[1];
        } else if (other.gameObject.tag == "SmallCloudTag")
        {
            score += scoreTable[2];
        } else if (other.gameObject.tag == "LargeCloudTag")
        {
            score += scoreTable[3];
        } else
        {
            return;
        }
    }
}
