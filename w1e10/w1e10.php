<?php
declare(strict_types=1);

use Puggan\Oop2019\Console;
use Puggan\Oop2019\Invader;

require_once __DIR__ . '/../vendor/autoload.php';

$invader = new Invader();
[$sizex, $sizey] = Console::Size();

foreach(range(0, $sizey - 1) as $posy)
{
    $maxx = $sizex - 1 - $invader->width;
    if ($posy & 1) {
        $steps = range($maxx, 0, -1);
    } else {
        $steps = range(0, $maxx);
    }
    foreach($steps as $posx) {
        Console::Clear();
        $invader->print($posx, $posy);
        usleep(100000);
    }
}
