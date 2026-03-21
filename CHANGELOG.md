# Changelog

All notable changes to NTPilot will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [1.1.0] - 2026-03-22

### Changed
- Redesigned UI: compact admin tool style with horizontal top tab strip (Process Hacker / HWiNFO inspired)
- Replaced left navigation panel with top tab strip for more content space
- Added persistent info bar below tabs showing live NTP service status on every page
- Enlarged default window size for better readability
- App icon now loads reliably from the embedded EXE resource

## [1.0.0] - 2025-01-01

### Added
- Initial release
- Status tab: Windows Time service control and live NTP status display
- Client tab: NTP client configuration (sync type, servers, flags, polling intervals)
- Server tab: NTP server configuration (announce flags, phase correction, chain settings)
- Advanced tab: Fine-tuning parameters (time correction, spike detection, logging)
- Config View tab: Raw w32tm configuration output
- Multi-language support (English, 日本語, Deutsch, Español, Français, Italiano, 한국어, Português, Русский, 中文)
- Windows Settings app style UI with left navigation panel
- System dark/light theme following
- Native x64, x86, ARM64 builds
- Per-monitor DPI awareness
