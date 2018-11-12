using UnityEngine;
using UnityEngine.UI;


public class TapEffectController : MonoBehaviour
{
    private const float SCALE = 0.5f;
    private const float EFFECT_Z = 500f;
    private const float INV_SCALE = ((float)1 / SCALE);

    public Canvas canvas;
    public CanvasGroup canvasGroup;
    public Camera tapCamera;
    public TapEffect tapEffect;
    public RawImage rawImage;

    private RenderTexture renderTexture;

    public RenderTexture RT { get { return renderTexture; } }

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        renderTexture = new RenderTexture((int)(Screen.width * SCALE), (int)(Screen.height * SCALE), 0);
        renderTexture.name = "TapEffectRenderTexture";
        tapCamera.targetTexture = renderTexture;
        rawImage.texture = renderTexture;
    }

    public void Play(Vector3 pos)
    {
        tapEffect.Play(pos);
    }

    private void Update()
    {
        Vector2 pos = Vector2.zero;
        bool flag = false;
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) {
            flag = true;
            pos = Input.mousePosition;
        }
#else
            if (Input.touchCount > 0) {
                flag = true;
                 pos = Input.GetTouch(0).position;
            }
#endif
        if (flag) {
            PlayEffect(pos);
        }
    }

    private void PlayEffect(Vector3 pos)
    {
        var pos3 = tapCamera.ScreenToWorldPoint(pos * SCALE + tapCamera.transform.forward * EFFECT_Z);
        Play(pos3);
    }

    private void OnDestroy()
    {
        if (renderTexture != null) {
            Destroy(renderTexture);
        }
    }
}

