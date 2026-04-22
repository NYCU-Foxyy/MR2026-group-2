using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DialogManager : MonoBehaviour {
    public struct Dialog {
        public Subtitle subtitle;
        public AudioClip audioClip;
    }

    private Dictionary<string, Dialog> dialogs;
    public string directory;

    void Awake() {
        // Load dialog files
        foreach (string path in Directory.EnumerateFiles(directory)) {
            string name = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);
            if (extension == "txt") {
                Dialog dialog;
                if (dialogs.ContainsKey(name)) {
                    dialog = dialogs[name];
                    dialog.subtitle = new Subtitle(path);
                    dialogs[name] = dialog;
                } else {
                    dialog = new Dialog {
                        subtitle = new Subtitle(path)
                    };
                    dialogs.Add(name, dialog);
                }
            } else {
                AudioClip clip = Resources.Load<AudioClip>(path);
                Dialog dialog;
                if (dialogs.ContainsKey(name)) {
                    dialog = dialogs[name];
                    dialog.audioClip = clip;
                    dialogs[name] = dialog;
                } else {
                    dialog = new Dialog {
                        audioClip = clip
                    };
                    dialogs.Add(name, dialog);
                }
            }
        }
    }
}
