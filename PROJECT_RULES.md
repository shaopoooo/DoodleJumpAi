# 專案：DoodleJumpClone (2D Vertical Platformer)

## 1. 專案狀態 (Project Status)
> [!IMPORTANT]
> Agent 必須在每次 [/finish] 指令後更新此區塊。
- **目前階段**: 核心機制開發 (Core Mechanics)
- **當前任務**: 核心機制開發完成 (All Core Mechanics Completed)
- **待辦清單**:
  - [x] 角色跳躍邏輯 (Rigidbody2D)
  - [x] 地板生成器 (Object Pooling)
  - [x] 攝影機跟隨 (Camera Follow)
  - [x] 死亡判定 (Game Over)

## 2. 技術規範 (Tech Stack)
- **Engine**: Unity 6 / 2022.3 LTS (URP)
- **Language**: C#
- **Pattern**: 
  - 變數優先使用 `[SerializeField] private` 而非 `public`。
  - 物理運算必須在 `FixedUpdate`。
  - 優先使用 `TryGetComponent` 避免 Null Reference。
  - Walkthrough文件: 使用中英文混合，中文用藍色標示，英文用白色標示，在每個步驟後增加簡短的驗證結果。

## 3. 自動化協議 (Automation Protocols)

### 🟢 狀態更新協議 (Trigger: "/update" or "更新狀態")
當用戶要求更新狀態時：
1. 分析剛剛完成的程式碼變更。
2. 編輯本檔案 (`PROJECT_RULES.md`) 的 [Project Status] 區塊。
3. 將已完成的項目打勾 `[x]`，並更新 [當前任務]。

### 🔴 收工結算協議 (Trigger: "/finish" or "收工")
當用戶輸入 "/finish" 時，請連續執行以下動作：
1. **執行 [狀態更新協議]**：更新本檔案的進度。
2. **生成開發日誌**：
   - 讀取本次對話的關鍵決策與 Prompt。
   - 將總結 **Append (追加寫入)** 到 `AI_LOG.md` 檔案裡頭依照時間由新到智舊排序（若無則建立）。
   - 日誌格式：
     ```markdown
     ### 📅 YYYY-MM-DD HH:MM:SS {功能名稱}
     - **對話**: {本次對話的關鍵決策與 Prompt，以可以重現為原則}
     - **變更**: {做了什麼}
     - **技術**: {用了什麼 Unity API}
     - **狀態**: {原本是 A，現在變成 B}
     - **步驟**: {walkthrough}
     ```
3. **提醒我git commit**