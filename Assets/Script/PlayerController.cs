using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //RigitBody�R���|�[�l���g�̑�����s�����߁ARigitbody�R���|�[�l���g���擾���đ�����邽�߂̕ϐ�
    private Rigidbody rb;

    //Header������ϐ��̐錾�ɒǉ�����ƃC���X�y�N�^�[��Ɂi�@�j���ɋL�q�����������\�������
    [Header("�ړ����x")]
    public float moveSpeed;

    [Header("�������x")]
    public float accelerationSpeed;

    [SerializeField]
    //������s��PhysicsMaterial���C���X�y�N�^�[����o�^���Ēl�Ƃ��đ��
    private PhysicMaterial pmNoFriction;

    void Start()
    {
        //���̃X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�������Ă���Rigidbody�R���|�[�l���g�̏��������ϐ��ɑ��
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() //Update���\�b�h�ł͂Ȃ��̂Œ���
    {
        //�ړ�
        Move();
    }

    /// <summary>
    /// �ړ�
    /// </summary>
    private void Move()
    {
        //�L�[�{�[�h�̍��E���̃L�[���͂𔻒肵�A-1.0f �` 1.0f�܂ł̒l����
        float x = Input.GetAxis("Horizontal");

        //Rigitbody��Velocity(���x)�ɁA�L�[���͂̔���l�ƈړ����x�������ăL�������ړ�
        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, rb.velocity.z);

        Debug.Log(rb.velocity);
    }

    private void Update()
    {
        //�u���[�L
        Brake();

        //����
        Accelerate();

    }



    /// <summary>
    /// �u���[�L
    /// </summary>
    private void Brake()
    {
        //�㉺�����̃L�[���͂��󂯕t���Ēl����
        float vertical = Input.GetAxis("Vertical");

        //�擾�����l���O�����������l�i�������̃L�[���́j�Ȃ�
        if(vertical < 0)
        {
            //NoFriction��DynamicFriction�̒l���W���W���ɑ傫������
            pmNoFriction.dynamicFriction += Time.deltaTime;

            //������DynamicFriction�̒l���ő�l�ł���1.0f�𒴂�����
            if (pmNoFriction.dynamicFriction > 1.0f) 
            {
                //1.0f�Œ�~����B
                pmNoFriction.dynamicFriction = 1.0f;

            }
        }

        //�擾�����l���O�A���邢�͂O�����傫�Ȓl�i�L�[���͂Ȃ��A���邢�͏�����̃L�[���͂Ȃ�j
        else
        {
            //���C���O�ɖ߂��@�����@�Ăъ���n�߂�悤�ɂȂ�
            pmNoFriction.dynamicFriction = 0;
        }
    }

    /// <summary>
    /// ����
    /// </summary>
    private void Accelerate()
    {
        //�㉺�����̃L�[���͂��󂯕t���Ēl����
        float vertical = Input.GetAxis("Vertical");

        //�擾�����l���O�����傫�Ȓl�i������̃L�[���́j�Ȃ�
        if(vertical > 0)
        {
            //���藎���Ă��鑬�x�iVelocity��Z�j��ύX���ĉ���������
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, accelerationSpeed);
        }
    }

}
