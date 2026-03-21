# NTPilot

Windows の時刻同期サービス (W32Time) を管理するための軽量な GUI ツールです。

## 機能

- **ステータス確認** — W32Time サービスの状態、同期ソース、ストラタムなどをリアルタイム表示
- **クライアント設定** — NTP サーバーアドレスやポーリング間隔の変更
- **サーバー設定** — NTP サーバー機能の有効化/無効化
- **詳細設定** — W32Time の詳細パラメータの編集
- **構成ビュー** — 現在のレジストリ設定と `w32tm` 出力の確認
- **ダーク/ライトモード** — Windows のシステムテーマに自動追従
- **多言語対応** — English, 日本語, Deutsch, Español, Français, Italiano, 한국어, Português (Brasil), Русский, 中文

## 動作要件

- Windows 8.1 / Windows Server 2012 R2 以降
- .NET Framework 4.8.1
- 管理者権限（W32Time サービスの制御にはUAC昇格が必要です）

## インストール

[Releases](https://github.com/Yanai-Taketo/NTPilot/releases) ページからお使いの環境に合った実行ファイルをダウンロードしてください。

| ファイル | アーキテクチャ |
|---|---|
| `NTPilot_x64.exe` | 64-bit (x64) |
| `NTPilot_x86.exe` | 32-bit (x86) |
| `NTPilot_ARM64.exe` | ARM64 |

インストール不要で、ダウンロードした exe を実行するだけで使用できます。

## ビルド

```bash
dotnet restore NTPilot.vbproj
dotnet build NTPilot.vbproj -c Release -p:Platform=x64
```

.NET SDK 9.0 以降が必要です（.NET Framework 4.8.1 をターゲットとしています）。

## ライセンス

このプロジェクトはライセンスが未指定です。
