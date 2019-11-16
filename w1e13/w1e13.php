<?php
declare(strict_types=1);

use Codedungeon\PHPCliColors\Color;
use Puggan\Oop2019\Bag;
use Puggan\Oop2019\Console;
use Puggan\Oop2019\TetrisBlock;

require_once __DIR__ . '/../vendor/autoload.php';

Console::Clear();
$bag = new Bag(
    [
        new TetrisBlock([[0, 0, 0, 0], [1, 1, 1, 1], [0, 0, 0, 0]], Color::BG_CYAN),
        new TetrisBlock([[1, 0, 0], [1, 1, 1], [0, 0, 0]], Color::BG_BLUE),
        new TetrisBlock([[0, 0, 1], [1, 1, 1], [0, 0, 0]], Color::BG_YELLOW),
        new TetrisBlock([[1, 1], [1, 1]], Color::BG_YELLOW),
        new TetrisBlock([[0, 1, 1], [1, 1, 0]], Color::BG_GREEN),
        new TetrisBlock([[1, 1, 0], [0, 1, 1]], Color::BG_RED),
        new TetrisBlock([[0, 1, 0], [1, 1, 1], [0, 0, 0]], Color::BG_MAGENTA),
    ]
);
/** @var TetrisBlock $tetris */
foreach (range(0, 9) as $row) {
    foreach (range(0, 13) as $col) {
        $bag->Next()->Print(1 + $col * 5, 1 + $row * 5);
    }
}
echo PHP_EOL;
