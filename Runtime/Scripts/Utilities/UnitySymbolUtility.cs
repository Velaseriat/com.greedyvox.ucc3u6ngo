using UnityEditor;
using UnityEditor.Build;

namespace GreedyVox.NetCode.Utilities
{
    public static class UnitySymbolUtility
    {
        public const string UccAiBD = "ULTIMATE_CHARACTER_CONTROLLER_MULTIPLAYER_BD_AI";
#if UNITY_EDITOR
        public static string[] GetSymbols() =>
        PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup)).Split(';');
        public static void SetSymbols(string[] symbols) =>
        PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup), string.Join(";", symbols));
        public static bool HasSymbol(string symbol) =>
        PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup)).Contains(symbol);
        public static void AddSymbol(string symbol)
        {
            var current = PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup));
            // Add the new symbol to the existing symbols
            if (!current.Contains(symbol))
                PlayerSettings.SetScriptingDefineSymbols(
                    NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup), $"{current};{symbol}"
                );
        }
        public static void RemoveSymbol(string symbol)
        {
            var current = PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup));
            // Remove the specified symbol and remove any duplicate semicolons
            if (current.Contains(symbol))
                PlayerSettings.SetScriptingDefineSymbols(
                    NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup), current.Replace(symbol, "").Replace(";;", ";")
                );
        }
#endif
    }
}