using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Babu
{
    public class UIController : MonoBehaviour
    {
        //<summary>
        //페이드인(서서히 나타나는 에니메이션) 하고 싶은 오브젝트 삽입
        //</summary>
        public GameObject[] FadeObject;
        //<summary>
        //페이드인 완료후 활성화 하고 싶은 버튼
        //</summary>
        public GameObject[] ActiveObject;
        //<summary>
        //UI비행기
        //</summary>
        public Transform objPlayer;
        //<summary>
        //UI 랭크
        //</summary>
        public GameObject RankGroup;


        void Start()
        {
            StartCoroutine(MoveRoutine(new Vector2(0, Screen.height / 2), 1.0f));
        }

        //서서히 나타나는 에니메이션
        IEnumerator FadeIn()
        {
            float time = 0;
            while(time < 1)
            {
                time += Time.deltaTime * 0.5f;
                foreach(GameObject obj in FadeObject)
                {
                    Color imgColor = obj.GetComponent<Image>().color;
                    imgColor.a = time;
                    obj.GetComponent<Image>().color = imgColor;
                    yield return null;
                }
            }
            foreach (GameObject obj in ActiveObject)
            {
                obj.SetActive(true);
            }
        }
        IEnumerator MoveRoutine(Vector2 destination, float time)
        {
            Vector2 startPos = objPlayer.GetComponent<RectTransform>().anchoredPosition;
            float dtime = 0f;
            while(dtime < time)
            {
                dtime += Time.deltaTime;

                float t = dtime / time;

                objPlayer.GetComponent<RectTransform>().anchoredPosition =
                    Vector2.Lerp(startPos, destination, t);
                yield return null;
            }
            transform.position = destination;
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(FadeIn());
        }        

        public void BtnStart()
        {
            SceneManager.LoadScene("Stage1");
        }

        public void BtnExit()
        {
            Application.Quit();
        }

        //public void BtnRank()
        //{

        //}
        
    
    }
}
