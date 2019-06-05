using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLeverPrisonController : MonoBehaviour {

	public GameObject BlueSphere;
	public GameObject MagentaSphere;
	public GameObject YellowSphere;
	public GameObject OrangeSphere;
	public GameObject RedSphere;
	public GameObject GreenSphere;
	public GameObject WhiteSphere;
	public GameObject BlackSphere;
	public IronLeverBaseInteraction ironLever;
	public int numberSphereToOpen = 8;
    public bool IsOpenDebug = false;

	private int m_NumberSphereActivated;

	void Start()
    {
		m_NumberSphereActivated = 0;
        if (IsOpenDebug)
            ironLever.IsLocked = false;
	}

	public void SphereAdded(PickObjectInteraction sphere) {
		PickSphereInteraction sphereInteraction = (PickSphereInteraction) sphere;
		if (sphereInteraction != null) {
			GameObject g = null;
			switch (sphereInteraction.GetColorSphere) {
				case PickSphereInteraction.ColorSphere.BLUE:
					g = BlueSphere;
					break;
			case PickSphereInteraction.ColorSphere.MAGENTA:
				g = MagentaSphere;
					break;
			case PickSphereInteraction.ColorSphere.YELLOW:
				g = YellowSphere;
					break;
			case PickSphereInteraction.ColorSphere.ORANGE:
				g = OrangeSphere;
					break;
			case PickSphereInteraction.ColorSphere.RED:
				g = RedSphere;
					break;
			case PickSphereInteraction.ColorSphere.GREEN:
				g = GreenSphere;
					break;
			case PickSphereInteraction.ColorSphere.WHITE:
				g = WhiteSphere;
					break;
			case PickSphereInteraction.ColorSphere.BLACK:
				g = BlackSphere;
					break;
			}

			if (g != null) {
				(g.GetComponent ("Halo") as Behaviour).enabled = true;
				m_NumberSphereActivated++;
				if (m_NumberSphereActivated >= numberSphereToOpen) {
					ironLever.IsLocked = false;
					Destroy (this);
				}
			}
		}
	}
}
