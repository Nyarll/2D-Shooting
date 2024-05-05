using UnityEditor;
using UnityEngine;
using System.Reflection;

namespace Editor_PlayWindow
{
    [InitializeOnLoad]
    public static class PlayWindow
    {
//        const float GameView_Width = 1920;  // Gameビューの横サイズ
        const float GameView_Width = 1600;  // Gameビューの横サイズ
//        const float GameView_Height = 1080; // Gameビューの縦サイズ 
        const float GameView_Height = 900; // Gameビューの縦サイズ 

        static PlayWindow()
        {
            // Unityプレイモード変更時に関数を登録
            EditorApplication.playModeStateChanged += OnChangedPlayMode;
        }

        static void OnChangedPlayMode(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                // ～Unity再生時～

                // Gameビューを表示、取得
                var typeView = Assembly.Load("UnityEditor").GetType("UnityEditor.GameView");
                var gameView = EditorWindow.GetWindow(typeView, false, "Game", false);

                // Gameビューを表示する位置を計算
                float posX = Screen.currentResolution.width / 2 - GameView_Width / 2;
                float posY = Screen.currentResolution.height / 2 - GameView_Height / 2;

                // Gameビューの位置とサイズを設定
                gameView.position = new Rect(posX, posY, GameView_Width, GameView_Height);
            }
            else if (state == PlayModeStateChange.EnteredEditMode)
            {
                // ～Unity再生終了時～

                // Gameビューを表示、取得
                var typeView = Assembly.Load("UnityEditor").GetType("UnityEditor.GameView");
                var gameView = EditorWindow.GetWindow(typeView, false, "Game", false);

                // Gameビューを閉じる
                gameView.Close();
            }
        }
    }
}