using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeLogoSploosh : slideEventCallBack {

    public  delegate void actionStage();
    public static event actionStage Onld1Half;
    public static event actionStage OnMainFull;
    public static event actionStage OnSplooshReady;

    public Image main;
    public Image ld1;
    public Image ld2;
    public Image ld3;
    public Text TitleText;

    [SerializeField]
    private int slideIndex = 0;
    private int inMax = 1;

     public Vector3 mainScale = new Vector3(0,0,1);

    // Use this for initialization

    protected override void CycleSlide(bool forward)
    {
        Debug.Log("message recived");
        if(forward)
        {
            if(slideIndex < inMax)
            {
                slideIndex++;
                Stage1Fire();
            }
            else
            {
                SlideFinish();
            }
        }
        else
        {
          Debug.Log("Cant go back");    
        }
    }

    void OnEnable()
    {
        Sub();
        Onld1Half += Stage2Fire;
        OnMainFull += Stage3Fire;
        OnSplooshReady += Stage4Fire;
    }
    void OnDisable()
    {
        Unsub();
        Onld1Half -= Stage2Fire;
        OnMainFull -= Stage3Fire;
        OnSplooshReady -= Stage4Fire;
    }
    void Awake()
    {
        main.rectTransform.localScale = mainScale;
        TitleText.enabled = false;
    }
	void Start () {
       // StartCoroutine(BarGrow());
       // StartCoroutine(MainGrow());
    }
	
	// Update is called once per frame
	void Update () {      
    }

    public void Stage1Fire()
    {
        StartCoroutine(BarGrow());
    }
    public void Stage2Fire()
    {
        StartCoroutine(MainGrow());
    }
    public void Stage3Fire()
    {
        StartCoroutine(BarColor());
        StartCoroutine(TextContainerSwipe());
    }
    public void Stage4Fire()
    {
        StartCoroutine(TextContainerColorFade());
    }
    public IEnumerator BarGrow()
    {
        bool flag = false;
        while(ld1.fillAmount != 1)
        {
            ld1.fillAmount += 0.01f;

            if (!flag && ld1.fillAmount > 0.5f)
            {
                flag = true;
                if(Onld1Half != null)
                Onld1Half();               
            }
            yield return new WaitForSeconds(0.01f);
        }
        if(OnMainFull != null)
        OnMainFull();
        yield break;
    }
    public IEnumerator BarColor()
    {
        while (ld1.color != Color.black)
        {
            ld1.color = Color.Lerp(ld1.color, Color.black, 0.1f);
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }
    public IEnumerator MainGrow()
    {
        Color newColor = new Color32(78, 208, 234, 255);
        float scale = 0f;
        while(scale < 1.3)
        {
            scale += 0.02f;
            mainScale.Set(scale, scale, 1);
            main.rectTransform.localScale = mainScale;
            yield return new WaitForSeconds(0.01f);
        }
        while(scale > 1)
        {
            scale -= 0.02f;
            mainScale.Set(scale, scale, 1);
            main.rectTransform.localScale = mainScale;
            main.color = Color32.Lerp(main.color, newColor, 0.1f);
            yield return new WaitForSeconds(0.01f);
        }

        yield break;
    }
    public IEnumerator TextContainerSwipe()
    {
        while (ld2.fillAmount < 1)
        {
            ld2.fillAmount += 0.02f;
            ld3.fillAmount += 0.02f;      
            yield return new WaitForSeconds(0.01f);
        }
        OnSplooshReady();
        yield break;

    }
    public IEnumerator TextContainerColorFade()
    {
        TitleText.enabled = true;
        while (ld2.color != Color.black)
        {
            ld2.color = Color.Lerp(ld2.color, Color.black, 0.1f);
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }
}
