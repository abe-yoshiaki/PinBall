using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;
    private int rightFingerId = 0;
    private int leftFingerId = 0;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

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

       if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                //画面に指が触れたとき、またはスライドしているとき   
                if(t.phase == TouchPhase.Began || t.phase == TouchPhase.Moved)
                {
                    //左画面をタッチしたときに左フリッパーを動かす
                    if (tag == "LeftFripperTag" && t.position.x <= Screen.width / 2)
                    {
                        leftFingerId = t.fingerId;
                        SetAngle(this.flickAngle);
                    }
                    //右画面をタッチしたときに右フリッパーを動かす
                    if (tag == "RightFripperTag" && t.position.x >= Screen.width / 2)
                    {
                        rightFingerId = t.fingerId;
                        SetAngle(this.flickAngle);
                    }
                }
                //画面から指が離れた時フリッパーを元に戻す
                if (t.phase == TouchPhase.Ended)
                {
                    //左画面をタッチしたときに左フリッパーを動かす
                    if (tag == "LeftFripperTag" && t.fingerId == leftFingerId)
                    {
                        SetAngle(this.defaultAngle);
                    }
                    //右画面をタッチしたときに右フリッパーを動かす
                    if (tag == "RightFripperTag" && t.fingerId == rightFingerId)
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
               
          }
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