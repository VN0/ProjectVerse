using System;
using System.Collections.Generic;
using Verse.API.Scripting;

namespace Verse.Models {
    public class ScriptAtlas {
        private static Dictionary<String, IThingScript> _scriptAtlas;

        public static void InitializeAtlas() {
            if (_scriptAtlas == null) {
                CreateAtlas();
            }
        }

        public static IThingScript GetScript(String scriptName) {
            InitializeAtlas();
            return _scriptAtlas[scriptName];
        }

        private static void CreateAtlas() {
            IThingScript script = new DoorTrigger();
            _scriptAtlas = new Dictionary<string, IThingScript>();
            var name = script.GetType().FullName;
            _scriptAtlas.Add(name, script);
        }
    }
}