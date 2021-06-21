using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    //�J�������Ǐ]����Ώۂ̃Q�[���I�u�W�F�N�g�B����̓y���M��
    private GameObject playerObj;

    //�J�������Ǐ]����ΏۂƂ̊Ԃ����B���̋����p�̕␳�l
    private Vector3 offset;

    void Start()
    {
        //�J�����ƒǏ]�Ώۂ̃Q�[���I�u�W�F�N�g�Ƃ̋�����␳�l�Ƃ��Ď擾
        offset = transform.position - playerObj.transform.position;
    }

    void Update()
    {
        //�Ǐ]�Ώۂ�����ꍇ
        if(playerObj != null)
        {
            //�J�����̈��Ǐ]�Ώۂ̈ʒu + �␳�l�ɂ���
            transform.position = playerObj.transform.position + offset;
        }
    }
}
