using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using UnityEngine;
using Verse.API.Scripting;
using Verse.API.Models;
using Verse.Models.JSON;

namespace Verse.Systems {
    //todo Cache each world with changes
    public static class WorldLoader {
        public static TerrainMap GetTerrainMap(string room) {
            var jsonString = Resources.Load<TextAsset>("Rooms/" + room + "/TerrainMap").text;

            TerrainMap terrainMap = JsonConvert.DeserializeObject<TerrainMap>(jsonString);

            if (terrainMap.Colliders.BoxColliders == null) {
                terrainMap.Colliders.BoxColliders = new List<BoxColliderInfo>();
            }

            return terrainMap;
        }

        public static IList<Thing> GetThingMap(string room) {
            var jsonString = Resources.Load<TextAsset>("Rooms/" + room + "/ObjectMap").text;
            var serializableThings = JsonConvert.DeserializeObject<List<SerializableThing>>(jsonString);
            return serializableThings.Select(sThing => (Thing) sThing).ToList();
        }

        public static IList<ScriptableThing> GetScriptableThings(string room) {
            var jsonString = Resources.Load<TextAsset>("Rooms/" + room + "/ScriptableObjectMap").text;
            var settings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto};

            var sThings =
                JsonConvert.DeserializeObject<List<SerializableScriptableThing>>(jsonString, settings);
            return sThings.Select(sThing => (ScriptableThing) sThing).ToList();
        }
    }
}