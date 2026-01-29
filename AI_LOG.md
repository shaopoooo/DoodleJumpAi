# 🤖 AI Development Log - DoodleJumpClone

> **說明**：本文件記錄了專案的開發歷程、關鍵決策以及 AI 協作紀錄。
> **維護者**：Human User & Antigravity Agent
> **規則**：請依照 `PROJECT_RULES.md` 中的 [收工協議] 格式追加內容。

---

## 🛠️ 開發日誌 (Development History)

### 📅 2026-01-28 17:07:21 核心機制開發 (Core Mechanics)
- **對話**: 建立一個 Unity 2D Doodle Jump 複製版遊戲。需包含以下核心機制：
  1. **角色控制 (Player)**：使用 Rigidbody2D 與新的 Input System (Keyboard.current) 控制左右移動，碰到平台時自動跳躍。並處理螢幕左右環繞 (Screen Wrap)。
  2. **地板生成 (Level Generator)**：使用 Object Pooling 技術生成無限平台，避免與銷毀物件造成的效能浪費。初始生成需確保角色下方有平台。
  3. **平台物理 (Platform)**：平台需設定為單向碰撞 (PlatformEffector2D)，Surface Arc 設為 150 度以避免卡住側邊。
  4. **攝影機 (Camera)**：攝影機僅隨玩家向上移動，不向下捲動。
  5. **遊戲結束 (Game Over)**：當角色掉出攝影機畫面下方 (Camera Y - 10) 時，重載場景。
  6. **文件**：生成詳細的雙語 (中英) `walkthrough.md`，並將完整內容嵌入到 `AI_LOG.md` 中。遵守 `PROJECT_RULES.md` 的開發規範 (SerializeField private, TryGetComponent)。
- **變更**:
  - 實作角色跳躍與移動邏輯 (Player Movement & Jump)
  - 實作地板生成器與物件池 (Level Generator with Object Pooling)
  - 實作攝影機跟隨 (Camera Follow)
  - 實作死亡判定與場景重載 (Game Over logic)
  - 製作雙語版遊玩指引 (Bilingual Walkthrough)
- **技術**:
  - `Rigidbody2D` & `FixedUpdate` (Physics)
  - `Input System` (Keyboard.current)
  - `Object Pooling` (List<GameObject>)
  - `PlatformEffector2D` (One-way collision)
  - `SceneManager.LoadScene` (Restart)
