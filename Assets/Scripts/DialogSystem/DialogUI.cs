using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI dislpayedText, yesText, noText;
    [SerializeField]
    GameObject dialogElements;

    PlayerMovement playerMovement;
    [SerializeField]
    float maxDialogDistance = 2f;

    AudioSource audioSource;

    [SerializeField]
    float timeNoSkip = 0.5f;

    [SerializeField]
    AudioClip clickSound;

    Dialog currentDialog;

    public static DialogUI instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
        playerMovement = PlayerMovement.Instance;
    }


    Vector3 playerInitPos;
    public void Activate(Dialog d)
    {
        playerInitPos = playerMovement.transform.position;
        currentDialog = d;
        //GameManager.instance.StopGame();
        skipFrame = true;
        //MusicManager.instance.DampenMusic();
        ShowDialog();
        next();
    }

    bool skipFrame = false;
    float elapsedTime = 0f;
    void Update()
    {
        if (Vector3.Distance(playerInitPos, playerMovement.transform.position) > maxDialogDistance)
            BreakDialog();


        if (!skipFrame && elapsedTime > timeNoSkip && currentDialog != null && Input.GetKeyDown(KeyCode.E))
        {
            next();
        }

        skipFrame = false;
        elapsedTime += Time.unscaledDeltaTime;
    }

    public void next()
    {
        var result = currentDialog.next();
        if(result.resultType == DialogResult.ResultType.NextLine)
        {
            dislpayedText.text = result.phrase.line;
        }

        if(result.resultType == DialogResult.ResultType.End)
        {
            dislpayedText.text = string.Empty;
            //GameManager.instance.ContinueGame();
            currentDialog = null;
            //MusicManager.instance.RestoreNormalVolime();

            CloseDialog();
        }

        audioSource.PlayOneShot(clickSound);
        //for not skipping frame unintentially
        elapsedTime = 0f;
    }

    public void BreakDialog()
    {
        dislpayedText.text = string.Empty;
        //GameManager.instance.ContinueGame();
        currentDialog = null;
        //MusicManager.instance.RestoreNormalVolime();

        CloseDialog();
    }

    public void ShowDialog()
    {
        dialogElements.SetActive(true);
    }

    public void CloseDialog()
    {
        dialogElements.SetActive(false);
    }
}
