using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubiStatueEyeController : MonoBehaviour
{

    public MeshRenderer[] meshEyesAnubiStatue;
    public GemInteractionEnigma[] gemOrder;
    public Color[] orderColorEye;
    public Color colorEyeFinal;

    private List<GemInteractionEnigma> gemInsered = new List<GemInteractionEnigma>();
    private Color m_ColorDefaut;
    private int m_NextGem;
    private bool m_SequenceCorrect = true;
    private Material m_MaterialLeftEye, m_MaterialRightEye;
    private bool sequenceCorrect;

    void Start()
    {
        m_MaterialLeftEye = meshEyesAnubiStatue[0].material;
        m_MaterialRightEye = meshEyesAnubiStatue[1].material;
        m_ColorDefaut = m_MaterialLeftEye.color;
        m_NextGem = 0;
        sequenceCorrect = true;

        AnubiSarcophagusEnigma.OnEnigmaWrong += SetDefaultStatus;
    }

    public void GemSwitched(GemInteractionEnigma gem)
    {
        if (gem.gameObject == gemOrder[m_NextGem].gameObject && sequenceCorrect)
        {
            if (++m_NextGem == gemOrder.Length)
            {
                ChangeEyeColor(colorEyeFinal);
                Destroy(this);
            }
            else
            {
                ChangeEyeColor(orderColorEye[m_NextGem]);
            }
        }
        else
        {
            sequenceCorrect = false;
            ChangeEyeColor(m_ColorDefaut);
            m_NextGem = 0;
        }
    }

    public void SetDefaultStatus()
    {
        sequenceCorrect = true;
        ChangeEyeColor(m_ColorDefaut);
        m_NextGem = 0;
    }

    private void ChangeEyeColor(Color color)
    {
        m_MaterialRightEye.SetColor("_Color", color);
        m_MaterialRightEye.SetColor("_EmissionColor", color);
        m_MaterialLeftEye.SetColor("_Color", color);
        m_MaterialLeftEye.SetColor("_EmissionColor", color);
    }
}
