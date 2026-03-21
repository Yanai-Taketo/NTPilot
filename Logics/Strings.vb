''' <summary>
''' All UI strings for 10 languages, embedded directly (no satellite DLLs → single exe).
''' Use T("key") to get the current language string.
''' Helper function D() constructs inner dictionaries to avoid deeply-nested initializers.
''' </summary>
Public Module Strings

    Private _lang As String = "en"

    Public Sub SetLanguage(lang As String)
        _lang = If(String.IsNullOrEmpty(lang), "en", lang)
    End Sub

    ''' <summary>Returns the translated string for the given key.</summary>
    Public Function T(key As String) As String
        Dim table As Dictionary(Of String, String) = Nothing
        If _table.TryGetValue(key, table) Then
            Dim val As String = Nothing
            If table.TryGetValue(_lang, val) Then Return val
            If table.TryGetValue("en", val) Then Return val
        End If
        Return key
    End Function

    ' -------------------------------------------------------------- Helpers

    ''' <summary>Creates a 2-language dictionary (en+ja) for tooltips; T() falls back to "en" for other languages.</summary>
    Private Function Tip(en As String, ja As String) As Dictionary(Of String, String)
        Return New Dictionary(Of String, String) From {{"en", en}, {"ja", ja}}
    End Function

    ''' <summary>Creates a per-language dictionary from ordered args (en,ja,de,es,fr,it,ko,pt-BR,ru,zh).</summary>
    Private Function D(en As String, ja As String, de As String, es As String,
                       fr As String, it As String, ko As String, ptBR As String,
                       ru As String, zh As String) As Dictionary(Of String, String)
        Return New Dictionary(Of String, String) From {
            {"en", en}, {"ja", ja}, {"de", de}, {"es", es},
            {"fr", fr}, {"it", it}, {"ko", ko}, {"pt-BR", ptBR},
            {"ru", ru}, {"zh", zh}
        }
    End Function

    Private ReadOnly _table As Dictionary(Of String, Dictionary(Of String, String)) = InitTable()

    Private Function InitTable() As Dictionary(Of String, Dictionary(Of String, String))
        Dim t As New Dictionary(Of String, Dictionary(Of String, String))

        ' ---- Application
        t("App.Title") = D("NTPilot", "NTPilot", "NTPilot", "NTPilot",
                           "NTPilot", "NTPilot", "NTPilot", "NTPilot", "NTPilot", "NTPilot")
        t("App.Subtitle") = D(
            "NTP Service Manager",
            "NTP サービスマネージャー",
            "NTP-Dienstverwaltung",
            "Administrador de servicios NTP",
            "Gestionnaire de service NTP",
            "Gestore servizio NTP",
            "NTP 서비스 관리자",
            "Gerenciador de serviço NTP",
            "Менеджер службы NTP",
            "NTP 服务管理器")

        ' ---- Navigation
        t("Nav.Status") = D("Status", "状態", "Status", "Estado",
                            "État", "Stato", "상태", "Status", "Состояние", "状态")
        t("Nav.Client") = D("Client", "クライアント", "Client", "Cliente",
                            "Client", "Client", "클라이언트", "Cliente", "Клиент", "客户端")
        t("Nav.Server") = D("Server", "サーバー", "Server", "Servidor",
                            "Serveur", "Server", "서버", "Servidor", "Сервер", "服务器")
        t("Nav.Advanced") = D("Advanced", "詳細設定", "Erweitert", "Avanzado",
                              "Avancé", "Avanzate", "고급", "Avançado", "Дополнительно", "高级")
        t("Nav.ConfigView") = D(
            "Config View", "設定確認", "Konfigurationsansicht", "Ver configuración",
            "Vue configuration", "Vista configurazione", "설정 보기",
            "Ver configuração", "Конфигурация", "配置视图")

        ' ---- Status page
        t("Status.Title") = D("Status", "状態", "Status", "Estado",
                              "État", "Stato", "상태", "Status", "Состояние", "状态")
        t("Status.Card.Service") = D(
            "Windows Time Service", "Windows Time サービス", "Windows-Zeitdienst",
            "Servicio de hora de Windows", "Service de temps Windows",
            "Servizio ora di Windows", "Windows 시간 서비스",
            "Serviço de hora do Windows", "Служба времени Windows", "Windows 时间服务")
        t("Status.ServiceStatus") = D(
            "Service Status", "サービス状態", "Dienststatus",
            "Estado del servicio", "État du service", "Stato servizio",
            "서비스 상태", "Status do serviço", "Статус службы", "服务状态")
        t("Status.Running") = D("Running", "実行中", "Wird ausgeführt", "En ejecución",
                                "En cours d'exécution", "In esecuzione", "실행 중",
                                "Em execução", "Запущена", "正在运行")
        t("Status.Stopped") = D("Stopped", "停止中", "Angehalten", "Detenido",
                                "Arrêté", "Arrestato", "중지됨", "Parado", "Остановлена", "已停止")
        t("Status.Unknown") = D("Unknown", "不明", "Unbekannt", "Desconocido",
                                "Inconnu", "Sconosciuto", "알 수 없음",
                                "Desconhecido", "Неизвестно", "未知")
        t("Status.BtnStart") = D("Start", "開始", "Starten", "Iniciar",
                                  "Démarrer", "Avvia", "시작", "Iniciar", "Запустить", "启动")
        t("Status.BtnStop") = D("Stop", "停止", "Beenden", "Detener",
                                 "Arrêter", "Arresta", "중지", "Parar", "Остановить", "停止")
        t("Status.BtnRestart") = D("Restart", "再起動", "Neu starten", "Reiniciar",
                                    "Redémarrer", "Riavvia", "다시 시작",
                                    "Reiniciar", "Перезапустить", "重启")
        t("Status.Card.NtpStatus") = D(
            "NTP Status", "NTP ステータス", "NTP-Status", "Estado NTP",
            "Statut NTP", "Stato NTP", "NTP 상태", "Status NTP", "Статус NTP", "NTP 状态")
        t("Status.Col.Key") = D("Key", "キー", "Schlüssel", "Clave",
                                 "Clé", "Chiave", "키", "Chave", "Параметр", "键")
        t("Status.Col.Value") = D("Value", "値", "Wert", "Valor",
                                   "Valeur", "Valore", "값", "Valor", "Значение", "值")
        t("Status.Card.Peers") = D(
            "Peer List", "ピアリスト", "Peer-Liste", "Lista de pares",
            "Liste des pairs", "Elenco peer", "피어 목록",
            "Lista de pares", "Список пиров", "对等节点列表")
        t("Status.Col.Server") = D("Server", "サーバー", "Server", "Servidor",
                                    "Serveur", "Server", "서버", "Servidor", "Сервер", "服务器")
        t("Status.Col.State") = D("State", "状態", "Zustand", "Estado",
                                   "État", "Stato", "상태", "Estado", "Состояние", "状态")
        t("Status.Col.Stratum") = D("Stratum", "層", "Stratum", "Estrato",
                                     "Stratum", "Stratum", "스트라텀", "Stratum", "Страт", "层")
        t("Status.Col.Offset") = D("Offset (s)", "オフセット (s)", "Versatz (s)", "Desviación (s)",
                                    "Décalage (s)", "Offset (s)", "오프셋 (s)",
                                    "Offset (s)", "Смещение (с)", "偏移 (s)")
        t("Status.Col.RootDelay") = D(
            "Root Delay (s)", "ルート遅延 (s)", "Stammverzögerung (s)", "Retardo raíz (s)",
            "Délai racine (s)", "Ritardo root (s)", "루트 지연 (s)",
            "Atraso raiz (s)", "Корн. задержка (с)", "根延迟 (s)")
        t("Status.Col.RootDisp") = D(
            "Root Disp. (s)", "ルート分散 (s)", "Stammstreuung (s)", "Dispersión raíz (s)",
            "Dispersion racine (s)", "Dispersione root (s)", "루트 분산 (s)",
            "Dispersão raiz (s)", "Корн. дисперсия (с)", "根分散 (s)")
        t("Status.BtnSyncNow") = D(
            "Sync Now", "今すぐ同期", "Jetzt synchronisieren", "Sincronizar ahora",
            "Synchroniser maintenant", "Sincronizza ora", "지금 동기화",
            "Sincronizar agora", "Синхронизировать", "立即同步")
        t("Status.BtnRefresh") = D("Refresh", "更新", "Aktualisieren", "Actualizar",
                                    "Actualiser", "Aggiorna", "새로 고침",
                                    "Atualizar", "Обновить", "刷新")

        ' ---- Client page
        t("Client.Title") = D(
            "Client Settings", "クライアント設定", "Client-Einstellungen",
            "Configuración de cliente", "Paramètres client",
            "Impostazioni client", "클라이언트 설정",
            "Configurações do cliente", "Настройки клиента", "客户端设置")
        t("Client.Card.Basic") = D(
            "Basic Settings", "基本設定", "Grundeinstellungen", "Configuración básica",
            "Paramètres de base", "Impostazioni di base", "기본 설정",
            "Configurações básicas", "Основные настройки", "基本设置")
        t("Client.Enabled") = D(
            "Enable NTP Client", "NTP クライアントを有効にする",
            "NTP-Client aktivieren", "Habilitar cliente NTP",
            "Activer le client NTP", "Abilita client NTP",
            "NTP 클라이언트 사용", "Habilitar cliente NTP",
            "Включить NTP-клиент", "启用 NTP 客户端")
        t("Client.SyncType") = D(
            "Sync Type", "同期タイプ", "Synchronisierungstyp", "Tipo de sincronización",
            "Type de synchronisation", "Tipo di sincronizzazione", "동기화 유형",
            "Tipo de sincronização", "Тип синхронизации", "同步类型")
        t("Client.NtpServers") = D(
            "NTP Servers", "NTP サーバー", "NTP-Server", "Servidores NTP",
            "Serveurs NTP", "Server NTP", "NTP 서버",
            "Servidores NTP", "NTP-серверы", "NTP 服务器")
        t("Client.Card.Flags") = D(
            "Flags Helper", "フラグヘルパー", "Flags-Hilfe", "Ayuda de banderas",
            "Aide drapeaux", "Assistente flag", "플래그 도우미",
            "Auxiliar de flags", "Помощник флагов", "标志助手")
        t("Client.Flag8") = D("0x8 – SpecialInterval", "0x8 – SpecialInterval",
                               "0x8 – SpecialInterval", "0x8 – SpecialInterval",
                               "0x8 – SpecialInterval", "0x8 – SpecialInterval",
                               "0x8 – SpecialInterval", "0x8 – SpecialInterval",
                               "0x8 – SpecialInterval", "0x8 – SpecialInterval")
        t("Client.Flag4") = D("0x4 – UseAsFallbackOnly", "0x4 – UseAsFallbackOnly",
                               "0x4 – UseAsFallbackOnly", "0x4 – UseAsFallbackOnly",
                               "0x4 – UseAsFallbackOnly", "0x4 – UseAsFallbackOnly",
                               "0x4 – UseAsFallbackOnly", "0x4 – UseAsFallbackOnly",
                               "0x4 – UseAsFallbackOnly", "0x4 – UseAsFallbackOnly")
        t("Client.Flag1") = D("0x1 – SymmetricActive", "0x1 – SymmetricActive",
                               "0x1 – SymmetricActive", "0x1 – SymmetricActive",
                               "0x1 – SymmetricActive", "0x1 – SymmetricActive",
                               "0x1 – SymmetricActive", "0x1 – SymmetricActive",
                               "0x1 – SymmetricActive", "0x1 – SymmetricActive")
        t("Client.CombinedFlag") = D("Combined flag:", "合成フラグ:", "Kombiniertes Flag:",
                                      "Bandera combinada:", "Drapeau combiné:", "Flag combinato:",
                                      "결합된 플래그:", "Flag combinado:", "Составной флаг:", "组合标志:")
        t("Client.Card.Polling") = D(
            "Polling Intervals", "ポーリング間隔", "Abfrageintervalle",
            "Intervalos de sondeo", "Intervalles d'interrogation",
            "Intervalli di polling", "폴링 간격",
            "Intervalos de sondagem", "Интервалы опроса", "轮询间隔")
        t("Client.UpdateInterval") = D(
            "Update Interval (100ns)", "更新間隔 (100ns)", "Aktualisierungsintervall (100ns)",
            "Intervalo de actualización (100ns)", "Intervalle de mise à jour (100ns)",
            "Intervallo di aggiornamento (100ns)", "업데이트 간격 (100ns)",
            "Intervalo de atualização (100ns)", "Интервал обновления (100нс)", "更新间隔 (100ns)")
        t("Client.MinPoll") = D(
            "Min Poll Interval (log2 s)", "最小ポーリング間隔 (log2 秒)",
            "Min. Abfrageintervall (log2 s)", "Intervalo mín. sondeo (log2 s)",
            "Intervalle sondage min. (log2 s)", "Intervallo poll min. (log2 s)",
            "최소 폴링 간격 (log2 초)", "Intervalo mín. sondagem (log2 s)",
            "Мин. интервал опроса (log2 с)", "最小轮询间隔 (log2 s)")
        t("Client.MaxPoll") = D(
            "Max Poll Interval (log2 s)", "最大ポーリング間隔 (log2 秒)",
            "Max. Abfrageintervall (log2 s)", "Intervalo máx. sondeo (log2 s)",
            "Intervalle sondage max. (log2 s)", "Intervallo poll max. (log2 s)",
            "최대 폴링 간격 (log2 초)", "Intervalo máx. sondagem (log2 s)",
            "Макс. интервал опроса (log2 с)", "最大轮询间隔 (log2 s)")
        t("Client.Card.CrossSite") = D(
            "Cross-Site & Peer Retry", "クロスサイト・ピア再試行",
            "Cross-Site & Peer-Wiederholung", "Cross-Site y reintento de par",
            "Cross-Site et nouvelle tentative", "Cross-Site e nuovo tentativo peer",
            "교차 사이트 및 피어 재시도", "Cross-Site e nova tentativa",
            "Межсайтовая синхронизация", "跨站点和对等重试")
        t("Client.CrossSiteSync") = D(
            "Allow Cross-Site Sync", "クロスサイト同期を許可する",
            "Cross-Site-Synchronisierung erlauben", "Permitir sincronización entre sitios",
            "Autoriser la synchronisation entre sites", "Consenti sincronizzazione cross-site",
            "사이트 간 동기화 허용", "Permitir sincronização entre sites",
            "Разрешить межсайтовую синхронизацию", "允许跨站点同步")
        t("Client.BackOffMinutes") = D(
            "Back-Off Minutes", "バックオフ時間 (分)", "Rückzugsminuten",
            "Minutos de espera", "Minutes de repli", "Minuti di attesa",
            "대기 시간 (분)", "Minutos de recuo", "Период отступления (мин)", "退避分钟数")
        t("Client.BackOffMaxTimes") = D(
            "Back-Off Max Times", "バックオフ最大回数", "Maximale Rückzugsversuche",
            "Máx. intentos de espera", "Max. tentatives de repli", "Max tentativi attesa",
            "최대 대기 횟수", "Máx. tentativas de recuo",
            "Макс. повторов отступления", "最大退避次数")

        ' ---- Server page
        t("Server.Title") = D(
            "Server Settings", "サーバー設定", "Server-Einstellungen",
            "Configuración del servidor", "Paramètres serveur",
            "Impostazioni server", "서버 설정",
            "Configurações do servidor", "Настройки сервера", "服务器设置")
        t("Server.Card.Basic") = D(
            "NTP Server", "NTP サーバー", "NTP-Server", "Servidor NTP",
            "Serveur NTP", "Server NTP", "NTP 서버", "Servidor NTP", "NTP-сервер", "NTP 服务器")
        t("Server.Enabled") = D(
            "Enable NTP Server", "NTP サーバーを有効にする",
            "NTP-Server aktivieren", "Habilitar servidor NTP",
            "Activer le serveur NTP", "Abilita server NTP",
            "NTP 서버 사용", "Habilitar servidor NTP",
            "Включить NTP-сервер", "启用 NTP 服务器")
        t("Server.AnnounceFlags") = D(
            "Announce Flags", "アナウンスフラグ", "Ankündigungsflags",
            "Banderas de anuncio", "Drapeaux d'annonce", "Flag di annuncio",
            "공지 플래그", "Flags de anúncio", "Флаги анонсирования", "公告标志")
        t("Server.SecureOnly") = D(
            "Accept Secure Packets Only", "セキュアパケットのみ受け付ける",
            "Nur sichere Pakete akzeptieren", "Aceptar solo paquetes seguros",
            "Accepter uniquement les paquets sécurisés", "Accetta solo pacchetti sicuri",
            "보안 패킷만 허용", "Aceitar apenas pacotes seguros",
            "Принимать только защищённые пакеты", "仅接受安全数据包")
        t("Server.Card.Phase") = D(
            "Phase Correction", "位相補正", "Phasenkorrektur",
            "Corrección de fase", "Correction de phase",
            "Correzione di fase", "위상 보정",
            "Correção de fase", "Коррекция фазы", "相位校正")
        t("Server.MaxPosPhase") = D(
            "Max Positive Phase Correction (s)", "最大正位相補正 (s)",
            "Max. positive Phasenkorrektur (s)", "Corrección fase positiva máx. (s)",
            "Correction phase positive max. (s)", "Correzione fase positiva max. (s)",
            "최대 양의 위상 보정 (s)", "Correção fase positiva máx. (s)",
            "Макс. положит. коррекция фазы (с)", "最大正相位校正 (s)")
        t("Server.MaxNegPhase") = D(
            "Max Negative Phase Correction (s)", "最大負位相補正 (s)",
            "Max. negative Phasenkorrektur (s)", "Corrección fase negativa máx. (s)",
            "Correction phase négative max. (s)", "Correzione fase negativa max. (s)",
            "최대 음의 위상 보정 (s)", "Correção fase negativa máx. (s)",
            "Макс. отрицат. коррекция фазы (с)", "最大负相位校正 (s)")
        t("Server.MaxPhaseOffset") = D(
            "Max Allowed Phase Offset (s)", "最大許容位相オフセット (s)",
            "Max. zulässiger Phasenversatz (s)", "Desviación de fase máx. permitida (s)",
            "Décalage phase max. autorisé (s)", "Offset fase max. consentito (s)",
            "최대 허용 위상 오프셋 (s)", "Offset fase máx. permitido (s)",
            "Макс. допустимое смещение фазы (с)", "最大允许相位偏移 (s)")
        t("Server.Card.Chain") = D(
            "Chain Settings (RODC)", "チェーン設定 (RODC)", "Ketteneinstellungen (RODC)",
            "Configuración de cadena (RODC)", "Paramètres de chaîne (RODC)",
            "Impostazioni catena (RODC)", "체인 설정 (RODC)",
            "Configurações de cadeia (RODC)", "Настройки цепочки (RODC)", "链设置 (RODC)")
        t("Server.ChainEntryTimeout") = D(
            "Chain Entry Timeout (s)", "チェーンエントリタイムアウト (s)",
            "Ketteneintrag-Timeout (s)", "Tiempo de espera de entrada de cadena (s)",
            "Délai d'entrée de chaîne (s)", "Timeout voce catena (s)",
            "체인 항목 시간 초과 (s)", "Tempo limite de entrada de cadeia (s)",
            "Тайм-аут записи цепочки (с)", "链条目超时 (s)")

        ' ---- Advanced page
        t("Advanced.Title") = D(
            "Advanced Settings", "詳細設定", "Erweiterte Einstellungen",
            "Configuración avanzada", "Paramètres avancés",
            "Impostazioni avanzate", "고급 설정",
            "Configurações avançadas", "Дополнительные настройки", "高级设置")
        t("Advanced.Card.TimeCorrection") = D(
            "Time Correction", "時刻補正", "Zeitkorrektur",
            "Corrección de hora", "Correction de l'heure",
            "Correzione ora", "시간 보정",
            "Correção de hora", "Коррекция времени", "时间校正")
        t("Advanced.UpdateInterval") = D(
            "Update Interval (100ns)", "更新間隔 (100ns)", "Aktualisierungsintervall (100ns)",
            "Intervalo de actualización (100ns)", "Intervalle de mise à jour (100ns)",
            "Intervallo aggiornamento (100ns)", "업데이트 간격 (100ns)",
            "Intervalo de atualização (100ns)", "Интервал обновления (100нс)", "更新间隔 (100ns)")
        t("Advanced.FreqCorrectRate") = D(
            "Frequency Correct Rate", "周波数補正レート", "Frequenzkorrekturrate",
            "Tasa de corrección de frecuencia", "Taux de correction de fréquence",
            "Tasso correzione frequenza", "주파수 보정 비율",
            "Taxa de correção de frequência", "Скорость коррекции частоты", "频率校正率")
        t("Advanced.PhaseCorrectRate") = D(
            "Phase Correct Rate", "位相補正レート", "Phasenkorrekturrate",
            "Tasa de corrección de fase", "Taux de correction de phase",
            "Tasso correzione fase", "위상 보정 비율",
            "Taxa de correção de fase", "Скорость коррекции фазы", "相位校正率")
        t("Advanced.ClockHoldoverPeriod") = D(
            "Clock Holdover Period (s)", "クロックホールドオーバー期間 (s)",
            "Takthaltedauer (s)", "Período de retención del reloj (s)",
            "Période de maintien de l'horloge (s)", "Periodo holdover orologio (s)",
            "클록 홀드오버 기간 (s)", "Período de retenção do relógio (s)",
            "Период удержания часов (с)", "时钟保持周期 (s)")
        t("Advanced.Card.Spike") = D(
            "Spike Detection", "スパイク検出", "Spike-Erkennung",
            "Detección de picos", "Détection de pics",
            "Rilevamento spike", "스파이크 감지",
            "Detecção de picos", "Обнаружение выбросов", "毛刺检测")
        t("Advanced.LargePhaseOffset") = D(
            "Large Phase Offset (100ns)", "大きな位相オフセット (100ns)",
            "Großer Phasenversatz (100ns)", "Desviación de fase grande (100ns)",
            "Grand décalage de phase (100ns)", "Grande offset di fase (100ns)",
            "큰 위상 오프셋 (100ns)", "Grande offset de fase (100ns)",
            "Большое смещение фазы (100нс)", "大相位偏移 (100ns)")
        t("Advanced.SpikeWatchPeriod") = D(
            "Spike Watch Period (s)", "スパイク監視期間 (s)",
            "Spike-Überwachungszeitraum (s)", "Período de vigilancia de picos (s)",
            "Période de surveillance des pics (s)", "Periodo sorveglianza spike (s)",
            "스파이크 감시 기간 (s)", "Período de vigilância de picos (s)",
            "Период наблюдения за выбросами (с)", "毛刺监测周期 (s)")
        t("Advanced.HoldPeriod") = D(
            "Hold Period (s)", "ホールド期間 (s)", "Haltezeit (s)",
            "Período de retención (s)", "Période de maintien (s)", "Periodo di attesa (s)",
            "유지 기간 (s)", "Período de retenção (s)", "Период удержания (с)", "保持周期 (s)")
        t("Advanced.Card.Misc") = D("Miscellaneous", "その他", "Sonstiges",
                                     "Miscelánea", "Divers", "Varie",
                                     "기타", "Diverso", "Прочее", "其他")
        t("Advanced.LocalClockDispersion") = D(
            "Local Clock Dispersion (s)", "ローカルクロック分散 (s)",
            "Lokale Taktstreuung (s)", "Dispersión del reloj local (s)",
            "Dispersion de l'horloge locale (s)", "Dispersione orologio locale (s)",
            "로컬 클록 분산 (s)", "Dispersão do relógio local (s)",
            "Дисперсия локальных часов (с)", "本地时钟分散 (s)")
        t("Advanced.AuditLimit") = D(
            "Clock Adjustment Audit Limit (100ns)", "クロック調整監査制限 (100ns)",
            "Taktanpassungs-Prüflimit (100ns)", "Límite auditoría ajuste reloj (100ns)",
            "Limite audit ajustement horloge (100ns)", "Limite audit regolazione orologio (100ns)",
            "시계 조정 감사 한도 (100ns)", "Limite auditoria ajuste relógio (100ns)",
            "Лимит аудита корр. часов (100нс)", "时钟调整审计限制 (100ns)")
        t("Advanced.Card.Logging") = D("Logging", "ログ設定", "Protokollierung",
                                        "Registro", "Journalisation", "Registrazione",
                                        "로깅", "Registro", "Ведение журнала", "日志记录")
        t("Advanced.FileLogName") = D(
            "Log File Path", "ログファイルパス", "Protokolldateipfad",
            "Ruta del archivo de registro", "Chemin du fichier journal",
            "Percorso file di log", "로그 파일 경로",
            "Caminho do arquivo de log", "Путь к файлу журнала", "日志文件路径")
        t("Advanced.FileLogEntries") = D(
            "Log Entries Mask", "ログエントリマスク", "Protokolleintragsmaske",
            "Máscara de entradas de registro", "Masque entrées journal",
            "Maschera voci log", "로그 항목 마스크",
            "Máscara de entradas de log", "Маска записей журнала", "日志条目掩码")
        t("Advanced.FileLogSize") = D(
            "Max Log File Size (KB)", "最大ログファイルサイズ (KB)",
            "Max. Protokolldateigröße (KB)", "Tamaño máx. archivo de registro (KB)",
            "Taille max. fichier journal (KB)", "Dimensione max file log (KB)",
            "최대 로그 파일 크기 (KB)", "Tamanho máx. arquivo de log (KB)",
            "Макс. размер файла журнала (КБ)", "最大日志文件大小 (KB)")

        ' ---- Config View page
        t("ConfigView.Title") = D("Configuration", "設定確認", "Konfiguration",
                                   "Configuración", "Configuration",
                                   "Configurazione", "구성",
                                   "Configuração", "Конфигурация", "配置")
        t("ConfigView.Card.Raw") = D(
            "Raw Configuration Output (w32tm /query /configuration /verbose)",
            "設定の生テキスト (w32tm /query /configuration /verbose)",
            "Rohe Konfigurationsausgabe (w32tm /query /configuration /verbose)",
            "Salida de configuración sin procesar (w32tm /query /configuration /verbose)",
            "Sortie de configuration brute (w32tm /query /configuration /verbose)",
            "Output configurazione grezza (w32tm /query /configuration /verbose)",
            "원시 구성 출력 (w32tm /query /configuration /verbose)",
            "Saída de configuração bruta (w32tm /query /configuration /verbose)",
            "Вывод конфигурации (w32tm /query /configuration /verbose)",
            "原始配置输出 (w32tm /query /configuration /verbose)")

        ' ---- Common buttons
        t("Btn.Apply") = D("Apply", "適用", "Übernehmen", "Aplicar",
                           "Appliquer", "Applica", "적용", "Aplicar", "Применить", "应用")
        t("Btn.Reset") = D(
            "Reset to Defaults", "デフォルトに戻す", "Auf Standard zurücksetzen",
            "Restablecer valores", "Rétablir les valeurs par défaut",
            "Ripristina predefiniti", "기본값으로 재설정",
            "Redefinir padrões", "Сбросить настройки", "重置为默认值")
        t("Btn.Refresh") = D("Refresh", "更新", "Aktualisieren", "Actualizar",
                              "Actualiser", "Aggiorna", "새로 고침",
                              "Atualizar", "Обновить", "刷新")
        t("Btn.Browse") = D("Browse...", "参照...", "Durchsuchen...", "Examinar...",
                             "Parcourir...", "Sfoglia...", "찾아보기...",
                             "Procurar...", "Обзор...", "浏览...")

        ' ---- Menu
        t("Menu.Language") = D("Language", "言語", "Sprache", "Idioma",
                                "Langue", "Lingua", "언어", "Idioma", "Язык", "语言")
        t("Menu.About") = D("About", "バージョン情報", "Info", "Acerca de",
                             "À propos", "Informazioni", "정보", "Sobre", "О программе", "关于")

        ' ---- Messages
        t("Msg.ApplySuccess") = D(
            "Settings applied successfully.", "設定を適用しました。",
            "Einstellungen erfolgreich übernommen.", "Configuración aplicada correctamente.",
            "Paramètres appliqués avec succès.", "Impostazioni applicate.",
            "설정이 성공적으로 적용되었습니다.", "Configurações aplicadas com sucesso.",
            "Настройки успешно применены.", "设置已成功应用。")
        t("Msg.ApplyFailed") = D(
            "Failed to apply settings:", "設定の適用に失敗しました:",
            "Einstellungen konnten nicht übernommen werden:", "Error al aplicar la configuración:",
            "Échec de l'application des paramètres:", "Impossibile applicare le impostazioni:",
            "설정 적용 실패:", "Falha ao aplicar configurações:",
            "Ошибка применения настроек:", "应用设置失败：")
        t("Msg.SyncStarted") = D(
            "Time synchronization initiated.", "時刻同期を開始しました。",
            "Zeitsynchronisierung eingeleitet.", "Sincronización de hora iniciada.",
            "Synchronisation de l'heure lancée.", "Sincronizzazione ora avviata.",
            "시간 동기화가 시작되었습니다.", "Sincronização de hora iniciada.",
            "Синхронизация времени запущена.", "已启动时间同步。")
        t("Msg.ServiceError") = D(
            "Service error:", "サービスエラー:", "Dienstfehler:",
            "Error del servicio:", "Erreur de service:", "Errore servizio:",
            "서비스 오류:", "Erro de serviço:", "Ошибка службы:", "服务错误：")
        t("Msg.ResetConfirm") = D(
            "Reset all settings on this page to Windows defaults?",
            "このページのすべての設定を Windows のデフォルト値に戻しますか？",
            "Alle Einstellungen dieser Seite auf Windows-Standardwerte zurücksetzen?",
            "¿Restablecer todos los ajustes de esta página a los valores predeterminados de Windows?",
            "Réinitialiser tous les paramètres de cette page aux valeurs par défaut de Windows?",
            "Ripristinare tutte le impostazioni di questa pagina ai valori predefiniti di Windows?",
            "이 페이지의 모든 설정을 Windows 기본값으로 재설정하시겠습니까?",
            "Redefinir todas as configurações desta página para os padrões do Windows?",
            "Сбросить все настройки этой страницы до значений Windows по умолчанию?",
            "将此页面上的所有设置重置为 Windows 默认值吗？")

        ' ---- Tooltips (en + ja only)
        t("Tip.Client.Enabled") = Tip(
            "Enable or disable the Windows NTP client. When disabled, the system will not sync time from NTP servers.",
            "Windows NTP クライアントを有効または無効にします。無効の場合、NTP サーバーから時刻を同期しません。")
        t("Tip.Client.SyncType") = Tip(
            "NTP: sync from servers. NT5DS: sync from AD domain hierarchy. NoSync: disabled. AllSync: all sources.",
            "NTP: サーバーから同期。NT5DS: AD ドメイン階層から同期。NoSync: 無効。AllSync: 全ソースを使用。")
        t("Tip.Client.NtpServers") = Tip(
            "Comma-separated list of NTP servers with optional flag suffixes (e.g. time.windows.com,0x8).",
            "NTP サーバーのカンマ区切りリスト（例: time.windows.com,0x8）。オプションのフラグサフィックス付き。")
        t("Tip.Client.Flag8") = Tip(
            "0x8 – SpecialInterval: poll at SpecialPollInterval instead of the dynamic Min/MaxPollInterval.",
            "0x8 – SpecialInterval: 動的な Min/MaxPollInterval ではなく SpecialPollInterval でポーリングします。")
        t("Tip.Client.Flag4") = Tip(
            "0x4 – UseAsFallbackOnly: use this source only when all preferred sources are unavailable.",
            "0x4 – UseAsFallbackOnly: 優先ソースが利用できない場合にのみこのソースを使用します。")
        t("Tip.Client.Flag1") = Tip(
            "0x1 – SymmetricActive: request bidirectional time exchange (symmetric active NTP mode).",
            "0x1 – SymmetricActive: 双方向の時刻交換（対称アクティブ NTP モード）を要求します。")
        t("Tip.Client.UpdateInterval") = Tip(
            "How often the time service updates the local clock, in 100ns units. Default: 30,000,000 (3 s).",
            "時刻サービスがローカルクロックを更新する頻度（100ns 単位）。デフォルト: 30,000,000（3秒）。")
        t("Tip.Client.MinPoll") = Tip(
            "Minimum polling interval as log2 seconds (e.g. 6 = 64 s). Default: 10.",
            "最小ポーリング間隔（log2 秒、例: 6 = 64秒）。デフォルト: 10。")
        t("Tip.Client.MaxPoll") = Tip(
            "Maximum polling interval as log2 seconds (e.g. 15 ≈ 9 h). Default: 15.",
            "最大ポーリング間隔（log2 秒、例: 15 ≈ 9時間）。デフォルト: 15。")
        t("Tip.Client.CrossSiteSync") = Tip(
            "Allow the NTP client to sync from sources outside its Active Directory site.",
            "NTP クライアントが Active Directory サイト外のソースと同期することを許可します。")
        t("Tip.Client.BackOffMinutes") = Tip(
            "Minutes to wait before retrying cross-site sync after a failure.",
            "クロスサイト同期が失敗した後、再試行するまで待機する時間（分）。")
        t("Tip.Client.BackOffMaxTimes") = Tip(
            "Maximum number of cross-site sync retries before giving up.",
            "クロスサイト同期を諦めるまでの最大再試行回数。")
        t("Tip.Server.Enabled") = Tip(
            "Enable NTP server mode. Other devices on the network can sync their clocks from this machine.",
            "NTP サーバーモードを有効にします。ネットワーク上の他のデバイスがこのマシンから時刻を同期できます。")
        t("Tip.Server.AnnounceFlags") = Tip(
            "Controls how this machine advertises itself as a time source. 5 = reliable, 10 = unreliable. Default: 10.",
            "このマシンが時刻ソースとして自身を広告する方法を制御します。5 = 信頼性あり、10 = 信頼性なし。デフォルト: 10。")
        t("Tip.Server.SecureOnly") = Tip(
            "When enabled, reject NTP requests from unauthenticated (non-Windows) clients.",
            "有効にすると、認証されていない（非 Windows）クライアントからの NTP リクエストを拒否します。")
        t("Tip.Server.MaxPosPhase") = Tip(
            "Maximum positive phase correction in seconds. Offsets larger than this are rejected. Default: 172800 (48 h).",
            "正の位相補正の最大値（秒）。これより大きなオフセットは拒否されます。デフォルト: 172800（48時間）。")
        t("Tip.Server.MaxNegPhase") = Tip(
            "Maximum negative phase correction in seconds. Offsets larger than this are rejected. Default: 172800 (48 h).",
            "負の位相補正の最大値（秒）。これより大きなオフセットは拒否されます。デフォルト: 172800（48時間）。")
        t("Tip.Server.MaxPhaseOffset") = Tip(
            "Offsets above this value (s) trigger a step adjustment instead of a gradual slew. Default: 1.",
            "この値（秒）を超えるオフセットは段階的スルーではなくステップ調整をトリガーします。デフォルト: 1。")
        t("Tip.Server.ChainEntryTimeout") = Tip(
            "Timeout in seconds for RODC time-chain entries. Relevant for Read-Only Domain Controllers.",
            "RODC タイムチェーンエントリのタイムアウト（秒）。読み取り専用ドメインコントローラーに関連します。")
        t("Tip.Advanced.UpdateInterval") = Tip(
            "Clock update frequency in 100ns units. Default: 30,000,000 (3 s).",
            "100ns 単位のクロック更新頻度。デフォルト: 30,000,000（3秒）。")
        t("Tip.Advanced.FreqCorrectRate") = Tip(
            "Rate at which W32tm corrects clock frequency drift. Higher = faster correction. Default: 4.",
            "W32tm がクロック周波数ドリフトを補正するレート。高いほど速く補正されます。デフォルト: 4。")
        t("Tip.Advanced.PhaseCorrectRate") = Tip(
            "Rate at which the service adjusts time phase (offset). Higher = faster correction. Default: 7.",
            "サービスが時刻位相（オフセット）を調整するレート。高いほど速く補正されます。デフォルト: 7。")
        t("Tip.Advanced.ClockHoldoverPeriod") = Tip(
            "Seconds the clock can operate without an NTP sync before switching to local fallback mode.",
            "ローカルフォールバックモードに切り替わる前に、NTP 同期なしでクロックが動作できる秒数。")
        t("Tip.Advanced.LargePhaseOffset") = Tip(
            "Time offset (100ns) considered a spike. Offsets above this trigger spike detection. Default: 50,000,000 (5 s).",
            "スパイクと見なされる時刻オフセット（100ns）。この値を超えるとスパイク検出が発動します。デフォルト: 50,000,000（5秒）。")
        t("Tip.Advanced.SpikeWatchPeriod") = Tip(
            "Duration (s) to monitor for repeated spikes before taking corrective action. Default: 900.",
            "修正措置を取る前にスパイクの繰り返しを監視する期間（秒）。デフォルト: 900。")
        t("Tip.Advanced.HoldPeriod") = Tip(
            "After a spike, ignore new samples for this many seconds to let the clock stabilize. Default: 5.",
            "スパイク後、クロックが安定するまでこの秒数の間、新しいサンプルを無視します。デフォルト: 5。")
        t("Tip.Advanced.LocalClockDispersion") = Tip(
            "Dispersion (s) assigned to this machine's local clock when used as an NTP reference. Default: 10.",
            "NTP 参照として使用する場合にこのマシンのローカルクロックに割り当てられる分散値（秒）。デフォルト: 10。")
        t("Tip.Advanced.AuditLimit") = Tip(
            "Clock adjustments above this threshold (100ns) are written to the event log. 0 = disabled. Default: 800.",
            "この閾値（100ns）を超えるクロック調整がイベントログに記録されます。0 = 無効。デフォルト: 800。")
        t("Tip.Advanced.FileLogName") = Tip(
            "Path to the W32Time debug log file. Leave empty to use the default Windows event log.",
            "W32Time デバッグログファイルのパス。空のままにするとデフォルトの Windows イベントログが使用されます。")
        t("Tip.Advanced.FileLogEntries") = Tip(
            "Bitmask of events to write to the log file. 0 = disabled. See W32tm documentation for values.",
            "ログファイルに書き込むイベントのビットマスク。0 = 無効。値については W32tm ドキュメントを参照。")
        t("Tip.Advanced.FileLogSize") = Tip(
            "Maximum size of the W32Time log file in KB. When reached, the log wraps. 0 = disabled. Default: 0.",
            "W32Time ログファイルの最大サイズ（KB）。達すると折り返されます。0 = 無効。デフォルト: 0。")

        ' ---- About dialog
        t("About.Title") = D(
            "About NTPilot", "NTPilot について", "Über NTPilot",
            "Acerca de NTPilot", "À propos de NTPilot",
            "Informazioni su NTPilot", "NTPilot 정보",
            "Sobre NTPilot", "О программе NTPilot", "关于 NTPilot")
        t("About.Version") = D("Version", "バージョン", "Version", "Versión",
                                "Version", "Versione", "버전", "Versão", "Версия", "版本")

        ' ---- Status bar
        t("StatusBar.Ready") = D("Ready", "準備完了", "Bereit", "Listo",
                                  "Prêt", "Pronto", "준비", "Pronto", "Готово", "就绪")
        t("StatusBar.Refreshing") = D(
            "Refreshing...", "更新中...", "Wird aktualisiert...",
            "Actualizando...", "Actualisation...", "Aggiornamento...",
            "새로 고침 중...", "Atualizando...", "Обновление...", "刷新中...")
        t("StatusBar.Applying") = D(
            "Applying...", "適用中...", "Wird übernommen...",
            "Aplicando...", "Application...", "Applicazione...",
            "적용 중...", "Aplicando...", "Применение...", "应用中...")

        Return t
    End Function

End Module
