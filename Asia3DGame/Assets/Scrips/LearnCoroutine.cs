using UnityEngine;
using System.Collections;
namespace TerraiJason
{
    /// <summary>
    /// �ǲߨ�P�{�ǡA²�٨�{ Coroutine
    /// �ت�:���{�����d�F�쵥�ݪ��ĪG
    /// </summary>
public class LearnCoroutine : MonoBehaviour
{
        ///�ϥΨ�P�{�Ǫ��T�ӱ���
        ///1.�ޥΩR�W�Ŷ� System.Collections
        ///2.�w�q�@�ӶǦ^ IEnumerator����k
        ///3.��k�������ϥ� yield return (����)
        ///4.�ϥ� StartCoroutine �Ұ�

        //�r�� string �N�O�@�Ӱ}�C
        private string testDialogue = "�S�ӤF��?";

        private void Awake()
        {
            //StartCoroutine(Test());

            //print("���o���չ�ܪ��Ĥ@�Ӧr : " + testDialogue[0]);

            //StartCoroutine(ShowDialogue());

            //�Ω�ҰʤU��IEnumerator
            StartCoroutine(ShowDialogueUseFor());
        }

        private IEnumerator Test()
        {
            print("<color=#33ff33>�Ĥ@��{��</color>");
            //�b�����d2����
            yield return new WaitForSeconds(2);
            print("<color=#ff3333>�ĤG��{��</color>");
            //�b�����d3����
            yield return new WaitForSeconds(3);
            print("<color=#3333ff>�ĤT��{��</color>");
        }

        private IEnumerator ShowDialogue()
        {
            print(testDialogue[0]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[1]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[2]);
            yield return new WaitForSeconds(0.1f);
        }

        private IEnumerator ShowDialogueUseFor()
        {
            
            for (int i = 0; i < testDialogue.Length; i++)
            {
                print(testDialogue[i]);
                yield return new WaitForSeconds(0.2f);
            }
        }
}
    

}

