using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
/// <summary>
/// �|�b�v�A�b�vWindow�𐶐�����ׂ̃V���O���g��
/// </summary>
public class PopUpWindowManage : Singleton<PopUpWindowManage>
{
    public GameObject PopUp;
    public GameObject PopUp_Select;
    public PopUpWindow popupwindow;
    public PopUpWindow_optionSelect popupwindow_optionselect;

    AsyncOperationHandle delete;
    /// <summary>
    /// �|�b�v�A�b�vWindow���o���B�ėp�B
    /// �������Ƀ|�b�v�A�b�v���̃e�L�X�g�B
    /// �������͐e�I�u�W�F�N�g���w��
    /// </summary>
    public void PopUp_Window_Instante(string Text,GameObject Parent)
    {
        Addressables.LoadAssetAsync<GameObject>("PopUpWindow").Completed
            += _ => {
                if (_.Result == null)
                {
                    return;
                }

                //delete = _;
                PopUp = Instantiate(_.Result);
                PopUp.transform.SetParent(Parent.transform, false);
                popupwindow = PopUp.GetComponent<PopUpWindow>();
                popupwindow.delete = _;

                popupwindow.popuptext.text = Text;
                popupwindow.button.onClick.AddListener(() => { 
                    Destroy(PopUp);
                    Addressables.Release(popupwindow.delete);
                });
            };        
    }
    /// <summary>
    /// �m�F�p�|�b�v�A�b�vWindow���o���B
    /// �������ɂ͎��s���̊֐���
    /// ��2�����Ƀ|�b�v�A�b�v���̃e�L�X�g�B
    /// ��3�����͐e�I�u�W�F�N�g���w��
    /// </summary>
    /// <param name="Text"></param>
    /// <param name="Parent"></param>
    public void PopUp_Window_optionSelect_Instance(Action action,string Text, GameObject Parent)
    {
        Addressables.LoadAssetAsync<GameObject>("PopUpWindow_optionSelect").Completed
            += _ => {
                if (_.Result == null)
                {
                    return;
                }

                PopUp_Select = Instantiate(_.Result);
                PopUp_Select.transform.SetParent(Parent.transform, false);
                popupwindow_optionselect = PopUp_Select.GetComponent<PopUpWindow_optionSelect>();
                popupwindow_optionselect.delete = _;

                popupwindow_optionselect.popuptext.text = Text;

                //���ۂ̏����͊֐��������̎��Ɏw�肷����̂Ƃ���B����
                popupwindow_optionselect.ok.onClick.AddListener(() => { 
                    action();
                    //�|�b�v�A�b�v����
                    Destroy(PopUp_Select);
                    Addressables.Release(popupwindow_optionselect.delete);
                }) ;
                
                //�L�����Z���B�|�b�v�A�b�v����
                popupwindow_optionselect.cancel.onClick.AddListener(() => {
                    Destroy(PopUp_Select);
                    Addressables.Release(popupwindow_optionselect.delete);
                });
            };
    }
}
