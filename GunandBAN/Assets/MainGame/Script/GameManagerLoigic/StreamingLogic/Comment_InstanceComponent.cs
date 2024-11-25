using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using R3;

public class Comment_InstanceComponent : MonoBehaviour
{
    #region UIComponent
    [Header("Comment�C�x���g�i�[�p")]
    [SerializeField]
    private Button button_one;
    [SerializeField]
    private Button button_two;
    [SerializeField]
    private Button button_three;

    [Header("�{�^�����e�L�X�g")]
    [SerializeField]
    private TextMeshProUGUI buttonText_one;
    [SerializeField]
    private TextMeshProUGUI buttonText_two;
    [SerializeField]
    private TextMeshProUGUI buttonText_three;
    [Header("UserName�i�[�p")]
    [SerializeField]
    private TextMeshProUGUI UserName_one;
    [SerializeField]
    private TextMeshProUGUI UserName_two;
    [SerializeField]
    private TextMeshProUGUI UserName_three;
    #endregion

    [Header("���̑�")]
    [SerializeField]
    private Button None;
    [SerializeField] 
    private TextMeshProUGUI Remit_Text;

    public Image RemitUI;


    public float RemitMax = 5;
    public float RemitCount=5;

    /// <summary>
    /// �����Ă݂������Ƃ�����B
    /// </summary>
    public int A;
    public int B;
    public int C;


    IDisposable dispose;

    public AsyncOperationHandle delete;

    /// <summary>
    /// ��������Ǝ����I�ɏ�񂪊i�[�����悤�ɂ��Ă�����B
    /// </summary>
    public void Start()
    {
        Init();
    }
    /// <summary>
    /// ����������
    /// </summary>
    public void Init()
    {
        GameMains_StreamLogic gameMains_StreamLogic = GameMains_StreamLogic.Instance();

        #region 1�l��

        //�O�����琔�l������Ă��Ȃ��ƁA�N���b�N�������̕ϐ��̒l�ɂȂ��Ă��܂��̂Ńo�O���Ă��܂��̂ŊO���ň�x�i�[����
        int num_a = gameMains_StreamLogic.current_UserDataNum;
        A = gameMains_StreamLogic.UserList[num_a].Id;

        Debug.Log("�e�X�gA��"+num_a);
        //�N���b�N�������ABAN����
        button_one.onClick.AddListener(() =>
        {
            gameMains_StreamLogic.OnBAN(A);
            dispose?.Dispose();
            Remove();
        });

        /////���̂܂܂���Ȃ񂩒m��񂯂ǃC���f�b�N�X�ԍ������Z�b�g�ȍ~�����Ă���Ȃ��H�I�Ȃ�ŁH�I

        //�R�����g�̏��������Ă���B
        //(���������^�C�~���O�ŕʓr�A�֐��ŃC�x���g�̖��O���w�肷�鎖
        gameMains_StreamLogic.UserComment(gameMains_StreamLogic.current_EventName);
        UserName_one.text = gameMains_StreamLogic.current_User;
        buttonText_one.text = gameMains_StreamLogic.current_Comment;
        #endregion

        # region 2�l��
        int num_b = gameMains_StreamLogic.current_UserDataNum;
        Debug.Log("�e�X�gB��"+num_b);
        B = gameMains_StreamLogic.UserList[num_b].Id;
        

        button_two.onClick.AddListener(() =>
        {
            gameMains_StreamLogic.OnBAN(B);
            dispose?.Dispose();
            Remove();
        });
        //�R�����g�̏��������Ă���B
        //(���������^�C�~���O�ŕʓr�A�֐��ŃC�x���g�̖��O���w�肷�鎖
        gameMains_StreamLogic.UserComment(gameMains_StreamLogic.current_EventName);
        UserName_two.text = gameMains_StreamLogic.current_User;
        buttonText_two.text = gameMains_StreamLogic.current_Comment;
        #endregion

        #region 3�l��
        int num_c = gameMains_StreamLogic.current_UserDataNum;
        C=gameMains_StreamLogic.UserList[num_c].Id;
        

        button_three.onClick.AddListener(() =>
        {
            gameMains_StreamLogic.OnBAN(C);
            dispose?.Dispose();
            Remove();
        });
        //�R�����g�̏��������Ă���B
        //(���������^�C�~���O�ŕʓr�A�֐��ŃC�x���g�̖��O���w�肷�鎖
        gameMains_StreamLogic.UserComment(gameMains_StreamLogic.current_EventName);
        UserName_three.text = gameMains_StreamLogic.current_User;
        buttonText_three.text = gameMains_StreamLogic.current_Comment;
        #endregion

        //�Q�[�W����
        RemitCount = RemitMax;
        dispose = Observable.EveryUpdate().Subscribe(_ =>
        {
            RemitCount -= Time.deltaTime;
            if (RemitCount > 0)
            {

                RemitUI.fillAmount = RemitCount / RemitMax;
            }
            else
            {
                RemitUI.fillAmount = RemitCount / RemitMax;
                dispose?.Dispose();
                Remove();
            }
        }).AddTo(this);

        None.onClick.AddListener(() =>
        {
            dispose?.Dispose();
            Remove();
        });
    }

    /// <summary>
    /// �폜
    /// </summary>
    public void Remove()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        if (delete.IsValid())
        {
            Addressables.Release(delete);
        }
    }
}
