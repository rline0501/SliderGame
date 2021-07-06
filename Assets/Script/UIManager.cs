using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text txtScore;

    [SerializeField]
    private Text txtTime;
    

    /// <summary>
    /// �X�R�A�̕\���X�V
    /// </summary>
    /// <param name="score"></param>
    public void UpdateDisplayScore(int score)
    {
        txtScore.text = score.ToString();
    }

    /// <summary>
    /// �Q�[�����Ԃ̕\���X�V
    /// </summary>
    /// <param name="time"></param>
    public void UpdateDisplayGameTime(int time)
    {
        txtTime.text = time.ToString();
    }
}
