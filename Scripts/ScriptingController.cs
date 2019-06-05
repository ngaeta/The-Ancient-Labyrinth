using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptingController : MonoBehaviour {

	private static List<IScripting> scripts;

	void Start() {
		scripts = new List<IScripting> ();
	}

	public static void StopAllScripts () {
		foreach (IScripting script in scripts)
			script.StopScript ();
	}

	public static void StartScript(IScripting script) {
		scripts.Add (script);
		script.StartScript ();
	}
}
