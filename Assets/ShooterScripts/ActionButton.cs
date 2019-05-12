using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ShooterScripts {
    class ActionButton {

        private string key_string;
        public string KeyString {
            get {
                return key_string;
            }
        }
        private KeyCode key_code;
        public KeyCode KeyCode {
            get {
                return key_code;
            }
        }

        public ActionButton(string key_string, KeyCode key_code) {
            this.key_string = key_string;
            this.key_code = key_code;
        }
    }
}
