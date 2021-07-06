using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{

    //サークルにキャラが侵入した時に獲得できる得点値。インスペクターより設定する
    public int point;
    
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("キャラ侵入");

            //col.gameObject(つまりpenguinゲームオブジェクト)に対して、TryGetComponentメソッドを実行し
            //PlayerControllerクラスの情報を取得できるか判定する
            if(col.gameObject.TryGetComponent(out PlayerController player))
            {
                //Circleのゲームオブジェクトそのものをplayer（ペンギン）に取り込む
                transform.SetParent(player.transform);

                //PlayerControllerクラスが取得できている場合、
                //player変数を通じてPlayerControllerクラスに記述されているpublic修飾子のAddscoreメソッドを呼び出す命令をする
                player.AddScore(point);
            }

        }

        Destroy(gameObject, 0.3f);
        
    }

}
