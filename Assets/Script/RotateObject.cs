using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateObject : MonoBehaviour
{
    [Header("回転する時間")]
    public float duration;

    //回転しているか、まだしていないかの状態を設定するための値。falseならまだ回転していない。
    private bool isRotate = false;

    private Tween tween;

    private void OnTriggerEnter(Collider col)
    {
        //キャラが一定の距離に入った時、まだ回転していない状態でないなら
        if (col.gameObject.tag == "Player" && isRotate == false)
        {
            //木を回転させて倒す
            Rotate();

            //回転して転倒した状態にする
            isRotate = true;
        }
    }

    /// <summary>
    /// 木を回転させる
    /// </summary>
    private void Rotate()
    {
        //Z軸のみduration分の時間をかけて回転。回転速度はRandomAngleメソッドの戻り値を利用して、ランダムに左右に倒れるようにする
        tween = transform.DORotate(new Vector3(0, 0, RandomAngle()), duration);
    }

    /// <summary>
    /// 木の回転角度をランダムに設定（float型の戻り値があるので、処理が終了するとfloat型の値を処理元に戻す）
    /// </summary>
    /// <returns></returns>
    private float RandomAngle()
    {
        //ランダムな値を取得してvalueに代入（Random.Range() メソッドも戻り値があります）
        int value = Random.Range(0, 2);

        //valueの値が０の場合
        if(value == 0)
        {
            //70.0fを呼び出し元に戻す
            return 70.0f;
        }
        //valueの値が１の場合
        else
        {
            //-70.0fを呼び出し元に戻す
            return -70.0f;
        }

        //↑の一連の記述を一行に簡潔化したもの
        //return Random.Range(0, 2) == 0 ? 70 : -70;

    }

    public void StopTween()
    {
        tween.Kill();
    }
   
}
