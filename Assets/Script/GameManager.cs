using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    [Header("�Q�[������")]
    public int gameTime;

    private float timeCounter;
    
    void Start()
    {
        //�Q�[�����Ԃ̕\�����X�V
        uiManager.UpdateDisplayGameTime(gameTime);
    }

    
    void Update()
    {
        //�J�E���^�[�����Z
        timeCounter += Time.deltaTime;

        //�P�b�o���Ƃ�
        if(timeCounter >= 1.0f)
        {
            //�J�E���^�[���������B�ēx�O������Z���ď�L�̏����ɓ���悤�ɂ���
            timeCounter = 0;

            //�Q�[�����Ԃ��P�b�����炷
            gameTime --;

            //�Q�[�����Ԃ��O�ȉ��ɂȂ�����
            if(gameTime <= 0)
            {
                //�}�C�i�X�ɂȂ�Ȃ��悤�ɂO�ɌŒ肷��
                gameTime = 0;
            }

            //�Q�[�����Ԃ̕\�����X�V�i�P�b�o�߂��ƂɎ��s�����d�g��
            uiManager.UpdateDisplayGameTime(gameTime);

        }


    }
}
