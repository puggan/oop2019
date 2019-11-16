<?php
declare(strict_types=1);

use Puggan\Oop2019\Console;

require_once __DIR__ . '/../vendor/autoload.php';

$firstNumber = Console::ReadInt('Type a number');
$lastNumber = Console::ReadInt('Type another number');

echo PHP_EOL, "{$firstNumber} + {$lastNumber} = ", $firstNumber + $lastNumber, PHP_EOL;