- **狀態**: 原本是 [專案初始化] -> 現在變成 [核心機制開發完成]
- **步驟**:
    # Doodle Jump Clone - Setup Guide 🚀

    Here is the complete guide to setting up your game scene for the Doodle Jump Clone.
    > [!NOTE]
    > 這是 Doodle Jump 複製版遊戲場景的完整設置指南。

    ## Prerequisites

    > [!NOTE]
    > 前置作業

    - Ensure you have the `Assets/Scripts` folder with `Player.cs`, `Platform.cs`, `LevelGenerator.cs`, and `CameraFollow.cs`.
      > [!NOTE]
      > 確認 `Assets/Scripts` 資料夾中已有上述四個腳本檔案。

    ## Step 1: Create the Player

    > [!NOTE]
    > 建立玩家角色

    1.  **Create Sprite**: Right-click Hierarchy > **2D Object** > **Sprites** > **Square**. Name it `Player`.
        > [!NOTE]
        > **建立精靈**: 在 Hierarchy 點右鍵 > **2D Object** > **Sprites** > **Square**。命名為 `Player`。
    2.  **Add Components**: Add `Rigidbody 2D` and `Box Collider 2D`.
        > [!NOTE]
        > **新增元件**: 加入 `Rigidbody 2D` 與 `Box Collider 2D`。
    3.  **Config Rigidbody**: Expand **Constraints** > Check **Freeze Rotation Z**.
        > [!NOTE]
        > **設定剛體**: 展開 **Constraints** > 勾選 **Freeze Rotation Z** (凍結 Z 軸旋轉)。
    4.  **Add Script**: Add the `Player` script.
        > [!NOTE]
        > **加入腳本**: 加入 `Player` 腳本。

    ### ✅ Verification

    > [!NOTE]
    > 檢查

    - **Inspector**: Has Rigidbody 2D (Frozen Z), Box Collider 2D, Player Script.
      > [!NOTE]
      > **Inspector**: 應有 Rigidbody 2D (已凍結 Z)、Box Collider 2D、Player 腳本。

    ## Step 2: Create the Platform Prefab

    > [!NOTE]
    > 建立平台預製物件

    1.  **Create Sprite**: Right-click Hierarchy > **2D Object** > **Sprites** > **Square**. Name it `Platform`.
        > [!NOTE]
        > **建立精靈**: 在 Hierarchy 點右鍵 > **2D Object** > **Sprites** > **Square**。命名為 `Platform`。
    2.  **Scale**: Set Transform **Scale X** to `3` and **Scale Y** to `0.5`.
        > [!NOTE]
        > **縮放**: 將 Transform **Scale X** 設為 `3`，**Scale Y** 設為 `0.5`。
    3.  **Add Components**: Add `Box Collider 2D`, `Platform Effector 2D`, and `Platform` script.
        > [!NOTE]
        > **新增元件**: 加入 `Box Collider 2D`、`Platform Effector 2D` 與 `Platform` 腳本。
    4.  **Config Collider**: In `Box Collider 2D`, check **Used By Effector**.
        > [!NOTE]
        > **設定碰撞器**: 在 `Box Collider 2D` 中，勾選 **Used By Effector** (被效應器使用)。
    5.  **Config Effector**: In `Platform Effector 2D`, set **Surface Arc** to `150`.
        > [!NOTE]
        > **設定效應器**: 在 `Platform Effector 2D` 中，將 **Surface Arc** 設為 `150`。
    6.  **Prefab**: Drag `Platform` from Hierarchy to Project Window. Delete it from Hierarchy.
        > [!NOTE]
        > **預製物件**: 將 `Platform` 拖入 Project 視窗變成 Prefab，然後從 Hierarchy 刪除它。

    ### ✅ Verification

    > [!NOTE]
    > 檢查

    - **Project**: Blue `Platform` asset exists.
      > [!NOTE]
      > **Project**: 看到藍色的 `Platform` 檔案。
    - **Inspector**: Has `Box Collider 2D` (Used By Effector checked), `Platform Effector 2D`, and Script.
      > [!NOTE]
      > **Inspector**: 應有 `Box Collider 2D` (已勾選 Used By Effector)、`Platform Effector 2D` 和腳本。

    ## Step 3: Setup Level Generator

    > [!NOTE]
    > 設置關卡生成器

    1.  **Create Manager**: Create Empty Object. Name it `LevelGenerator`.
        > [!NOTE]
        > **建立管理器**: 建立空物件，命名為 `LevelGenerator`。
    2.  **Add Script**: Add `Level Generator` script.
        > [!NOTE]
        > **加入腳本**: 加入 `Level Generator` 腳本。
    3.  **Config**: Drag `Platform` prefab to "Platform Prefab" slot. "Number Of Platforms" is 20.
        > [!NOTE]
        > **設定**: 將 `Platform` Prefab 拖入 "Platform Prefab" 欄位。"Number Of Platforms" 預設為 20。

    ### ✅ Verification

    > [!NOTE]
    > 檢查

    - **Inspector**: Prefab assigned (not None).
      > [!NOTE]
      > **Inspector**: Prefab 已指派 (非 None)。

    ## Step 4: Setup Camera Follow

    > [!NOTE]
    > 設置攝影機跟隨

    1.  **Select Camera**: Click `Main Camera`.
        > [!NOTE]
        > **選取攝影機**: 點擊 `Main Camera`。
    2.  **Add Script**: Add `Camera Follow` script.
        > [!NOTE]
        > **加入腳本**: 加入 `Camera Follow` 腳本。
    3.  **Config**: Drag `Player` object to "Target" slot.
        > [!NOTE]
        > **設定**: 將 `Player` 物件拖入 "Target" 欄位。

    ### ✅ Verification

    > [!NOTE]
    > 檢查

    - **Inspector**: Target is Player.
      > [!NOTE]
      > **Inspector**: Target 是 Player。
    - **Gameplay**: Camera moves UP when player climbs.
      > [!NOTE]
      > **Gameplay**: 當玩家往上爬時，攝影機跟著往上移動。
    - **One-Way**: Camera does NOT move down when player falls.
      > [!NOTE]
      > **One-Way**: 當玩家往下掉時，攝影機不會跟著往下移動。

    ## Step 5: Play & Test

    > [!NOTE]
    > 遊玩與測試

    1.  **Start**: Press Play.
        > [!NOTE]
        > **開始**: 按下 Play。
    2.  **Controls**: Use Arrow Keys or A/D. Jump is automatic.
        > [!NOTE]
        > **操作**: 使用方向鍵或 A/D。跳躍是自動的。

    ### ✅ Final Verification

    > [!NOTE]
    > 最終檢查

    - **Screen Wrap**: Move off-screen -> appear on other side.
      > [!NOTE]
      > **螢幕環繞**: 移出螢幕 -> 從另一側出現。
    - **Infinite Level**: Platforms keep appearing as you go up.
      > [!NOTE]
      > **無限關卡**: 往上爬時平台持續出現。
    - **Pool Count**: `Platform(Clone)` count in Hierarchy stays ~20.
      > [!NOTE]
      > **物件池數量**: Hierarchy 中的 `Platform(Clone)` 數量維持在及 20 個左右。
    - **Game Over**: Fall off the bottom -> Scene reloads (restart).
      > [!NOTE]
      > **遊戲結束**: 掉出畫面下方 -> 場景重新載入 (重新開始)。

### 📅 2026-01-28 15:30:00 專案初始化 (Project Initialization)
- **對話**: 建立並設定 Unity 2D URP 專案，包含完成此專案所需之基礎架構。
  1. **環境設定**：安裝 `unity-mcp` 並測試 Server 連線。
  2. **版本控制**：配置標準 `.gitignore` 與 Git LFS。
  3. **自動化規範**：建立 `PROJECT_RULES.md` 定義開發協議 (狀態更新、收工結算) 與技術棧 (URP, C#, [SerializeField] private)。
- **變更 (Changes)**：
  - 建立 Unity 2D URP 專案。
  - 安裝 `unity-mcp` 套件並完成 Server 連線。
  - 設定 `.gitignore` 與 Git LFS 以符合版本控制標準。
  - 建立 `PROJECT_RULES.md` 定義自動化開發協議。
- **技術決策 (Decisions)**：
  - 選擇 **Universal Render Pipeline (URP)** 以獲得最佳手機效能與 2D 光影支援。
  - 採用 **Git + GitHub** 進行版控，忽略 Library/Temp 等快取資料夾。
- **狀態**：✅ 環境建置完成，準備開始開發角色控制。
