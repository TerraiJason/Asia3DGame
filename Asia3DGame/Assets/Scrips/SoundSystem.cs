
using UnityEngine;
namespace TerraiJason
{

    /// <summary>
    /// ���Ĩt��
    /// </summary>
    /// �n�D����:�b�Ĥ@���M�Φ��}���ɷ|�K�[�̭����w������
public class SoundSystem : MonoBehaviour
{
        private AudioSource aud;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }

         /// <summary>
         /// ���񭵮�
         /// </summary>
         /// <param name= "sound">�n���񪺭���</param>
         public void PlaySound(AudioClip sound)
        {
            //���Ĩӷ�.����@������(����)
            aud.PlayOneShot(sound);
        }
    }

}

