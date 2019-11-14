<?php
declare(strict_types=1);

namespace Puggan\Oop2019;

use Codedungeon\PHPCliColors\Color;

/**
 * Class Console
 * Try to emulate functions from the c# Console class
 */
class Console
{
    /**
     * @param string $string
     * @param resource|null $channel
     */
    public static function Write(string $string, $channel = null): void
    {
        fwrite($channel ?? STDOUT, $string);
    }

    /**
     * @param string $string
     * @param resource|null $channel
     */
    public static function WriteLine(string $string, $channel = null): void
    {
        fwrite($channel ?? STDOUT, $string . PHP_EOL);
    }

    /**
     * @param string $string
     * @param resource|null $channel
     */
    public static function ErrorWrite(string $string, $channel = null): void
    {
        fwrite($channel ?? STDERR, $string);
    }

    /**
     * @param string $string
     * @param resource|null $channel
     */
    public static function ErrorWriteLine(string $string, $channel = null): void
    {
        fwrite($channel ?? STDERR, $string . PHP_EOL);
    }

    /**
     * @return string
     */
    public static function ReadLine(): string
    {
        return fgets(STDIN);
    }

    /**
     * Clear the screen
     */
    public static function Clear(): void
    {
        throw new \RuntimeException(__METHOD__ . ' not implemted');
    }

    /**
     * @param resource|null $channel
     */
    public static function ResetColor($channel = null): void
    {
        self::Write(Color::RESET, $channel);
    }

    /**
     * @param int $color
     * @param resource|null $channel
     */
    public static function BackgroundColor(int $color, $channel = null): void
    {
        static $colors = [
        // Black 	0
            Color::BG_BLACK,
        // DarkBlue 	1
            Color::BG_BLUE,
        // DarkGreen 	2
            Color::BG_GREEN,
        // DarkCyan 	3
            Color::BG_CYAN,
        // DarkRed 	4
            Color::BG_RED,
        // DarkMagenta 	5
            Color::BG_MAGENTA,
        // DarkYellow 	6
            Color::BG_YELLOW,
        // Gray 	7
            Color::BG_LIGHT_GRAY,
        // DarkGray 	8
            "\033[100m",
        // Blue 	9
            "\033[104m",
        // Green 	10
            "\033[102m",
        // Cyan 	11
            "\033[106m",
        // Red 	12
            "\033[101m",
        // Magenta 	13
            "\033[105m",
        // Yellow 	14
            "\033[103m",
        // White 	15
            Color::BG_WHITE,
        ];
        self::Write($colors[$color], $channel);
    }

    /**
     * @param int $color
     * @param resource|null $channel
     */
    public static function ForgroundColor(int $color, $channel = null): void
    {
        throw new \RuntimeException(__METHOD__ . ' not implemted');
    }

    /**
     * @param int $left
     * @param int $top
     * @param resource|null $channel
     */
    public static function SetCursorPosition(int $left, int $top, $channel = null): void
    {
        self::Write("\033[<L>;<C>H", $channel);
    }

    /**
     * @return int
     */
    public static function Width(): int
    {
        return self::Size()[0];
    }

    /**
     * @return int
     */
    public static function Height(): int
    {
        return self::Size()[1];
    }

    /**
     * @return int[]
     */
    public static function Size(): array
    {
        /** @var int[] $cache */
        static $cache = null;
        if ($cache) {
            return $cache;
        }

        /** @var string[] $ini */
        $ini = parse_ini_string(shell_exec('resize'));
        $cache = [$ini['COLUMNS'], $ini['LINES']];
        return $cache;
    }

    /**
     * @param string $question
     * @return int
     */
    public static function ReadInt(string $question): int
    {
        while (true) {
            echo $question, ': ';
            $number = trim(self::ReadLine());
            if (is_numeric($number)) {
                return +$number;
            }
            self::ErrorWriteLine("That's not a number, try again");
        }
    }
}
