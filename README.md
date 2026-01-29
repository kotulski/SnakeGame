# SnakeGame - Projekt C#

Projekt klasycznej gry Snake zrealizowany w technologii .NET Console App. Głównym celem projektu była nauka współpracy przy użyciu systemu kontroli wersji Git oraz symulacja środowiska pracy zespołowej (GitFlow).

## 🎮 Opis Gry
Gracz steruje wężem poruszającym się po planszy. Celem jest zbieranie owoców (pojawiających się losowo), co powoduje wydłużenie węża i zwiększenie licznika punktów. Gra kończy się w momencie uderzenia w ścianę lub we własny ogon.

## 🚀 Zaimplementowane Funkcje
* **Silnik Gry:** Płynne sterowanie bez blokowania wątku głównego (wykorzystanie `Console.KeyAvailable`).
* **System Kolizji:** Wykrywanie zderzeń ze ścianami oraz z segmentami ogona.
* **Grafika:** Zoptymalizowany system renderowania (brak migotania ekranu, ukryty kursor).
* **Interfejs Sieciowy (Symulacja):** Moduł startowy symulujący nawiązywanie połączenia z drugim graczem (wymóg projektowy "Współpraca na Konsoli").
* **Restart:** Możliwość ponownego uruchomienia rozgrywki po przegranej (Game Over) bez konieczności restartu aplikacji.

## 🛠️ Instrukcja Uruchomienia
1. Sklonuj repozytorium na dysk:
   ```bash
   git clone https://github.com/kotulski/SnakeGame.git
2. Otwórz plik rozwiązania SnakeGame.sln w środowisku Visual Studio.
3. Skompiluj projekt i uruchom grę przyciskiem Start lub klawiszem F5.

## 🤝 Współpraca i Git Workflow
Projekt został zrealizowany z wykorzystaniem systemu gałęzi (Branching Strategy) w celu symulacji podziału zadań w zespole:

main: Główna, stabilna wersja kodu.

fix-classes: Gałąź naprawcza - uzupełnienie brakujących właściwości w klasach Obstakel i Pixel oraz refaktoryzacja nazewnictwa.

fix-game-logic: Gałąź implementacyjna - naprawa głównej pętli gry, logiki poruszania się i renderowania.

feature-multiplayer: Gałąź rozwojowa - dodanie ekranu symulującego łączenie z serwerem.

Każda zmiana była wprowadzana poprzez Pull Request, poddawana weryfikacji i scalana z gałęzią główną.

## 👥 Autorzy
Patryk Kotulski - Główny Programista
