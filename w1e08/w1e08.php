<?php
declare(strict_types=1);

use Codedungeon\PHPCliColors\Color;
use Puggan\Oop2019\Console;

require_once __DIR__ . '/../vendor/autoload.php';

Console::ResetColor();
$size = Console::ReadInt('Please input size of tree');

if ($size < 2)
{
    Console::ErrorWriteLine('Sorry, the smalles I can draw is a size 2.');
    exit();
}

foreach(range(0, $size) as $row)
{
    echo
        str_repeat(' ', $size - $row),
        Color::YELLOW, Color::BG_GREEN,
        str_repeat('*', 2 * $row + 1),
        Color::RESET,
        PHP_EOL;
}
echo str_repeat(' ', $size - 1), Color::BG_YELLOW, '[ ]', Color::RESET, PHP_EOL;
