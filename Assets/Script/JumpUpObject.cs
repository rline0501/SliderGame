using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpUpObject : MonoBehaviour
{

    //�L�����̃X�^�[�g�ʒu�̍���
    private float startHeight;

    //�L�������B�����߂̍����̓x����
    private float hideHeight = 1.0f;

    
    void Start()
    {
        //�B��
        Hide();

    }

    /// <summary>
    /// �Q�[���I�u�W�F�N�g���B��
    /// </summary>
    private void Hide()
    {
        //�Q�[���J�n�O�̈ʒu�����L�^���Ă���
        startHeight = transform.position.y;

        //�I�u�W�F�N�g�̍����iY���j��ύX���ĎΖʂ̒��ɉB���悤�ɂ���
        transform.position = new Vector3(transform.position.x, transform.position.y - hideHeight, transform.position.z);

    }

    private void OnTriggerEnter(Collider col)
    {
        //�L���������͈͂ɓ����������o��
        if(col.gameObject.tag == "Player")
        {
            Debug.Log(col.gameObject.tag);

            //TODO
            HeadUp();
        }
    }

    /// <summary>
    /// ����o��
    /// </summary>
    private void HeadUp()
    {
        //DOTween�̋@�\���g���ăI�u�W�F�N�g����ֈړ�������
        transform.DOMoveY(startHeight, 0.25f);
    }

    
}
