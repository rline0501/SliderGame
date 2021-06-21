using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    //カメラが追従する対象のゲームオブジェクト。今回はペンギン
    private GameObject playerObj;

    //カメラが追従する対象との間を取る。一定の距離用の補正値
    private Vector3 offset;

    void Start()
    {
        //カメラと追従対象のゲームオブジェクトとの距離を補正値として取得
        offset = transform.position - playerObj.transform.position;
    }

    void Update()
    {
        //追従対象がいる場合
        if(playerObj != null)
        {
            //カメラの一を追従対象の位置 + 補正値にする
            transform.position = playerObj.transform.position + offset;
        }
    }
}
