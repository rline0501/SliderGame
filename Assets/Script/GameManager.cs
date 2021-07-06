using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    [Header("ゲーム時間")]
    public int gameTime;

    private float timeCounter;
    
    void Start()
    {
        //ゲーム時間の表示を更新
        uiManager.UpdateDisplayGameTime(gameTime);
    }

    
    void Update()
    {
        //カウンターを加算
        timeCounter += Time.deltaTime;

        //１秒経つごとに
        if(timeCounter >= 1.0f)
        {
            //カウンターを初期化。再度０から加算して上記の条件に入るようにする
            timeCounter = 0;

            //ゲーム時間を１秒ずつ減らす
            gameTime --;

            //ゲーム時間が０以下になったら
            if(gameTime <= 0)
            {
                //マイナスにならないように０に固定する
                gameTime = 0;
            }

            //ゲーム時間の表示を更新（１秒経過ごとに実行される仕組み
            uiManager.UpdateDisplayGameTime(gameTime);

        }


    }
}
