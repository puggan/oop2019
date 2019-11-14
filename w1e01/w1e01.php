<?php
declare(strict_types=1);

require_once __DIR__ . '/../vendor/autoload.php';

use Puggan\Oop2019\Console;

$firstNumber = Console::ReadInt('Type a number');
$lastNumber = Console::ReadInt('Type another number');

echo PHP_EOL, "{$firstNumber} + {$lastNumber} = ", $firstNumber + $lastNumber, PHP_EOL;
