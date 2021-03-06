using System.IO;
using UnityEngine;

namespace Verse.Utilities {
    public static class FileConstants {
        public static string ModsFolder = Path.Combine(Application.dataPath, @"../Mods");
        public static string DefsFolderName = "Defs";
        public static string TileDefsFolder = Path.Combine(DefsFolderName, "Tiles");
        public static string TileObjectDefsFolder = Path.Combine(DefsFolderName, "TileObjects");
        public static string TileObjectEntitiesDefsFolder = Path.Combine(DefsFolderName, "TileObjectEntities");
        public static string RoomsFolderName = "Rooms";
        public static string RoomPatchesFolder = Path.Combine(RoomsFolderName, "Patches");
        public static string RoomDefinitionFileName = "MapDefinition.json";
        public static string RoomTileMapFileName = "TileMap.json";
        public static string RoomTileObjectMapFileName = "ObjectMap.json";
        public static string RoomTileObjectEntityMapFileName = "ScriptableObjectMap.json";
        public static string ModPackageFileName = "ModPackage.json";
    }
}