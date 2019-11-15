<?php
declare(strict_types=1);

use Puggan\Oop2019\Console;

require_once __DIR__ . '/../vendor/autoload.php';

while (true)
{
    Console::BackgroundColor(random_int(0,15));
    echo PHP_EOL;
    usleep(200000);
}
