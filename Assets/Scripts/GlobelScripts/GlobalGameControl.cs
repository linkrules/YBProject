using UnityEngine;
using System.Collections;

public class GlobalGameControl {

    #region Global Game State
    public enum gameState_t {
        GAMESTATE_NONE,
        GAMESTATE_PLAY,
        GAMESTATE_PAUSE,
    };

    public gameState_t globalGameState = gameState_t.GAMESTATE_NONE;

    public gameState_t GetGameState() {
        return globalGameState;
    }

    public void SetGameState(gameState_t gameState) {
        globalGameState = gameState;
    }

    #endregion

    #region Init Game
    public void InitGameDisplay() {
        Screen.showCursor = false;
    }

    #endregion


}
