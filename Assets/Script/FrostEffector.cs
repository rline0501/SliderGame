using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostEffector : MonoBehaviour
{
    //霜のエフェクトのFrostAmountの値の加算値
    private float duration = 0.2f;

    //１回だけ霜のエフェクトを発生させるための制御用の判定値。falseなら未接触、trueなら接触済
    private bool isApplyEffected;

    private RotateObject rotateObject;

    private void Start()
    {
        TryGetComponent(out rotateObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        //Playerタグを持つゲームオブジェクト（ペンギン）と接触した際に、まだ１回も接触判定を行っていない(isApplyEffectedの値がfalseである)場合
        if(col.gameObject.tag == "Player" && isApplyEffected == false)
        {
            //何回も接触することを想定し、１回だけ霜のエフェクトを発生させるように条件を制御する
            isApplyEffected = true;

            //MainCameraタグのついているゲームオブジェクトをヒエラルキーから探して、そのゲームオブジェクトにアタッチされているFrostEffectControllerスクリプトの情報を取得し
            //FrostEffectControllerスクリプト内にあるUpdateFrostAmountメソッドを呼び出す命令を行う。引数としてduration変数の値を渡す
            Camera.main.gameObject.GetComponent<FrostEffectController>().UpdateFrostAmount(duration);

            //rotateObject変数で指定したRotateObject型の情報がNullでない場合
            if(rotateObject != null)
            {
                rotateObject.StopTween();
            }


            //このゲームオブヘクトを破棄する　＝＞　ゲーム画面に残しておきたい場合にはこの部分は消す
            Destroy(gameObject, 0.5f);

        }

    }
    
        
    
}
