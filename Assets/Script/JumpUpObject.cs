using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpUpObject : MonoBehaviour
{

    //キャラのスタート位置の高さ
    private float startHeight;

    //キャラを隠すための高さの度合い
    private float hideHeight = 1.0f;

    
    void Start()
    {
        //隠す
        Hide();

    }

    /// <summary>
    /// ゲームオブジェクトを隠す
    /// </summary>
    private void Hide()
    {
        //ゲーム開始前の位置情報を記録しておく
        startHeight = transform.position.y;

        //オブジェクトの高さ（Y軸）を変更して斜面の中に隠れるようにする
        transform.position = new Vector3(transform.position.x, transform.position.y - hideHeight, transform.position.z);

    }

    private void OnTriggerEnter(Collider col)
    {
        //キャラが一定範囲に入ったら顔を出す
        if(col.gameObject.tag == "Player")
        {
            Debug.Log(col.gameObject.tag);

            //TODO
            HeadUp();
        }
    }

    /// <summary>
    /// 顔を出す
    /// </summary>
    private void HeadUp()
    {
        //DOTweenの機能を使ってオブジェクトを上へ移動させる
        transform.DOMoveY(startHeight, 0.25f);
    }

    
}
