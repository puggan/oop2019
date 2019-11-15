<?php
declare(strict_types=1);

use Codedungeon\PHPCliColors\Color;
use Puggan\Oop2019\Console;

require_once __DIR__ . '/../vendor/autoload.php';

$partColors = [];
$parts = [];
// @see https://en.wikipedia.org/wiki/Tetris#/media/File:Tetrominoes_IJLO_STZ_Worlds.svg
// @see https://pradeep1210.files.wordpress.com/2010/02/tetrisshapes5b35d.jpg

$partColors[] = Color::BG_CYAN;
$parts[] = [[1, 1, 1, 1]]; // I
$partColors[] = Color::BG_BLUE;
$parts[] = [[1, 0, 0 ], [ 1, 1, 1]]; // J
$partColors[] = Color::BG_YELLOW;
$parts[] = [[1, 1, 1 ], [ 1, 0, 0]]; // L
$partColors[] = Color::BG_YELLOW;
$parts[] = [[1, 1 ], [ 1, 1]]; // O
$partColors[] = Color::BG_GREEN;
$parts[] = [[0, 1, 1 ], [ 1, 1, 0]]; // S
$partColors[] = Color::BG_MAGENTA;
$parts[] = [[1, 1, 1 ], [ 0, 1, 0]]; // T
$partColors[] = Color::BG_RED;
$parts[] = [[1, 1, 0 ], [ 0, 1, 1]]; // Z

Console::Clear();
foreach($parts as $row => $part)
{
    tetrisPrint($part, 1, 1 + 5 * $row, $partColors[$row]);
    foreach(range(0, 3) as $col)
    {
        $part = rotateCCW($part);
        tetrisPrint($part, 6 + 5 * $col, 1 + 5 * $row, $partColors[$row]);
    }
}
Console::ResetColor();
Console::SetCursorPosition(1, 1 + 5 * count($parts));

function rotateCW($matrix)
{
    if (count($matrix) > 1) {
        return array_map(null, ...array_reverse($matrix));
    }
    return array_map(
        static function ($r) {
            return [$r];
        },
        $matrix[0]
    );
}

function rotateCCW($matrix)
{
    if (count($matrix) > 1) {
        return array_reverse(array_map(null, ...$matrix));
    }
    return array_map(
        static function ($r) {
            return [$r];
        },
        array_reverse($matrix[0])
    );
}

function rotate180($matrix)
{
    return array_reverse(array_map('array_reverse', $matrix));
}

function tetrisPrint($part, $xStart, $yStart, $color)
{
    echo $color;
    foreach($part as $y => $row)
    {
        $restart = true;
        foreach($row as $x => $bit)
        {
            if ($bit) {
                if($restart) {
                    Console::SetCursorPosition(2 * ($xStart + $x), $yStart + $y);
                    $restart = false;
                }
                echo '  ';
            } else {
                $restart = true;
            }
        }
    }
}
