using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningPlayer : MonoBehaviour
{
    public GameObject title;
    public GameObject NewGame;
    public GameObject Option;
    public GameObject NewMyAccount;

    private OpeningContext OpeningContext;

    private void Awake()
    {
        OpeningContext = new OpeningContext();
        OpeningContext.Opening_Init(this, OpeningState.NewMyAccount);
    }

    private void Update() => OpeningContext.Opening_currentState.Update();
    private void FixedUpdate() => OpeningContext.Opening_currentState.FixUpdate();


}
/// <summary>
/// �Ή�����State
/// </summary>
public enum OpeningState
{
    Title,//�������
    Option,//�ݒ���
    NewGame,//�Q�[���f�[�^���������
    NewMyAccount,//�A�J�E���g�쐬���
}