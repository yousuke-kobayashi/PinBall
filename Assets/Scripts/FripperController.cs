using System.Collections;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingeJointコンポーネントを入れる
    HingeJoint myHingeJoint;

    //初期の傾き
    float defaultAngle = 20;
    //弾いた時の傾き
    float flickAngle = -20;

	void Start () {
        //HingeJointコンポーネントを取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }
	
	void Update () {
		//左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //画面をクリックまたはタップした時、その位置に応じてフリッパーを動かす
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x <= Screen.width / 2 && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            } else if (Input.mousePosition.x >= Screen.width / 2 && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }
        }
        //クリックまたはタップを離した時、フリッパーを元に戻す
        if (Input.GetMouseButtonUp(0))
        {
            SetAngle(this.defaultAngle);
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
